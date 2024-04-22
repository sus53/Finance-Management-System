using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Stock;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController(ApplicationDataContext context, IStockRepository stockRepo) : ControllerBase
    {
        private readonly ApplicationDataContext _context = context;
        private readonly IStockRepository _stockRepo = stockRepo;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepo.GetAllAsync();
            var stockDto = stocks.Select(s => s.ToStockDto());
            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _context.Stock.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDto updateStockDto)
        {
            var stockDto = await _context.Stock.FindAsync(id);

            if (stockDto == null)
            {
                return NotFound();
            }

            stockDto.CompanyName = updateStockDto.CompanyName;
            stockDto.Purchase = updateStockDto.Purchase;
            stockDto.LastDiv = updateStockDto.LastDiv;
            stockDto.Industry = updateStockDto.Industry;
            stockDto.MarketCap = updateStockDto.MarketCap;
            stockDto.Symbol = updateStockDto.Symbol;

            await _context.SaveChangesAsync();
            return Ok(stockDto);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _context.Stock.FindAsync(id);

            if (stockModel == null)
            {
                return NotFound();
            }

            _context.Stock.Remove(stockModel);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}