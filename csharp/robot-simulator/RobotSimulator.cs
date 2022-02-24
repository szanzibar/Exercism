using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    public Direction Direction { get; private set; }

    public int X { get; private set; }

    public int Y { get; private set; }

    public void Move(string instructions)
    {
        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case 'R':
                    RotateRight();
                    break;
                case 'L':
                    RotateLeft();
                    break;
                case 'A':
                    Advance();
                    break;
                default:
                    break;
            }
        }
    }

    private void RotateRight()
    {
        Direction = Direction switch
        {
            Direction.West => Direction.North,
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            _ => throw new Exception(),
        };
    }

    private void RotateLeft()
    {
        Direction = Direction switch
        {
            Direction.West => Direction.South,
            Direction.North => Direction.West,
            Direction.East => Direction.North,
            Direction.South => Direction.East,
            _ => throw new Exception(),
        };
    }

    private void Advance()
    {
        switch (Direction)
        {
            case Direction.North:
                Y++;
                break;
            case Direction.East:
                X++;
                break;
            case Direction.South:
                Y--;
                break;
            case Direction.West:
                X--;
                break;
            default:
                break;
        }
    }
}