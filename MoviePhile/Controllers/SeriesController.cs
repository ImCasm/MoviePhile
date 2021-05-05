using Application.Common.Interfaces.Services;
using Application.Dto;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MoviePhile.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISerieService _seriesService;
        private readonly IMapper _mapper;

        public SeriesController(ISerieService seriesService, IMapper mapper)
        {
            _seriesService = seriesService;
            _mapper = mapper;
        }

        [HttpGet("popular")]
        public async Task<ActionResult> GetPopularSeries(int page = 1)
        {
            return Content(await _seriesService.GetPopularSeries(page), "application/json");
        }

        [HttpGet("search")]
        public async Task<ActionResult> GetSeriesByName(string query, int page = 1)
        {
            return Content(await _seriesService.GetSeriesByName(query, page), "application/json");
        }

        [HttpGet]
        public async Task<ActionResult> GetSerieId(int serieId)
        {
            return Ok(_mapper.Map<TvShowDto>(await _seriesService.GetSerieById(serieId)));
        }

        [HttpPost]
        public async Task<ActionResult> InsertSerie(TvShow serie)
        {
            return Ok(_mapper.Map<MovieDto>(await _seriesService.InsertSerie(serie)));
        }
    }
}
