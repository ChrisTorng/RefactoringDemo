namespace RefactoringDemo8a
{
    public class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            this.Movie = movie;
            this.DaysRented = daysRented;
        }

        public Movie Movie { get; } // 影片

        public int DaysRented { get; } // 租期

        public double GetCharge() =>
            this.Movie.GetCharge(this.DaysRented);

        public int GetFrequentRenterPoints() =>
            this.Movie.GetFrequentRenterPoints(this.DaysRented);
    }
}
