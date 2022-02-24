defmodule LibraryFees do
  @spec datetime_from_string(binary) :: NaiveDateTime.t()
  def datetime_from_string(string), do: NaiveDateTime.from_iso8601!(string)

  @spec before_noon?(NaiveDateTime.t()) :: boolean
  def before_noon?(datetime), do: datetime.hour < 12

  @spec return_date(NaiveDateTime.t()) :: Date.t()
  def return_date(checkout_datetime) do
    date =
      checkout_datetime
      |> NaiveDateTime.to_date()

    if before_noon?(checkout_datetime),
      do: Date.add(date, 28),
      else: Date.add(date, 29)
  end

  @spec days_late(Date.t(), NaiveDateTime.t()) :: integer
  def days_late(planned_return_date, actual_return_datetime) do
    diff = Date.diff(actual_return_datetime, planned_return_date)
    if diff > 0, do: diff, else: 0
  end

  @spec monday?(NaiveDateTime.t()) :: boolean
  def monday?(datetime), do: NaiveDateTime.to_date(datetime) |> Date.day_of_week() == 1

  @spec calculate_late_fee(binary, binary, number) :: number
  def calculate_late_fee(checkout, return, rate) do
    checkout = datetime_from_string(checkout)
    return = datetime_from_string(return)
    late_fee = days_late(return_date(checkout), return) * rate

    if monday?(return), do: trunc(late_fee / 2), else: late_fee
  end
end
