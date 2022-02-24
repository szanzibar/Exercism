defmodule Username do
  def sanitize(username) do
    reducer = fn char, acc ->
      acc ++
        case char do
          ?ä -> 'ae'
          ?ö -> 'oe'
          ?ü -> 'ue'
          ?ß -> 'ss'
          ?_ -> '_'
          char when char in ?a..?z -> [char]
          _ -> ''
        end
    end

    Enum.reduce(username, '', reducer)
  end
end
