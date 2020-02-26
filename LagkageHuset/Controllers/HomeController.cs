using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LagkageHuset.BusinessControllers;
using LagkageHuset.DataContainers;
using LagkageHuset.DataModels;
using LagkageHuset.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;

namespace LagkageHuset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ISalgsActions _salgsController;

        public HomeController()
        {
            _salgsController = new SalgsController();
        }

        [Route("HentVarer")]
        [HttpGet]
        public IActionResult HentVarer()
        {
            var date = DateTime.Now.Date;
            var varer = _salgsController.HentVarer();
            return Ok(varer);
        }
        
        [Route("VisTider")]
        [HttpPost]
        public IActionResult VisTider([FromBody] DatoObject dato)
        { 
            return Ok(_salgsController.VisTider(DateTime.Parse(dato.Dato)));
        }

        [Route("VaelgTid")]
        [HttpPost]
        public IActionResult VaelgTid([FromBody] DatoObject dato)
        {
            _salgsController.ReserverTid(DateTime.Parse(dato.Dato));
            return Ok();
        }

        [Route("GaaTilKurv")]
        [HttpPost]
        public IActionResult GaaTilKurv([FromBody] VareListe varer)
        {
            var pris = _salgsController.TotalPris(varer.Varer);
            var salg = new Salg
            {
                Varer = _salgsController.HentVarer().Where(v => varer.Varer.Contains(v.Id)).ToList(),
                Pris = pris
            };

            return Ok(salg);
        }

        [Route("Betal")]
        [HttpPost]
        public IActionResult Betal([FromBody] VareListe varer)
        {
            _salgsController.Betal(new Kurv
            {
                Varer = _salgsController.HentVarer().Where(v => varer.Varer.Contains(v.Id)).ToList()
            });

            return Ok();
        }
    }

    public class DatoObject
    {
        public string Dato { get; set; }
    }

    public class VareListe
    {
        public int[] Varer { get; set; }
    }
}