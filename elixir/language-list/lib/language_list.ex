defmodule LanguageList do
  def new(), do: []

  def add(list, language), do: [language | list]

  def remove([_hd | tl]), do: tl

  def first([hd | _tl]), do: hd

  def count(list), do: length(list)

  def exciting_list?(list), do: "Elixir" in list
end
