using Demo_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ADO.Interfaces
{
    public interface IPokemonRepository
    {
        IEnumerable<Pokemon> GetAll(); // Collection en lecture seule (liste destinée à être parcourue)
        Pokemon? GetById(int id);
        int Count();
        int Create(Pokemon p);
        bool Update(int id, Pokemon p);
        bool Delete(int id);
    }
}
