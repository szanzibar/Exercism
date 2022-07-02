defmodule LucasNumbers do
  @moduledoc """
  Lucas numbers are an infinite sequence of numbers which build progressively
  which hold a strong correlation to the golden ratio (φ or ϕ)

  E.g.: 2, 1, 3, 4, 7, 11, 18, 29, ...
  """

  @doc """
  generate(count) with Stream.unfold

  generate(10_000) = (4.5ms)
  """
  def generate(count) when is_integer(count) and count >= 1 do
    Stream.unfold({2, 1}, fn {first, second} -> {first, {second, first + second}} end)
    |> Enum.take(count)
  end

  # @doc """
  # generate(count) with recursion
  # generate(10_000) = (203.9ms)
  # """
  # def generate(1), do: [2]
  # def generate(2), do: [2, 1]

  # def generate(count) when is_integer(count) and count > 2 do
  #   [first, second | tail] = generate(count - 1) |> Enum.reverse()
  #   [first + second, first, second | tail] |> Enum.reverse()
  # end

  def generate(_), do: raise(ArgumentError, "count must be specified as an integer >= 1")
end
