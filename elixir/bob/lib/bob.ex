defmodule Bob do
  defp empty?(input), do: String.trim(input) == ""
  defp letters?(input), do: String.match?(input, ~r/[[:alpha:]]/)
  defp question?(input), do: String.trim(input) |> String.ends_with?("?")
  defp yelling?(input), do: input == String.upcase(input) && letters?(input)
  defp yelling_question?(input), do: yelling?(input) && question?(input)

  def hey(input) when empty?(input) do
    "Fine. Be that way!"
  end

  def hey(input) do
    cond do
      yelling_question?(input) ->
        "Calm down, I know what I'm doing!"

      yelling?(input) ->
        "Whoa, chill out!"

      question?(input) ->
        "Sure."

      "Anything else?" ->
        "Whatever."
    end
  end
end
