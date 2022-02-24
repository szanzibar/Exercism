defmodule FileSniffer do
  def type_from_extension(extension) do
    %{
      "exe" => "application/octet-stream",
      "bmp" => "image/bmp",
      "png" => "image/png",
      "jpg" => "image/jpg",
      "gif" => "image/gif"
    }[extension]
  end

  def type_from_binary(binary_file) do
    case binary_file do
      <<0x7F, 0x45, 0x4C, 0x46, _::binary>> -> "application/octet-stream"
      <<0x42, 0x4D, _::binary>> -> "image/bmp"
      <<0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, _::binary>> -> "image/png"
      <<0xFF, 0xD8, 0xFF, _::binary>> -> "image/jpg"
      <<0x47, 0x49, 0x46, _::binary>> -> "image/gif"
    end
  end

  def verify(file_binary, extension) do
    extension_type = type_from_extension(extension)

    case extension_type == type_from_binary(file_binary) do
      true -> {:ok, extension_type}
      _ -> {:error, "Warning, file format and file extension do not match."}
    end
  end
end
