defmodule RPG.CharacterSheet do
  def welcome(), do: IO.puts("Welcome! Let's fill out your character sheet together.")

  def ask_name(), do: ask("What is your character's name?")

  def ask_class(), do: ask("What is your character's class?")

  def ask_level(), do: ask("What is your character's level?") |> String.to_integer()

  def run() do
    welcome()

    %{
      name: ask_name(),
      class: ask_class(),
      level: ask_level()
    }
    |> IO.inspect(label: "Your character")
  end

  defp ask(question), do: IO.gets("#{question}\n") |> String.trim()
end
