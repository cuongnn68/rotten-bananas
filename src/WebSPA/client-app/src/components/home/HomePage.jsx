import "./HomePage.css";
import React from "react";
import DetailMovieCard from "../common/DetailMovieCard.jsx";
import Space from "../common/Space.jsx";
import DetailMovieCards from "../common/DetailMovieCards";
import getMovies from "../../testData.js";

//@ts-check
export default function HomePage() {
    let movies = getMovies();
    return (
        // <div className="Home-page">
            <div className="Home-page" >
                <DetailMovieCards titleSection="New release" movies={movies} />
                <Space height="1.5cm" />
                <DetailMovieCards titleSection="Top rated movies" movies={movies} />
                <Space height="1.5cm" />
                <DetailMovieCards titleSection="Upcoming movies" movies={movies} />

    
    
                {/* <h1>Home page</h1>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat vel nunc in interdum. Fusce interdum, ipsum vitae fermentum commodo, metus mi commodo lacus, id blandit neque urna ac ligula. Morbi eu elit varius, eleifend augue porttitor, mattis mauris. Phasellus vitae mi nibh. Integer ornare ipsum ac dui ultricies aliquet et non turpis. Praesent ullamcorper ante sed augue condimentum varius. Nunc semper ante vel magna ullamcorper pretium. In consequat, dui quis vulputate auctor, sem sem fringilla ante, eget dictum ante purus sed erat. Nullam purus sem, molestie ac molestie nec, aliquam id justo. Proin pharetra odio nec semper condimentum. Maecenas scelerisque iaculis est, vitae fermentum lacus pharetra eget. Pellentesque ac ligula pellentesque, consectetur libero at, aliquam ligula.
    
                    Sed ac feugiat ligula, et ultricies ex. Praesent a libero eget tellus ultricies consequat. Phasellus ac gravida risus. Curabitur iaculis, sapien eleifend facilisis vehicula, orci ante egestas metus, sed elementum est ex vitae purus. Fusce cursus luctus neque eget elementum. Quisque eu ornare mi. Sed quam eros, euismod eu enim eu, condimentum laoreet orci. Vivamus maximus nunc vel diam scelerisque euismod. Nulla tempor mi vitae ante cursus blandit.
    
                    Duis mattis nulla a iaculis auctor. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Donec condimentum eget arcu eu consectetur. Cras quis est faucibus, feugiat dolor quis, blandit mauris. Pellentesque urna nunc, tincidunt vitae turpis vitae, rutrum blandit quam. Maecenas varius nunc eget tristique varius. Vivamus eleifend diam mauris. Sed et mattis tellus, non euismod libero. Curabitur id laoreet lorem. Etiam a orci finibus, elementum sem ut, dignissim augue. Donec euismod, neque in elementum efficitur, metus tellus iaculis leo, tempor elementum turpis lectus et leo. Morbi quis nisi cursus, malesuada tortor sed, mollis lorem.
    
                    Aenean elementum vehicula venenatis. Quisque ut luctus nisl. Fusce convallis lorem sapien, a vestibulum lacus varius nec. Maecenas aliquam leo vel porta maximus. Integer nec orci sit amet odio molestie blandit. Cras tempor, erat quis malesuada elementum, diam orci vulputate magna, in placerat mauris quam hendrerit magna. Donec maximus massa nunc. Phasellus id dapibus felis. Donec congue, tortor in consequat efficitur, massa tellus tristique leo, in mollis mi ante nec erat. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nam et viverra orci. Sed condimentum nunc id ligula cursus pretium. Praesent tincidunt mi id diam congue porta. Vestibulum diam nunc, facilisis at metus at, aliquam ullamcorper metus. Proin in sem mi.
    
                    Donec convallis cursus efficitur. Sed ac laoreet neque. Nunc dictum aliquet libero at porttitor. Duis quis porta sapien. Cras facilisis augue nec libero aliquam, aliquam efficitur est dictum. Nunc auctor non neque eu posuere. Duis mauris nunc, volutpat sit amet diam ut, congue convallis tortor.
    
                    Fusce interdum scelerisque erat at laoreet. Phasellus non risus vel ex tincidunt accumsan. Nullam elit diam, pellentesque non consectetur sed, efficitur at est. Nam arcu justo, condimentum et est non, maximus sollicitudin ante. Curabitur vitae sodales tellus. Donec libero enim, auctor ac lobortis in, gravida eu velit. Suspendisse potenti. Morbi condimentum, erat sit amet sagittis luctus, ex elit consectetur tortor, ac interdum elit orci eu nibh.
    
                    Integer ut scelerisque erat, ut efficitur nisl. Vestibulum eget turpis et leo venenatis feugiat. Sed pharetra mauris vitae dolor gravida, eu consequat nulla ultrices. Curabitur dapibus massa in turpis accumsan efficitur. Aliquam ultrices gravida felis, eu dictum arcu fringilla non. Fusce consequat libero laoreet, tempus dolor eu, tristique turpis. Nunc magna odio, luctus non ante sit amet, ultrices aliquam dolor. Etiam eget mauris vestibulum, viverra neque tincidunt, vulputate enim. Nulla facilisi. Maecenas ipsum elit, mollis eu tristique in, hendrerit ut est. Vestibulum pretium at leo id volutpat. Nullam vulputate mauris lacus, quis scelerisque nunc efficitur sit amet. Mauris consequat feugiat velit sed facilisis.
    
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce erat massa, iaculis nec cursus in, lobortis sed tellus. Curabitur dignissim consequat ex, eget pulvinar lorem porttitor sit amet. Suspendisse velit augue, semper a est at, consectetur blandit dolor. Cras cursus lectus suscipit bibendum fermentum. Duis finibus libero vehicula gravida dapibus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vivamus at nibh vitae mi suscipit laoreet at non libero. Donec in auctor lorem, quis lobortis dolor. Vivamus ullamcorper tincidunt metus consequat convallis.
    
                    Integer et pretium orci. Quisque ornare lectus nec arcu tincidunt, commodo vulputate ex euismod. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque tincidunt ipsum at neque porta volutpat. Nulla facilisi. Donec maximus sem nisi, quis egestas nibh eleifend ut. Phasellus erat tellus, laoreet sit amet suscipit et, dapibus eget odio. In ut ante facilisis nulla ultricies blandit interdum sit amet tellus. Sed luctus lacus in libero varius efficitur. Phasellus hendrerit nulla eget varius posuere. Etiam non massa a risus luctus euismod eu ac augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Pellentesque sagittis tortor vel augue dictum, eget aliquam felis tempus. Mauris lacinia sapien et nunc vestibulum, id ullamcorper justo cursus. Nulla facilisi.
    
                    Proin velit purus, semper vitae fermentum eu, pretium ut leo. Praesent a gravida orci. Nullam justo libero, pulvinar eget orci at, efficitur placerat ex. Maecenas luctus iaculis massa et feugiat. In hac habitasse platea dictumst. Morbi hendrerit vel elit sed fringilla. Praesent id orci non dui fringilla congue. Nulla in lorem sollicitudin, vehicula lectus sit amet, malesuada massa. Nullam mauris metus, semper vitae porta sed, tempus a lacus. Nulla egestas tincidunt interdum. Vestibulum eros arcu, porta bibendum vestibulum eu, fermentum mattis lacus. Nullam quis volutpat lorem. Maecenas id convallis ligula. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Vestibulum pretium varius luctus.</p> */}
            </div>
        // </div>
    );
};