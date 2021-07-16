
using Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;


namespace MoviePhile.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {

        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;
        public PublicationController(IPublicationService publication, IMapper mapper)
        {
            _publicationService = publication;
            _mapper = mapper;
        }

        
        [HttpPost]
        public async Task<IActionResult> CommentFilm([FromBody] Domain.Entities.Publication publication)
        {
            return Ok(await _publicationService.SetPublication(publication));
        }

 
    }
}
