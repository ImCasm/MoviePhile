using Application.Common.Interfaces.Services;
using Application.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePhile.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FilmCommentControllerBase : ControllerBase
    {

        private readonly IFilmCommentService _filmCommentService;
        public FilmCommentControllerBase(IFilmCommentService filmComment)
        {
            _filmCommentService = filmComment;
        }

        [HttpPost]
        [Route("CommentFilm")]
        public async Task<IActionResult> CommentFilm([FromBody] Domain.Entities.FilmComment comment)
        {
            return Ok(await _filmCommentService.SetComment(comment));
        }
            


    }
}
