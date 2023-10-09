defmodule PaintByNumber do
  def palette_bit_size(color_count, bits \\ 0, bit_size \\ 0)
  def palette_bit_size(color_count, bits, bit_size) when bit_size >= color_count, do: bits

  def palette_bit_size(color_count, bits, _) do
    palette_bit_size(color_count, bits + 1, Integer.pow(2, bits + 1))
  end

  def empty_picture(), do: <<>>

  def test_picture(), do: <<0::2, 1::2, 2::2, 3::2>>

  def prepend_pixel(picture, color_count, pixel_color_index) do
    bit_size = palette_bit_size(color_count)
    <<pixel_color_index::size(bit_size), picture::bitstring>>
  end

  def get_first_pixel(<<>>, _), do: nil

  def get_first_pixel(picture, color_count) do
    bit_size = palette_bit_size(color_count)
    <<pixel::size(bit_size), _::bitstring>> = picture
    pixel
  end

  def drop_first_pixel(<<>>, _), do: <<>>

  def drop_first_pixel(picture, color_count) do
    bit_size = palette_bit_size(color_count)
    <<_::size(bit_size), rest::bitstring>> = picture
    rest
  end

  def concat_pictures(picture1, picture2) do
    <<picture1::bitstring, picture2::bitstring>>
  end
end
