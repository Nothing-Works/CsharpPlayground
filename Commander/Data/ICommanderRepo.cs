using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> Index();
        Command Show(int id);
        void Store(Command command);
        void Update(Command command);
        void Delete(Command command);
    }
}