defmodule HighSchoolSweetheart do
  def first_letter(name), do: String.trim(name) |> String.first()

  def initial(name), do: String.upcase(first_letter(name)) <> "."

  def initials(full_name) do
    String.split(full_name, " ")
    |> Enum.map(&initial(&1))
    |> Enum.join(" ")
  end

  def pair(full_name1, full_name2) do
    """
         ******       ******
       **      **   **      **
     **         ** **         **
    **            *            **
    **                         **
    **     #{initials(full_name1)}  +  #{initials(full_name2)}     **
     **                       **
       **                   **
         **               **
           **           **
             **       **
               **   **
                 ***
                  *
    """
  end
end
