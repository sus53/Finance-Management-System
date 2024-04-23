using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Comment;
using server.Interfaces;
using server.Models;

namespace server.Repository
{
    public class CommentRepository(ApplicationDataContext context) : ICommentRepository
    {
        private readonly ApplicationDataContext _context = context;
        public async Task<Comment> CreateAsync(Comment commentDto)
        {
            await _context.Comment.AddAsync(commentDto);
            await _context.SaveChangesAsync();
            return commentDto;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comment.FindAsync(id);
            if (commentModel == null) return null;
            _context.Comment.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetAsync(int id)
        {
            return await _context.Comment.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentRequestDto commentDto)
        {
            var existingModel = await _context.Comment.FindAsync(id);
            if (existingModel == null) return null;

            existingModel.Title = commentDto.Title;
            existingModel.Content = commentDto.Content;
            existingModel.CreatedOn = commentDto.CreatedOn;
            existingModel.StockId = commentDto.StockId;

            await _context.SaveChangesAsync();
            return existingModel;
        }
    }
}