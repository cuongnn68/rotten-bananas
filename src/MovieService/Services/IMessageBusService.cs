using MovieService.Dtos;

namespace MovieService.Services;

public interface IMessageBusService {
    public Task AddNewMovieAsync(NewMovieAS newMovie) ;
}