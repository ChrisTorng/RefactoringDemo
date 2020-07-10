namespace RefactoringDemo3
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
            double result = 0;

#pragma warning disable IDE0010 // Add missing cases
            switch (this.Movie.PriceCode)
#pragma warning restore IDE0010 // Add missing cases
            {
            case Movie.REGULAR: // 普通片
                result += 2;
                if (this.DaysRented > 2)
                {
                    result += (this.DaysRented - 2) * 1.5;
                }

                break;

            case Movie.NEWRELEASE: // 新片
                result += this.DaysRented * 3;
                break;

            case Movie.CHILDRENS: // 兒童片
                result += 1.5;
                if (this.DaysRented > 3)
                {
                    result += (this.DaysRented - 3) * 1.5;
                }

                break;
            }

            return result;
        }
    }
}
