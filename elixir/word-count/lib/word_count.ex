defmodule WordCount do
  @doc """
  Count the number of words in the sentence.

  Words are compared case-insensitively.
  """
  @spec count(String.t()) :: map
  def count(sentence) do
    Regex.split(~r/[^[:alnum:]]/u, sentence, trim: true)
    |> IO.inspect()
    |> Enum.frequencies_by(&String.downcase/1)
  end
end
