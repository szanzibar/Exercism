# Use the Plot struct as it is provided
defmodule Plot do
  @enforce_keys [:plot_id, :registered_to]
  defstruct [:plot_id, :registered_to]
end

defmodule CommunityGarden do
  def start(opts \\ []) do
    Agent.start(fn -> {0, []} end, opts)
  end

  def list_registrations(pid) do
    Agent.get(pid, fn {_id, state} -> state end)
  end

  def register(pid, register_to) do
    Agent.update(pid, fn {id, state} ->
      {id + 1, [%Plot{plot_id: id + 1, registered_to: register_to} | state]}
    end)

    [head | _tail] = list_registrations(pid)
    head
  end

  def release(pid, plot_id) do
    Agent.update(pid, fn {id, state} ->
      {id, Enum.filter(state, &(&1.plot_id != plot_id))}
    end)
  end

  def get_registration(pid, plot_id) do
    list_registrations(pid)
    |> Enum.find({:not_found, "plot is unregistered"}, &(&1.plot_id == plot_id))
  end
end
