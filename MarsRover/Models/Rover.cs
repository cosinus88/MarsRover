using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class Rover
    {
        public Guid Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public string DirectionChar { get { return Direction.ToString();  } }
        public Rover(int x, int y, Direction direction)
        {
            Id = Guid.NewGuid();
            (X, Y, Direction) = (x, y, direction);
        }

        
    }
}
