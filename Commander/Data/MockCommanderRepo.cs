using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void Delete(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> Index()
        {
            return new List<Command> {
                new Command { Id = 1, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
                new Command { Id = 2, HowTo = "Cook rice", Line = "Boil water and get some rice", Platform = "Rice" }
            };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Command Show(int id)
        {
            return new Command { Id = 1, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
        }

        public void Store(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}