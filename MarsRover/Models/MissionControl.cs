using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Models
{
    public static class MissionControl
    {
        public static Plateau _plateau { get; set; }

        public static Plateau SetPlateu(Size size)
        {
            _plateau = new Plateau(size.Width, size.Height);
            return _plateau;
        }

        public static Rover LaunchRover(Position position)
        {

            if (_plateau == null) throw new Exception("There's no plateu, rover can not be deployed, find the plateu first!");

            if(_plateau.Width < position.X + 1) throw new Exception("There's no such X coordinate on the plateu");

            if (_plateau.Height < position.Y + 1) throw new Exception("There's no such Y coordinate on the plateu");

            var rover = new Rover(position.X, position.Y, position.Direction);

            _plateau.Rovers.Add(rover);

            return rover;
        }

        public static CommandResult Move(Guid roverId, Command command)
        {
            if (_plateau == null) throw new Exception("No Plateu found");


            var rover = _plateau.Rovers.FirstOrDefault(x => x.Id == roverId);

            if (rover == null) throw new Exception($"The rover with the given id {roverId} was not found");

            var suggestedMove = new Position(rover.X, rover.Y, rover.Direction);
            
            var directions = new Dictionary<Direction, int> { { Direction.N , 0}, { Direction.E, 1 }, { Direction.S, 2 }, { Direction.W, 3 } };

            switch (command)
            {
                case Command.L:
                    var current = directions[suggestedMove.Direction];
                    var next = current - 1;
                    if (next < 0) suggestedMove.Direction = directions.Last().Key;
                    else suggestedMove.Direction = directions.First(x => x.Value == next).Key;
                    break;
                case Command.R:
                    var currentR = directions[suggestedMove.Direction];
                    var nextR = currentR + 1;
                    if (nextR > 3) suggestedMove.Direction = directions.First().Key;
                    else suggestedMove.Direction = directions.First(x => x.Value == nextR).Key;
                    break;
                case Command.M:
                    switch (suggestedMove.Direction)
                    {
                        case Direction.N:
                            suggestedMove.Y += 1;
                            break;
                        case Direction.S:
                            suggestedMove.Y -= 1;
                            break;
                        case Direction.E:
                            suggestedMove.X += 1;
                            break;
                        case Direction.W:
                            suggestedMove.X -= 1;
                            break;
                        default:
                            throw new Exception("Unrecognized move");
                    }

                    if(suggestedMove.X < 0 || suggestedMove.X >= _plateau.Width)
                        return new CommandResult(new Position(rover.X, rover.Y, rover.Direction),"Wrong X coordinate, you can not move outside of the plateu");

                    if (suggestedMove.Y < 0 || suggestedMove.Y >= _plateau.Height)
                        return new CommandResult(new Position(rover.X, rover.Y, rover.Direction), "Wrong Y coordinate, you can not move outside of the plateu");

                    break;

            }

            rover.X = suggestedMove.X;
            rover.Y = suggestedMove.Y;
            rover.Direction = suggestedMove.Direction;

            return new CommandResult(suggestedMove);
        }
    }
    
}
