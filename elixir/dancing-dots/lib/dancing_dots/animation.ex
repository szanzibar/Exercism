defmodule DancingDots.Animation do
  @type dot :: DancingDots.Dot.t()
  @type opts :: keyword
  @type error :: any
  @type frame_number :: pos_integer

  @callback init(opts) :: {:ok, opts} | {:error, error}
  @callback handle_frame(dot, frame_number, opts) :: dot

  defmacro __using__(_) do
    quote do
      @behaviour unquote(__MODULE__)
      def init(opts), do: {:ok, opts}
      defoverridable init: 1
    end
  end
end

defmodule DancingDots.Flicker do
  alias DancingDots.Animation
  use Animation

  @impl Animation

  def handle_frame(dot, frame_number, _opts) when rem(frame_number, 4) == 0 do
    %DancingDots.Dot{dot | opacity: dot.opacity / 2}
  end

  @impl Animation
  def handle_frame(dot, _frame_number, _opts), do: dot
end

defmodule DancingDots.Zoom do
  alias DancingDots.Animation
  use Animation

  @impl Animation
  def init(opts) do
    if is_number(opts[:velocity]) do
      {:ok, opts}
    else
      {:error,
       "The :velocity option is required, and its value must be a number. Got: #{inspect(opts[:velocity])}"}
    end
  end

  @impl Animation
  def handle_frame(dot, frame_number, velocity: velocity) do
    %DancingDots.Dot{dot | radius: dot.radius + (frame_number - 1) * velocity}
  end
end
