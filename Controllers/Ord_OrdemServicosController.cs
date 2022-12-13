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
    public class Ord_OrdemServicosController : Controller
    {
        private readonly Context _context;

        public Ord_OrdemServicosController(Context context)
        {
            _context = context;
        }

        // GET: Ord_OrdemServicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ord_OrdemServicos.ToListAsync());
        }

        // GET: Ord_OrdemServicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ord_OrdemServicos = await _context.Ord_OrdemServicos
                .FirstOrDefaultAsync(m => m.Ord_OrdemId == id);
            if (ord_OrdemServicos == null)
            {
                return NotFound();
            }

            return View(ord_OrdemServicos);
        }

        // GET: Ord_OrdemServicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ord_OrdemServicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ord_OrdemId,Ord_NumeroOrdem,Ord_DataAbertura,CodigoClienteId,Ord_Modelo,Ord_Detalhes,Ord_Diagnostico,Ord_Solucao,Ord_PecasTrocadas,Ord_ValorServico,Ord_ValorPeca,Ord_ValorTotal")] Ord_OrdemServicos ord_OrdemServicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ord_OrdemServicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ord_OrdemServicos);
        }

        // GET: Ord_OrdemServicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ord_OrdemServicos = await _context.Ord_OrdemServicos.FindAsync(id);
            if (ord_OrdemServicos == null)
            {
                return NotFound();
            }
            return View(ord_OrdemServicos);
        }

        // POST: Ord_OrdemServicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ord_OrdemId,Ord_NumeroOrdem,Ord_DataAbertura,CodigoClienteId,Ord_Modelo,Ord_Detalhes,Ord_Diagnostico,Ord_Solucao,Ord_PecasTrocadas,Ord_ValorServico,Ord_ValorPeca,Ord_ValorTotal")] Ord_OrdemServicos ord_OrdemServicos)
        {
            if (id != ord_OrdemServicos.Ord_OrdemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ord_OrdemServicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Ord_OrdemServicosExists(ord_OrdemServicos.Ord_OrdemId))
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
            return View(ord_OrdemServicos);
        }

        // GET: Ord_OrdemServicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ord_OrdemServicos = await _context.Ord_OrdemServicos
                .FirstOrDefaultAsync(m => m.Ord_OrdemId == id);
            if (ord_OrdemServicos == null)
            {
                return NotFound();
            }

            return View(ord_OrdemServicos);
        }

        // POST: Ord_OrdemServicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ord_OrdemServicos = await _context.Ord_OrdemServicos.FindAsync(id);
            _context.Ord_OrdemServicos.Remove(ord_OrdemServicos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Ord_OrdemServicosExists(int id)
        {
            return _context.Ord_OrdemServicos.Any(e => e.Ord_OrdemId == id);
        }
    }
}
