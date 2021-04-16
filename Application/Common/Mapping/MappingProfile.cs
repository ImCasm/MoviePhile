using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System.Linq;

namespace Domain.Common.Mapping
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Nos permite mapear los objetos del negocio (Entidades) a objetos de transferencia de datos(Dto) 
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Community, CommunityDTO>()
                .ForMember(communityDto => communityDto.Genres, opt => opt.MapFrom(community => community.Genres))
                .ForMember(communityDto => communityDto.Publications, opt => opt.MapFrom(community => community.Publications))
                .ForMember(communityDto => communityDto.Users, opt => opt.MapFrom(community => community.Users.Select(x => x.User)));

            CreateMap<Genre, GenreDTO>();

            CreateMap<User, UserDTO>();

            CreateMap<Publication, PublicationDTO>()
                .ForMember(publicationDto => publicationDto.Comments, opt => opt.MapFrom(publication => publication.Comments))
                .ForMember(publicationDto => publicationDto.User, opt => opt.MapFrom(publication => publication.User));

            CreateMap<PublicationComment, PublicationCommentDTO>()
                .ForMember(pubCommentDto => pubCommentDto.User, opt => opt.MapFrom(pubComment => pubComment.User));

        }
    }
}
