use Bitwise

defmodule SecretHandshake do
  @doc """
  Determine the actions of a secret handshake based on the binary
  representation of the given `code`.

  If the following bits are set, include the corresponding action in your list
  of commands, in order from lowest to highest.

  1 = wink
  10 = double blink
  100 = close your eyes
  1000 = jump

  10000 = Reverse the order of the operations in the secret handshake
  """
  @spec commands(code :: integer) :: list(String.t())
  def commands(code) do
    secret_list =
      []
      |> command(Bitwise.band(code, 1) == 1, "wink")
      |> command(Bitwise.band(code, 2) == 2, "double blink")
      |> command(Bitwise.band(code, 4) == 4, "close your eyes")
      |> command(Bitwise.band(code, 8) == 8, "jump")

    case Bitwise.band(code, 16) == 16 do
      # We build list in reverse order
      true -> secret_list
      false -> Enum.reverse(secret_list)
    end
  end

  defp command(list, true, action), do: [action | list]
  defp command(list, false, _action), do: list
end
