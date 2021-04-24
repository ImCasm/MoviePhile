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
            CreateMap<Community, CommunityDto>()
                .ForMember(communityDto => communityDto.Publications, opt => opt.MapFrom(community => community.Publications))
                .ForMember(communityDto => communityDto.Users, opt => opt.MapFrom(community => community.Users.Select(x => x.User)));

            CreateMap<Film, FilmDto>()
                .ForMember(filmDto => filmDto.Genre, opt => opt.MapFrom(film => film.Genre))
                .ForMember(filmDto => filmDto.Comments, opt => opt.MapFrom(film => film.Comments));

            CreateMap<Movie, MovieDto>()
                .ForMember(movieDto => movieDto.Genre, opt => opt.MapFrom(movie => movie.Genre))
                .ForMember(movieDto => movieDto.Comments, opt => opt.MapFrom(genre => genre.Comments))
                .IncludeBase<Film, FilmDto>();

            CreateMap<TvShow, TvShowDto>()
               .ForMember(tvShowDto => tvShowDto.Genre, opt => opt.MapFrom(tvShow => tvShow.Genre))
               .ForMember(movieDto => movieDto.Comments, opt => opt.MapFrom(tvShow => tvShow.Comments))
               .IncludeBase<Film, FilmDto>();

            CreateMap<FilmComment, FilmCommentDto>()
                .ForMember(filmCommentDto => filmCommentDto.User, opt => opt.MapFrom(filmComment => filmComment.User));

            CreateMap<Genre, GenreDto>();

            CreateMap<User, UserDto>();

            CreateMap<Publication, PublicationDto>()
                .ForMember(publicationDto => publicationDto.Comments, opt => opt.MapFrom(publication => publication.Comments))
                .ForMember(publicationDto => publicationDto.User, opt => opt.MapFrom(publication => publication.User));

            CreateMap<PublicationComment, PublicationCommentDto>()
                .ForMember(pubCommentDto => pubCommentDto.User, opt => opt.MapFrom(pubComment => pubComment.User));

        }
    }
}
