defmodule TopSecret do
  def to_ast(string), do: Code.string_to_quoted!(string)

  def decode_secret_message_part({define, meta, [{:when, _, child_args} | _]} = ast, acc) do
    {_, acc} = decode_secret_message_part({define, meta, child_args}, acc)
    {ast, acc}
  end

  def decode_secret_message_part({define, _, [{func_name, _, params} | _]} = ast, acc)
      when define in [:def, :defp] do
    arity = Enum.count(params || [])
    {ast, [func_name |> Atom.to_string() |> String.slice(0, arity) | acc]}
  end

  def decode_secret_message_part(ast, acc) do
    {ast, acc}
  end

  def decode_secret_message(string) do
    string
    |> to_ast()
    |> Macro.postwalker()
    |> Enum.filter(fn
      {def, _, _} when def in [:def, :defp] -> true
      _ -> false
    end)
    |> Enum.reduce("", fn a, acc ->
      {_, [code]} = decode_secret_message_part(a, [])
      acc <> code
    end)
  end
end
