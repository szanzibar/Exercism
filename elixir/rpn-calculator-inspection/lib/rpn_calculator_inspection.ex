defmodule RPNCalculatorInspection do
  def start_reliability_check(calculator, input) do
    %{input: input, pid: spawn_link(fn -> calculator.(input) end)}
  end

  def await_reliability_check_result(%{pid: pid, input: input}, results) do
    Process.monitor(pid)

    receive do
      {:EXIT, ^pid, :normal} ->
        Map.put(results, input, :ok)

      {:EXIT, ^pid, _} ->
        Map.put(results, input, :error)
    after
      100 -> Map.put(results, input, :timeout)
    end
  end

  def reliability_check(calculator, inputs) do
    original_trap_exit = Process.flag(:trap_exit, true)

    results =
      Enum.map(inputs, fn input -> start_reliability_check(calculator, input) end)
      |> Enum.reduce(%{}, fn start, acc ->
        await_reliability_check_result(start, %{})
        |> Map.merge(acc)
      end)

    Process.flag(:trap_exit, original_trap_exit)

    results
  end

  def correctness_check(calculator, inputs) do
    Enum.map(inputs, &Task.async(fn -> calculator.(&1) end))
    |> Task.await_many(100)
  end
end
