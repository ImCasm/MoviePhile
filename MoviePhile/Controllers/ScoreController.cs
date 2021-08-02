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

        public ScoreController(IScoreService score)
        {
            _scoreService = score;
         
        }

        [HttpPost]
        public async Task<IActionResult> AddScore([FromBody] Domain.Entities.Score score)
        {
            return Ok(await _scoreService.setScore(score));

        }

    }
}
