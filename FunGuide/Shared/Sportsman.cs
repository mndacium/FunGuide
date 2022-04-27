using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunGuide.Shared
{
    public class Sportsman:BaseEntity
    {

        public string FirstName { get; set; }=String.Empty;
        public string LastName { get; set; }= String.Empty;
        public DateTime? BirthDate { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string? Сitizenship { get; set; }
        public Sport? Sport { get; set; }
        public int SportId { get; set; }
        public string? Team { get; set;}

    }
}
