defmodule Lasagna do
  def expected_minutes_in_oven, do: 40

  def remaining_minutes_in_oven(minutes_so_far), do: expected_minutes_in_oven() - minutes_so_far

  def preparation_time_in_minutes(layers), do: layers * 2

  def total_time_in_minutes(layers, minutes_so_far) do
    preparation_time_in_minutes(layers) + minutes_so_far
  end

  def alarm, do: "Ding!"
end
