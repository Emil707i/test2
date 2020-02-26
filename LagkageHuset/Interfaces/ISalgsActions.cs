using System;
using System.Collections.Generic;
using LagkageHuset.DataContainers;
using LagkageHuset.DataModels;

namespace LagkageHuset.Interfaces
{
    public interface ISalgsActions
    {
        List<Vare> HentVarer();
        decimal TotalPris(int[] varer);
        List<DateTime> VisTider(DateTime dato);
        void ReserverTid(DateTime tid);
        void Betal(Kurv kurv);
        void BookBoks(int id);
    }
}