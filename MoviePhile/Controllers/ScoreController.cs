using Application.Common.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePhile.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController: ControllerBase
    {
        private readonly IScoreService _scoreService;
        private readonly IMapper _mapper;
        public ScoreController(IScoreService score, IMapper mapper)
        {
            _scoreService = score;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddScore([FromBody] Domain.Entities.Score score)
        {
            return Ok(await _scoreService.setScore(score));

        }

    }
}
