defmodule TakeANumber do
  def start() do
    spawn(TakeANumber, :loop, [])
  end

  def loop(number \\ 0) do
    receive do
      {:report_state, pid} ->
        send(pid, number)
        loop(number)

      {:take_a_number, pid} ->
        send(pid, number + 1)
        loop(number + 1)

      :stop ->
        :ok

      _ ->
        loop(number)
    end
  end
end
