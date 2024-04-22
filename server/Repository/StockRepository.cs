using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Models;

namespace server.Repository
{
    public class StockRepository(ApplicationDataContext context) : IStockRepository
    {
        private readonly ApplicationDataContext _context = context;

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stock.ToListAsync();
        }

        public async Task<Stock> GetAsync(int id)
        {
            return await _context.Stock.FindAsync(id);
        }
    }
}