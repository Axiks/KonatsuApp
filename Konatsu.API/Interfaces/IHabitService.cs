using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konatsu.API.Interfaces
{
    public interface IHabitService : IDisposable
    {
        void AddHabbit(String title, String description);
        HabitEntity GetHabbit(int id);
        HabitEntity FindHabbit(string title);
        void DeleteHabbit(int id);
        List<HabitEntity> AllHabits();
    }
}
