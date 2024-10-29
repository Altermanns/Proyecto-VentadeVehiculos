using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_VentadeVehiculos.Data;
using Proyecto_VentadeVehiculos.Models;

namespace Proyecto_VentadeVehiculos.Controllers
{
    public class TransaccionsController : Controller
    {
        private readonly Proyecto_VentadeVehiculosContext _context;

        public TransaccionsController(Proyecto_VentadeVehiculosContext context)
        {
            _context = context;
        }

        // GET: Transaccions
        public async Task<IActionResult> Index()
        {
            var proyecto_VentadeVehiculosContext = _context.Transaccion.Include(t => t.Comprador).Include(t => t.Vehiculo).Include(t => t.Vendedor);
            return View(await proyecto_VentadeVehiculosContext.ToListAsync());
        }

        // GET: Transaccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion = await _context.Transaccion
                .Include(t => t.Comprador)
                .Include(t => t.Vehiculo)
                .Include(t => t.Vendedor)
                .FirstOrDefaultAsync(m => m.IdTransaccion == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }

        // GET: Transaccions/Create
        public IActionResult Create()
        {
            ViewData["IdComprador"] = new SelectList(_context.Comprador, "IdComprador", "Nombre");
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Marca");
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Nombre");
            return View();
        }

        // POST: Transaccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaccion,IdVendedor,IdComprador,IdVehiculo,FechaTransaccion,PrecioFinal")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdComprador"] = new SelectList(_context.Comprador, "IdComprador", "Nombre", transaccion.IdComprador);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Marca", transaccion.IdVehiculo);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Nombre", transaccion.IdVendedor);
            return View(transaccion);
        }

        // GET: Transaccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion = await _context.Transaccion.FindAsync(id);
            if (transaccion == null)
            {
                return NotFound();
            }
            ViewData["IdComprador"] = new SelectList(_context.Comprador, "IdComprador", "Nombre", transaccion.IdComprador);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Marca", transaccion.IdVehiculo);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Nombre", transaccion.IdVendedor);
            return View(transaccion);
        }

        // POST: Transaccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransaccion,IdVendedor,IdComprador,IdVehiculo,FechaTransaccion,PrecioFinal")] Transaccion transaccion)
        {
            if (id != transaccion.IdTransaccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaccionExists(transaccion.IdTransaccion))
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
            ViewData["IdComprador"] = new SelectList(_context.Comprador, "IdComprador", "Nombre", transaccion.IdComprador);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculo, "IdVehiculo", "Marca", transaccion.IdVehiculo);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedor, "IdVendedor", "Nombre", transaccion.IdVendedor);
            return View(transaccion);
        }

        // GET: Transaccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion = await _context.Transaccion
                .Include(t => t.Comprador)
                .Include(t => t.Vehiculo)
                .Include(t => t.Vendedor)
                .FirstOrDefaultAsync(m => m.IdTransaccion == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }

        // POST: Transaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaccion = await _context.Transaccion.FindAsync(id);
            if (transaccion != null)
            {
                _context.Transaccion.Remove(transaccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaccionExists(int id)
        {
            return _context.Transaccion.Any(e => e.IdTransaccion == id);
        }
    }
}
