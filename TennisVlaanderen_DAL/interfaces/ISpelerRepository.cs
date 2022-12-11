using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisVlaanderen_Models;

namespace TennisVlaanderen_DAL.interfaces
{
    public interface ISpelerRepository
    {
        IEnumerable<TennisVlaanderen_Models.Speler> OphalenSpeler();     
    }
}
