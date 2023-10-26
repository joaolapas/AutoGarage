using AutoGarage.Data;
using AutoGarage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AutoGarage.Controllers
{
    public class AutomoveisController : Controller
    {
        private readonly AutoGarageContext _context;

        public AutomoveisController(AutoGarageContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            var automoveis = _context.Automoveis.Include(a => a.Cliente).ToList();

           
            return View(automoveis);
        }


        ////////////////////////////////////////////////////////////////////////////////
        /////Adicionar

        [HttpGet]
        public IActionResult AdicionarRegisto(int? ClienteId)
        {
            
            
            var automovel = new AutomoveisModel
            {   
                ClienteId = ClienteId
            };

            return View(automovel);
        }

        [HttpPost]
        public IActionResult AdicionarRegisto(AutomoveisModel automovel)
        {
            if (ModelState.IsValid)
            {
                 
                _context.Automoveis.Add(automovel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        ////////////////////////////////////////////////////////////////
        /////////////////Editar

        [HttpGet]
        public IActionResult EditarRegisto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AutomoveisModel automovel = _context.Automoveis.FirstOrDefault(automovel => automovel.Id == id);

            if (automovel == null)
            {
                return NotFound();
            }

            return View(automovel);
        }
        [HttpPost]
        public IActionResult EditarRegisto(AutomoveisModel automovel)
        {
            if (ModelState.IsValid)
            {
                _context.Automoveis.Update(automovel);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(automovel);
        }
        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////Remover
        [HttpGet]
        public IActionResult EliminarRegisto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AutomoveisModel automovel = _context.Automoveis.FirstOrDefault(auto => auto.Id == id);

            if (automovel == null)
            {
                return NotFound();
            }

            return View(automovel);
        }
        [HttpPost]
        public IActionResult EliminarRegisto(AutomoveisModel automovel)
        {
            if (automovel == null)
            {
                return NotFound();
            }
            _context.Automoveis.Remove(automovel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //////////////////////////////////////////////////////////
        /////////////////////////Detalhes
        public IActionResult Detalhes(int id)
        {
            var automovel = _context.Automoveis
                .Include(c => c.Servicos)
                .Include(a => a.Cliente)
                .FirstOrDefault(c => c.Id == id);

            if (automovel == null)
            {
                return NotFound();
            }

            return View(automovel);
        }

    }
}
