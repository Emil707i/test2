using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LagkageHuset.DataModels;

namespace LagkageHuset.DataContainers
{
    public class Kurv
    {
        public List<Vare> Varer { get; set; }

        public decimal TotalPris()
        {
            return Varer == null ? Varer.Sum(v => v.Pris) : 0;
        }
    }
}
