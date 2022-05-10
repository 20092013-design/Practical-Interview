using ConvertCurrencyApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertCurrencyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyContext _context;

        public CurrencyController(CurrencyContext context)
        {
            _context = context;
        }
        //GET: api/Currency
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> getAllCurrencies()
        {
            return await _context.Currencies.ToListAsync();
        }

        //GET: api/Currency/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> getCurrency(int id)
        {
            var Currency = await _context.Currencies.FindAsync(id);
            if (Currency == null)
            {
                return NotFound();
            }
            return Currency;
        }

        //PUT: api/Currency/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurrency(int id, Currency currency)
        {
            if (id != currency.CurrencyId)
            {
                return BadRequest();
            }
            _context.Entry(currency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }
        //POST:api/Currency
        [HttpPost]
        public async Task<ActionResult<Currency>> CreateCurrency( Currency currency)
        {

            _context.Currencies.Add(currency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrency", new { id = currency.CurrencyId }, currency);
        }


    }
}
