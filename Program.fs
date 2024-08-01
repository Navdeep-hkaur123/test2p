// For more information see https://aka.ms/fsharp-console-apps

type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport


type Director = {
    FullName: string
    TotalMovies: int
}


type Movie = {
    Title: string
    DurationInMinutes: int
    Category: Genre
    MovieDirector: Director
    IMDbScore: float
}


let movieList = [
    { Title = "CODA"; DurationInMinutes = 111; Category = Drama; MovieDirector = { FullName = "Sian Heder"; TotalMovies = 9 }; IMDbScore = 8.1 }
    { Title = "Belfast"; DurationInMinutes = 98; Category = Comedy; MovieDirector = { FullName = "Kenneth Branagh"; TotalMovies = 23 }; IMDbScore = 7.3 }
    { Title = "Don't Look Up"; DurationInMinutes = 138; Category = Comedy; MovieDirector = { FullName = "Adam McKay"; TotalMovies = 27 }; IMDbScore = 7.2 }
    { Title = "Drive My Car"; DurationInMinutes = 179; Category = Drama; MovieDirector = { FullName = "Rysuke Hamaguchi"; TotalMovies = 16 }; IMDbScore = 7.6 }
    { Title = "Dune"; DurationInMinutes = 155; Category = Fantasy; MovieDirector = { FullName = "Denis Villeneuve"; TotalMovies = 24 }; IMDbScore = 8.1 }
    { Title = "King Richard"; DurationInMinutes = 144; Category = Sport; MovieDirector = { FullName = "Reinaldo Marcus Green"; TotalMovies = 15 }; IMDbScore = 7.5 }
    { Title = "Licorice Pizza"; DurationInMinutes = 133; Category = Comedy; MovieDirector = { FullName = "Paul Thomas Anderson"; TotalMovies = 49 }; IMDbScore = 7.4 }
    { Title = "Nightmare Alley"; DurationInMinutes = 150; Category = Thriller; MovieDirector = { FullName = "Guillermo Del Toro"; TotalMovies = 22 }; IMDbScore = 7.1 }
]


let potentialOscarWinners = 
    movieList 
    |> List.filter (fun movie -> movie.IMDbScore > 7.4)


let formatRunLength minutes = 
    let hrs = minutes / 60
    let mins = minutes % 60
    sprintf "%dh %dmin" hrs mins

let formattedDurations = 
    movieList 
    |> List.map (fun movie -> formatRunLength movie.DurationInMinutes)


printfn "Potential Oscar-Winning Movies:"
potentialOscarWinners 
|> List.iter (fun movie -> printfn "%s - IMDb Score: %f" movie.Title movie.IMDbScore)

printfn "\nMovie Run Times in Hours and Minutes:"
List.zip movieList formattedDurations 
|> List.iter (fun (movie, formattedTime) -> printfn "%s - %s" movie.Title formattedTime)

