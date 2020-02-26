using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagkageHuset.DataModels
{
    public class Salg
    {
        public int Id { get; set; }
        public List<Vare> Varer { get; set; }
        public decimal Pris { get; set; }
        public DateTime Betalt { get; set; }

    }
}
