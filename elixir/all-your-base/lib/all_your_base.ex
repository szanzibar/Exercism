defmodule AllYourBase do
  @doc """
  Given a number in input base, represented as a sequence of digits, converts it to output base,
  or returns an error tuple if either of the bases are less than 2
  """

  @spec convert(list, integer, integer) :: {:ok, list} | {:error, String.t()}
  def convert(_list, _input_base, output_base) when output_base < 2 do
    {:error, "output base must be >= 2"}
  end

  def convert(_list, input_base, _output_base) when input_base < 2 do
    {:error, "input base must be >= 2"}
  end

  def convert(list, input_base, output_base) do
    try do
      converted_from = from(list, input_base, 0)
      converted_to = to(converted_from, output_base, [])

      {:ok, converted_to}
    rescue
      e in RuntimeError -> {:error, e.message}
    end
  end

  defp from([hd | _], base, _acc) when hd < 0 or hd >= base,
    do: raise("all digits must be >= 0 and < input base")

  defp from([hd | tl], base, acc), do: from(tl, base, acc + hd * Integer.pow(base, length(tl)))
  defp from([], _base, acc), do: acc

  defp to(0, _base, []), do: [0]
  defp to(0, _base, acc), do: acc
  defp to(num, base, acc), do: to(div(num, base), base, [rem(num, base) | acc])
end
