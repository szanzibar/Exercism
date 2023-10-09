defmodule LogParser do
  @log_levels ["DEBUG", "INFO", "WARNING", "ERROR"]

  def valid_line?(line) do
    Regex.run(~r/^\[(\w*)\]/, line)
    |> case do
      [_, log_level | _] when log_level in @log_levels -> true
      _ -> false
    end
  end

  def split_line(line) do
    String.split(line, ~r/<[~|\*|=|-]*>/U)
  end

  def remove_artifacts(line) do
    Regex.replace(~r/end-of-line\d+/i, line, "")
  end

  def tag_with_user_name(line) do
    Regex.run(~r/User\s+(\S+)/, line)
    |> case do
      [_, user | _] -> "[USER] #{user} #{line}"
      _ -> line
    end
  end
end
