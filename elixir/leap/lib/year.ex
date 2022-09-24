defmodule Year do
  @doc """
  Returns whether 'year' is a leap year.

  A leap year occurs:

  on every year that is evenly divisible by 4
    except every year that is evenly divisible by 100
      unless the year is also evenly divisible by 400
  """
  @spec leap_year?(non_neg_integer) :: boolean
  def leap_year?(year) do
    evenly_divisible?(year, 4) && (!evenly_divisible?(year, 100) || evenly_divisible?(year, 400))
  end

  defp evenly_divisible?(n, d), do: rem(n, d) == 0
end
