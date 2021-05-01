using Application.Common.Interfaces.Services;
using Application.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviePhile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            return Ok(_mapper.Map<ICollection<GenreDto>>(await _genreService.GetAllGenres()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            return Ok(_mapper.Map<GenreDto>(await _genreService.GetGenreById(id)));
        }

        [HttpGet("movies")]
        public async Task<IActionResult> GetAllMovieGenres()
        {
            return Ok(_mapper.Map<ICollection<GenreDto>>(await _genreService.GetAllMovieGenres()));
        }

        [HttpGet("series")]
        public async Task<IActionResult> GetAllSeriesGenres()
        {
            return Ok(_mapper.Map<ICollection<GenreDto>>(await _genreService.GetAllSeriesGenres()));
        }
    }
}
