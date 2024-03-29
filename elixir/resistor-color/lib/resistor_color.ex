defmodule ResistorColor do
  @doc """
  Return the value of a color band
  """
  @spec code(atom) :: integer()
  def code(color) do
    [
      :black,
      :brown,
      :red,
      :orange,
      :yellow,
      :green,
      :blue,
      :violet,
      :grey,
      :white
    ]
    |> Enum.find_index(&(&1 == color))
  end
end
