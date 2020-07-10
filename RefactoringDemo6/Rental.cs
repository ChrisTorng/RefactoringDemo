namespace RefactoringDemo6
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

#pragma warning disable CA1024 // Use properties where appropriate
        public double GetCharge()
#pragma warning restore CA1024 // Use properties where appropriate
        {
            return this.Movie.GetCharge(this.DaysRented);
        }

#pragma warning disable CA1024 // Use properties where appropriate
        public int GetFrequentRenterPoints()
#pragma warning restore CA1024 // Use properties where appropriate
        {
            return this.Movie.GetFrequentRenterPoints(this.DaysRented);
        }
    }
}
