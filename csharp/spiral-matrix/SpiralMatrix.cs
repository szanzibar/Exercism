using System;

public class SpiralMatrix
{
    enum Direction
    {
        RIGHT, DOWN, LEFT, UP
    }
    public static int[,] GetMatrix(int size)
    {
        var matrix = new int[size, size];
        int y = 0, x = 0;
        var direction = Direction.RIGHT;

        for (var i = 1; i <= size * size; i++)
        {
            matrix[y, x] = i;
            switch (direction)
            {
                case Direction.RIGHT:
                    if (x + 1 >= size || matrix[y, x + 1] > 0) { direction = Direction.DOWN; y++; }
                    else x++;
                    break;
                case Direction.DOWN:
                    if (y + 1 >= size || matrix[y + 1, x] > 0) { direction = Direction.LEFT; x--; }
                    else y++;
                    break;
                case Direction.LEFT:
                    if (x - 1 < 0 || matrix[y, x - 1] > 0) { direction = Direction.UP; y--; }
                    else x--;
                    break;
                case Direction.UP:
                    if (y - 1 < 0 || matrix[y - 1, x] > 0) { direction = Direction.RIGHT; x++; }
                    else y--;
                    break;
                default:
                    break;
            }
        }

        return matrix;
    }
}
