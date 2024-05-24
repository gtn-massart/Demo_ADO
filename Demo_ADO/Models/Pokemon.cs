using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ADO.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Height { get; set; }
        public int Weight { get; set; }
        public string? Description { get; set; }
        public int Type1Id { get; set; }
        public int? Type2Id { get; set; }
        public PokemonType? Type1 { get; set; }
        public PokemonType? Type2 { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}\nName : {Name}\n";
        }
    }

}
