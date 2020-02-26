using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagkageHuset.DataModels
{
    public class Vare
    {
        public int Id { get; set; }
        public VareBeskrivelse VareBeskrivelse { get; set; }
        public decimal Pris { get; set; }
    }
}
