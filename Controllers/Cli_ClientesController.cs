using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TecGas.Models;
using TEM.Models;

namespace TecGas.Controllers
{
    public class Cli_ClientesController : Controller
    {
        private readonly Context _context;

        public Cli_ClientesController(Context context)
        {
            _context = context;
        }

        // GET: Cli_Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cli_Clientes.ToListAsync());
        }

        // GET: Cli_Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cli_Clientes = await _context.Cli_Clientes
                .FirstOrDefaultAsync(m => m.CodigoClienteId == id);
            if (cli_Clientes == null)
            {
                return NotFound();
            }

            return View(cli_Clientes);
        }

        // GET: Cli_Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cli_Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoClienteId,Cli_Nome,Cli_CNPJ,Cli_Endereco,Cli_Telefone,Cli_Email")] Cli_Clientes cli_Clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cli_Clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cli_Clientes);
        }

        // GET: Cli_Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cli_Clientes = await _context.Cli_Clientes.FindAsync(id);
            if (cli_Clientes == null)
            {
                return NotFound();
            }
            return View(cli_Clientes);
        }

        // POST: Cli_Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoClienteId,Cli_Nome,Cli_CNPJ,Cli_Endereco,Cli_Telefone,Cli_Email")] Cli_Clientes cli_Clientes)
        {
            if (id != cli_Clientes.CodigoClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cli_Clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cli_ClientesExists(cli_Clientes.CodigoClienteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cli_Clientes);
        }

        // GET: Cli_Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cli_Clientes = await _context.Cli_Clientes
                .FirstOrDefaultAsync(m => m.CodigoClienteId == id);
            if (cli_Clientes == null)
            {
                return NotFound();
            }

            return View(cli_Clientes);
        }

        // POST: Cli_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cli_Clientes = await _context.Cli_Clientes.FindAsync(id);
            _context.Cli_Clientes.Remove(cli_Clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cli_ClientesExists(int id)
        {
            return _context.Cli_Clientes.Any(e => e.CodigoClienteId == id);
        }
    }
}
