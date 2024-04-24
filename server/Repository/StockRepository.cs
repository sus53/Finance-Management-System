using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Stock;
using server.Interfaces;
using server.Models;

namespace server.Repository
{
    public class StockRepository(ApplicationDataContext context) : IStockRepository
    {
        private readonly ApplicationDataContext _context = context;

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stock.FindAsync(id);
            if (stockModel == null) return null;

            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stock.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Stock?> GetAsync(int id)
        {
            return await _context.Stock.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stock.AnyAsync(stock => stock.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingModel = await _context.Stock.FindAsync(id);

            if (existingModel == null) return null;

            existingModel.CompanyName = stockDto.CompanyName;
            existingModel.Purchase = stockDto.Purchase;
            existingModel.LastDiv = stockDto.LastDiv;
            existingModel.Industry = stockDto.Industry;
            existingModel.MarketCap = stockDto.MarketCap;
            existingModel.Symbol = stockDto.Symbol;

            await _context.SaveChangesAsync();
            return existingModel;
        }
    }
}