using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class CommanderRepo : ICommanderRepo
    {
        private readonly AppDbContext _context;

        public CommanderRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(Command command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Remove(command);
        }

        public IEnumerable<Command> Index()
        {
            return _context.Commands.ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public Command Show(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public void Store(Command command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Add(command);
        }

        public void Update(Command command)
        {
        }
    }
}