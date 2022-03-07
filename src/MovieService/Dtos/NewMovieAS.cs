namespace MovieService.Dtos {
    public class NewMovieAS {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public int DurationByMin { get; set; }
        public bool Active { get; set; }
    }
}