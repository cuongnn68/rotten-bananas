using AutoMapper;
using MovieService.Util;
using RatingService.Dtos;
using RatingService.Models;

namespace RatingService.Configuration;

public class RatingProfile : Profile {
    public RatingProfile() {
        CreateMap<Rating, RatingRP>()
            .ForMember(
                ratingRP => ratingRP.Username,
                option => option.MapFrom(rating => rating.User.Username))
            .ForMember(
                ratingRP => ratingRP.MovieName,
                option => option.MapFrom(rating => rating.Movie.Name))
            .ForMember(
                ratingRp => ratingRp.Time,
                option => option.MapFrom(rating => rating.Time.ToString(Const.DATE_TIME_FORMAT))
            );
        CreateMap<Rating, MovieRatingRP>()
            .ForMember(
                ratingRP => ratingRP.Username,
                option => option.MapFrom(rating => rating.User.Username)
            );
        CreateMap<NewRatingRQ, Rating>()
            .ForMember(
                rating => rating.Time,
                option => option.MapFrom(newRating => DateTime.ParseExact(newRating.Time, Const.DATE_TIME_FORMAT, null))
            );
        CreateMap<NewMovieAS, Movie>();
    }
}