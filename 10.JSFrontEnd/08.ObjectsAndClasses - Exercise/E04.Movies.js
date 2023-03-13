function getValidMoviesJson(moviesArray) {
  let movies = [];

  for (const entry of moviesArray) {
    const splitEntry = entry.split(" ");
    let movie = {};

    if (splitEntry.includes("addMovie")) {
      movie.name = getMovieName(splitEntry).trim();
      movies.push(movie);
    }

    if (splitEntry.includes("directedBy")) {
      const movieAndDirector = getMovieNameAndDirector(splitEntry);
      const movieName = movieAndDirector[0];
      const movieDirector = movieAndDirector[1];

      movie = getMovieByName(movies, movieName);
      if (movie == undefined) {
        continue;
      }

      movie.director = movieDirector;
    } else if (splitEntry.includes("onDate")) {
      const movieAndDate = getMovieNameAndDate(splitEntry);
      const movieName = movieAndDate[0];
      const movieDate = movieAndDate[1];

      movie = getMovieByName(movies, movieName);
      if (movie == undefined) {
        continue;
      }

      movie.date = movieDate;
    }
  }

  for (const movie of movies) {
    if (
      movie.name != undefined &&
      movie.director != undefined &&
      movie.date != undefined
    ) {
      console.log(JSON.stringify(movie));
    }
  }

  function getMovieName(splitEntryArray) {
    let name = "";

    for (const word of splitEntryArray) {
      if (word !== "addMovie") {
        name += `${word} `;
      }
    }

    return name;
  }

  function getMovieNameAndDirector(splitEntryArray) {
    let name = "";
    let director = "";
    let hasReachedDirector = false;

    for (const word of splitEntryArray) {
      if (hasReachedDirector) {
        director += `${word} `;
      } else if (!hasReachedDirector && word !== "directedBy") {
        name += `${word} `;
      }

      if (word === "directedBy") {
        hasReachedDirector = true;
      }
    }

    return [name.trim(), director.trim()];
  }

  function getMovieNameAndDate(splitEntryArray) {
    let name = "";
    let date = "";
    let hasReachedDate = false;

    for (const word of splitEntryArray) {
      if (hasReachedDate) {
        date = `${word}`;
      } else if (!hasReachedDate && word !== "onDate") {
        name += `${word} `;
      }

      if (word === "onDate") {
        hasReachedDate = true;
      }
    }

    return [name.trim(), date];
  }

  function getMovieByName(movieObjects, searchedName) {
    for (const movie of movieObjects) {
      if (movie.name === searchedName) {
        return movie;
      }
    }
  }
}

getValidMoviesJson([
  "addMovie Fast and Furious",
  "addMovie Godfather",
  "Inception directedBy Christopher Nolan",
  "Godfather directedBy Francis Ford Coppola",
  "Godfather onDate 29.07.2018",
  "Fast and Furious onDate 30.07.2018",
  "Batman onDate 01.08.2018",
  "Fast and Furious directedBy Rob Cohen",
]);
