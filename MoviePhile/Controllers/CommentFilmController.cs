using Application.Common.Interfaces.Services;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MoviePhile.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FilmCommentControllerBase : ControllerBase
    {

        private readonly IFilmCommentService _filmCommentService;
        private readonly IMapper _mapper;
        public FilmCommentControllerBase(IFilmCommentService filmComment, IMapper mapper)
        {
            _filmCommentService = filmComment;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CommentFilm")]
        public async Task<IActionResult> CommentFilm([FromBody] Domain.Entities.FilmComment comment)
        {
            return Ok(await _filmCommentService.SetComment(comment));
        }


        [HttpGet]
        [Route("AllCommentFilm")]
        public async Task<IActionResult> AllCommentFilm(int IdFilm)
        {
            var allFilmComment = await _filmCommentService.GetAllComment(IdFilm);
            //return Ok(_mapper.Map<IEnumerable<FilmCommentDto>>(allFilmComment));
            return Ok(allFilmComment);

        }



    }
}
