using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using server.Dtos.Comment;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController(ICommentRepository commentRepo, IStockRepository stockRepo) : Controller
    {
        private readonly ICommentRepository _commentRepo = commentRepo;
        private readonly IStockRepository _stockRepo = stockRepo;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(comment => comment.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetAsync(id);
            if (comment == null) return NotFound();
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Create([FromRoute] int id, [FromBody] CommentDto commentDto)
        {
            if (!await _stockRepo.StockExists(id))
            {
                return BadRequest("Stock does not exist!");
            }

            var commentModel = await _commentRepo.CreateAsync(commentDto.ToCommentFromCommentDto(id));

            return CreatedAtAction(nameof(GetById), new { id = commentModel }, commentModel.ToCommentDto());
        }

    }
}