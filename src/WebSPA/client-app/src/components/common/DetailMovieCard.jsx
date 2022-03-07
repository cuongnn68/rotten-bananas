import { useNavigate } from "react-router-dom";
import "./DetailMovieCard.css";

export default function DetailMovieCard(props) {
    let navigate = useNavigate();
    let movie = props.movie;
    return (
        <div className="Card" onClick={() => {console.log("to movieId: " + movie.id); navigate("/movie")}}>
            <img className="Movie-image" src={movie.imageUrl} alt="Image not found" />
            <div className="Movie-info">
                <div>Title: {movie.title}</div>
                <div>Release on: {movie.dateRelease}</div>
                <div>Plot: {movie.plot} </div>
            </div>
        </div>
    );
}