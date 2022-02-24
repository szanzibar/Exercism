defmodule FreelancerRates do
  def daily_rate(hourly_rate), do: hourly_rate * 8 / 1

  def apply_discount(before_discount, discount) do
    before_discount - discount / 100 * before_discount
  end

  def monthly_rate(hourly_rate, discount) do
    (daily_rate(hourly_rate) * 22)
    |> apply_discount(discount)
    |> ceil()
  end

  def days_in_budget(budget, hourly_rate, discount) do
    daily = daily_rate(hourly_rate) |> apply_discount(discount)

    Float.floor(budget / daily, 1)
  end
end
