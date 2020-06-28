using System.Collections.Generic;
using System.Linq;
using CmdApi.Data;
using CmdApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CmdApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommandController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> Index()
        {
            return _context.Commands.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Command> Show(int id)
        {
            var command = _context.Commands.SingleOrDefault(c => c.Id == id);

            if (command is null)
            {
                return NotFound();
            }

            return command;
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Command> Store(Command command)
        {
            _context.Commands.Add(command);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Show), new { id = command.Id }, command);
        }

        [HttpDelete("{id}")]
        public ActionResult<Command> Delete(int id)
        {
            var command = _context.Commands.SingleOrDefault(c => c.Id == id);

            if (command is null)
            {
                return NotFound();
            }

            _context.Commands.Remove(command);
            _context.SaveChanges();

            return command;
        }
    }
}