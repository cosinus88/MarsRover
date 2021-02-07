using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class CommandResult
    {
        public Position Position { get; set; }
        public string Error { get; set; }
        public CommandResult(Position position) => (Position) = (position);
        public CommandResult(string error) => (Error) = (error);
        public CommandResult(Position position, string error) => (Position, Error) = (position, error);

    }
}
