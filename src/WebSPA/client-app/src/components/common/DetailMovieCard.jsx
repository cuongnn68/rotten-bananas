import "./DetailMovieCard.css";

export default function DetailMovieCard() {
    let movies = [
        {
            id: 1,
            imageUrl: "https://random.imagecdn.app/225/320",
            title: "Lorem",
            dateRelease: "11/11/1111",
            duration: 120,
            plot: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. ",
        },
        {
            id: 2,
            imageUrl: "https://random.imagecdn.app/225/320",
            title: "Lorem",
            dateRelease: "11/11/1111",
            duration: 120,
            plot: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. ",
        },
        {
            id: 3,
            imageUrl: "https://random.imagecdn.app/225/320",
            title: "Lorem",
            dateRelease: "11/11/1111",
            duration: 120,
            plot: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. ",
        },
        {
            id: 4,
            imageUrl: "https://random.imagecdn.app/225/320",
            title: "Lorem",
            dateRelease: "11/11/1111",
            duration: 120,
            plot: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. ",
        },
    ]
    return (
        <div className="Card" onClick={() => {console.log("click movie")}}>
            <img className="Movie-image" src={movies[0].imageUrl} alt="Image not found" />
            <div className="Movie-info">
                <div>Title: {movies[0].title}</div>
                <div>Release on: {movies[0].dateRelease}</div>
                <div>Plot: {movies[0].plot} </div>
            </div>
        </div>
    );
}