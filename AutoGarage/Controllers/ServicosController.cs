using AutoGarage.Data;
using AutoGarage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AutoGarage.Controllers
{
    public class ServicosController : Controller
    {
        private readonly AutoGarageContext _context;

        public ServicosController(AutoGarageContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // vai buscar os dados da tabela de automoveis
            var servicos = _context.Servicos.Include(a => a.Automovel).ToList();

            // Passa os dados para a view
            return View(servicos);
        }
        ////////////////////////////////////////////////////////////////////////////////
        /////Adicionar

        [HttpGet]
        public IActionResult AdicionarRegisto(int AutomovelId)
        {
           
            var servico = new ServicosModel
            {
                AutomovelId = AutomovelId,
            };

            return View(servico);
        }

        [HttpPost]
        public IActionResult AdicionarRegisto(ServicosModel servico)
        {
            if (ModelState.IsValid)
            {

                _context.Servicos.Add(servico);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //////////////////////////////////////////////////////////////////////////////////
        ////////////////////Editar

        [HttpGet]
        public IActionResult EditarRegisto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ServicosModel servico = _context.Servicos.FirstOrDefault(servico => servico.Id == id);

            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }
        [HttpPost]
        public IActionResult EditarRegisto(ServicosModel servico)
        {
            if (ModelState.IsValid)
            {
                _context.Servicos.Update(servico);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(servico);
        }
        ///////////////////////////////////////////////////////////////////
        //////////////////////////////////Remover
        [HttpGet]
        public IActionResult EliminarRegisto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ServicosModel servicos = _context.Servicos.FirstOrDefault(serv => serv.Id == id);

            if (servicos == null)
            {
                return NotFound();
            }

            return View(servicos);
        }
        [HttpPost]
        public IActionResult EliminarRegisto(ServicosModel servicos)
        {
            if (servicos == null)
            {
                return NotFound();
            }
            _context.Servicos.Remove(servicos);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
