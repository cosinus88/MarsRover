using MarsRover.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRover.Controllers
{
    [Route("api/mission")]
    [ApiController]
    public class MissionController : ControllerBase
    {

        [HttpGet]
        [Route("setplateu")]
        public ActionResult<Plateau> SetPlateu([FromQuery] Size size)
        {
            if (ModelState.IsValid)
            {
                return MissionControl.SetPlateu(size);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("launchrover")]
        public ActionResult<Rover> LaunchRover([FromQuery] Position position)
        {
            if (position == null) return BadRequest("No position supplied");

            if (MissionControl._plateau == null) return BadRequest("There's no plateu, rover can not be deployed, find the plateu first!");

            if (MissionControl._plateau.Width < position.X + 1) ModelState.AddModelError(nameof(Position.X),"There's no such X coordinate on the plateu");

            if (MissionControl._plateau.Height < position.Y + 1) ModelState.AddModelError(nameof(Position.Y), "There's no such Y coordinate on the plateu");
            
            if (ModelState.IsValid)
            {
                return MissionControl.LaunchRover(position);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("move")]
        public ActionResult<Position> Move(Guid roverId, Command command)
        {
            var result = MissionControl.Move(roverId, command);
            if (!string.IsNullOrEmpty(result.Error))
            {
                return BadRequest(result.Error);
            }
            return result.Position;
        }
    }
}
