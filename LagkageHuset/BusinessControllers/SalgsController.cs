using System;
using System.Collections.Generic;
using System.Linq;
using BoksSystemInterface;
using LagkageHuset.DataContainers;
using LagkageHuset.DataModels;
using LagkageHuset.Interfaces;

namespace LagkageHuset.BusinessControllers
{
    public class SalgsController : ISalgsActions
    {
        private IBoksSystem _boksSystem;
        private BetalingsController _betalingsController;
        private Kurv _kurv;

        public SalgsController()
        {
            _boksSystem = new BoksSystem();
            _betalingsController = new BetalingsController();
        }

        public List<Vare> HentVarer()
        {
            return VareKatalog.HentVarer();
        }

        public decimal TotalPris(int[] varer)
        {
            return VareKatalog.HentVarer().Where(v => varer.Contains(v.Id)).Sum(v => v.Pris);
        }

        public List<DateTime> VisTider(DateTime dato)
        {
            var tider = _boksSystem.LedigeTider().FirstOrDefault(lt => lt.Key.Date == dato.Date).Value;
            
            if (!tider.Any())
                return new List<DateTime>();

            return tider;
        }

        public void ReserverTid(DateTime tid)
        {
            _boksSystem.ReserverTid(tid);
        }

        public void Betal(Kurv kurv)
        {
            _betalingsController.Betal(kurv);
        }

        public void BookBoks(int id)
        {
            _boksSystem.BookBoks(id);
        }
    }
}
