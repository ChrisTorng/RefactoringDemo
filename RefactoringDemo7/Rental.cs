namespace RefactoringDemo7
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

        public double GetCharge()
        {
            return this.Movie.GetCharge(this.DaysRented);
        }

        public int GetFrequentRenterPoints()
        {
            return this.Movie.GetFrequentRenterPoints(this.DaysRented);
        }
    }
}
