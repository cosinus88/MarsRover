using System;

namespace MarsRover.Models
{
    public class Position : IEquatable<Position>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public Position() { }
        public Position(int x, int y, Direction direction) => (X, Y, Direction) = (x, y, direction);
        public bool Equals(Position other)
        {
            return other.X == X && other.Y == Y && other.Direction == Direction;
        }
    }
}
