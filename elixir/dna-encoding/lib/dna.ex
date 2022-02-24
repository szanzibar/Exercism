defmodule DNA do
  @nucleotide %{
    ?\s => 0b0,
    ?A => 0b1,
    ?C => 0b10,
    ?G => 0b100,
    ?T => 0b1000
  }

  def encode_nucleotide(code_point) do
    Map.fetch!(@nucleotide, code_point)
  end

  def decode_nucleotide(encoded_code) do
    {key, _val} =
      @nucleotide
      |> Enum.find(fn {_key, val} -> val == encoded_code end)

    key
  end

  def encode([head | []]) do
    <<encode_nucleotide(head)::4>>
  end

  def encode([head | tail]) do
    <<encode_nucleotide(head)::4, encode(tail)::bitstring>>
  end

  def decode(<<value::4>>) do
    [decode_nucleotide(value)]
  end

  def decode(<<value::4, rest::bitstring>>) do
    [decode_nucleotide(value) | decode(rest)]
  end
end
