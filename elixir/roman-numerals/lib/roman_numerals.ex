defmodule RomanNumerals do
  @doc """
  Convert the number to a roman number.
  """
  @spec numeral(pos_integer) :: String.t()
  def numeral(number, roman \\ "") do
    cond do
      number >= 1000 -> numeral(number - 1000, roman <> "M")
      number >= 900 -> numeral(number - 900, roman <> "CM")
      number >= 500 -> numeral(number - 500, roman <> "D")
      number >= 400 -> numeral(number - 400, roman <> "CD")
      number >= 100 -> numeral(number - 100, roman <> "C")
      number >= 90 -> numeral(number - 90, roman <> "XC")
      number >= 50 -> numeral(number - 50, roman <> "L")
      number >= 40 -> numeral(number - 40, roman <> "XL")
      number >= 10 -> numeral(number - 10, roman <> "X")
      number >= 9 -> numeral(number - 9, roman <> "IX")
      number >= 5 -> numeral(number - 5, roman <> "V")
      number >= 4 -> numeral(number - 4, roman <> "IV")
      number >= 1 -> numeral(number - 1, roman <> "I")
      true -> roman
    end
  end
end
