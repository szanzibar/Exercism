defmodule NameBadge do
  def print(id, name, department) do
    id_prefix? = if id, do: "[#{id}] - ", else: ""
    department? = if department, do: String.upcase(department), else: "OWNER"

    "#{id_prefix?}#{name} - #{department?}"
  end
end
