
import DetailMovieCard from "./DetailMovieCard";
import Space from "./Space";

/**
 * 
 * @param {{titleSection: string, movies: []}} props 
 * @returns 
 */
export default function DetailMovieCards(props) {
    let movies = props.movies;
    let title = props.titleSection;
    return (
        <div className="List-card">
            <div className="Title-section" >
                {title}
            </div>
            {
                movies.reduce(
                    (component, movie) => {
                        component.push(
                            <Space key={"space_" + movie.id} height="0.5cm" />,
                            <DetailMovieCard key={movie.id} movie={movie} />
                        );
                        return component;
                    },
                    []
                )
            }
        </div>
    )
}