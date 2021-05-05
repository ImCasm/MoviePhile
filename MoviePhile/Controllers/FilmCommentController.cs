using Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;

namespace MoviePhile.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FilmCommentController : ControllerBase
    {

        private readonly IFilmCommentService _filmCommentService;
        private readonly IMapper _mapper;
        public FilmCommentController(IFilmCommentService filmComment, IMapper mapper)
        {
            _filmCommentService = filmComment;
            _mapper = mapper;
        }
        
        [HttpPost]
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
