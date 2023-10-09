defmodule Anagram do
  @doc """
  Returns all candidates that are anagrams of, but not equal to, 'base'.
  """
  @spec match(String.t(), [String.t()]) :: [String.t()]
  def match(base, candidates) do
    base_sorted = sort_chars(base)

    candidates
    |> Enum.filter(fn candidate ->
      sort_chars(candidate) == base_sorted &&
        String.downcase(candidate) != String.downcase(base)
    end)
  end

  defp sort_chars(word),
    do: word |> String.downcase() |> String.codepoints() |> Enum.sort() |> Enum.join()
end
