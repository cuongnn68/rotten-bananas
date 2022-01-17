namespace RatingService.Dtos {
    public class MovieRatingRP {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Time { get; set; }
        public string Review { get; set; }

        public int UserId { get; set; }
        public string Username { get; set; }
    }
}