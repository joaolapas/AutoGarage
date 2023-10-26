using AutoGarage.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoGarage.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoGarage.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AutoGarageContext _context;

        public ClientesController(AutoGarageContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // vai buscar os dados da tabela de clientes
            var clientes = _context.Clientes.ToList();

            // Passa os dados para a view
            return View(clientes);
        }

        ////////////////////////////////////////////
        /////Adicionar

        [HttpGet]
        public IActionResult AdicionarRegisto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarRegisto(ClientesModel cliente)
        {
            if(ModelState.IsValid){ 
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        ///////////////////////////////////////////////////////////////////
        /////////////////Editar
        
        [HttpGet]
        public IActionResult EditarRegisto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ClientesModel cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }
        [HttpPost]
        public IActionResult EditarRegisto(ClientesModel cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(cliente);
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
            ClientesModel cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }
        [HttpPost]
        public IActionResult EliminarRegisto(ClientesModel cliente)
        {
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //////////////////////////////////////////////////////////
        /////////////////////////Detalhes
        public IActionResult Detalhes(int id)
        {
            var cliente = _context.Clientes
                .Include(c => c.Automoveis) 
                .FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound(); 
            }

            return View(cliente);
        }

    }
}
