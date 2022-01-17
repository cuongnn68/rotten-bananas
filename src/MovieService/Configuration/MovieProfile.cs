using AutoMapper;
using MovieService.Dtos;
using MovieService.Models;
using MovieService.Util;

namespace MovieService.Configuration;

public class MovieProfile : Profile {
    public MovieProfile() {
        CreateMap<Movie, GetMovieRP>();
        CreateMap<NewMovieRQ, Movie>()
            .ForMember(
                dest => dest.ReleaseDate, 
                opt => opt.MapFrom(src => DateTime.ParseExact(src.ReleaseDate, Const.DATE_FORMAT, null)));
    }
}