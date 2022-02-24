defmodule BasketballWebsite do
  def extract_from_path(data, path) do
    String.split(path, ".")
    |> extract(data)
  end

  defp extract([], data), do: data

  defp extract([head | tail], data) do
    extract(tail, data[head])
  end

  def get_in_path(data, path) do
    get_in(data, String.split(path, "."))
  end
end
