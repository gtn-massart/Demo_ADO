using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demo_ADO.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime? Created { get; set; }


        public override string ToString()
        {
            return $"Id : {Id}\nTitle : {Title}\nDescription : {Description}\n";
        }

    }
}
