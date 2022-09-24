defmodule TakeANumberDeluxe do
  use GenServer

  # Client API

  @spec start_link(keyword()) :: {:ok, pid()} | {:error, atom()}
  def start_link(init_arg) do
    GenServer.start_link(__MODULE__, init_arg)
    |> case do
      {:ok, pid} -> {:ok, pid}
      {:error, {:bad_return_value, error}} -> error
    end
  end

  @spec report_state(pid()) :: TakeANumberDeluxe.State.t()
  def report_state(machine) do
    GenServer.call(machine, :report_state)
  end

  @spec queue_new_number(pid()) :: {:ok, integer()} | {:error, atom()}
  def queue_new_number(machine) do
    GenServer.call(machine, :queue_new_number)
  end

  @spec serve_next_queued_number(pid(), integer() | nil) :: {:ok, integer()} | {:error, atom()}
  def serve_next_queued_number(machine, priority_number \\ nil) do
    GenServer.call(machine, {:serve_next_queued_number, priority_number})
  end

  @spec reset_state(pid()) :: :ok
  def reset_state(machine) do
    GenServer.cast(machine, :reset_state)
  end

  # Server callbacks

  @impl GenServer
  def init(init_arg) do
    TakeANumberDeluxe.State.new(
      init_arg[:min_number],
      init_arg[:max_number],
      init_arg[:auto_shutdown_timeout] || :infinity
    )
    |> case do
      {:ok, state} ->
        {:ok, state, state.auto_shutdown_timeout}

      error ->
        error
    end
  end

  @impl GenServer
  def handle_call(:report_state, _, state) do
    {:reply, state, state, state.auto_shutdown_timeout}
  end

  @impl GenServer
  def handle_call(:queue_new_number, _, state) do
    TakeANumberDeluxe.State.queue_new_number(state)
    |> case do
      {:ok, new_number, new_state} ->
        {:reply, {:ok, new_number}, new_state, state.auto_shutdown_timeout}

      error ->
        {:reply, error, state, state.auto_shutdown_timeout}
    end
  end

  @impl GenServer
  def handle_call({:serve_next_queued_number, priority_number}, _, state) do
    TakeANumberDeluxe.State.serve_next_queued_number(state, priority_number)
    |> case do
      {:ok, next_number, new_state} ->
        {:reply, {:ok, next_number}, new_state, state.auto_shutdown_timeout}

      error ->
        {:reply, error, state, state.auto_shutdown_timeout}
    end
  end

  @impl GenServer
  def handle_cast(
        :reset_state,
        %{
          min_number: min,
          max_number: max,
          auto_shutdown_timeout: timeout
        }
      ) do
    {:ok, new_state} = TakeANumberDeluxe.State.new(min, max, timeout)
    {:noreply, new_state, timeout}
  end

  @impl GenServer
  def handle_info(:timeout, state) do
    {:stop, :normal, state}
  end

  @impl GenServer
  def handle_info(_, state) do
    {:noreply, state, state.auto_shutdown_timeout}
  end
end
