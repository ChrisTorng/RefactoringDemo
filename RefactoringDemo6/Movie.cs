namespace RefactoringDemo6
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEWRELEASE = 1;

        public Movie(string title, int priceCode)
        {
            this.Title = title;
            this.PriceCode = priceCode;
        }

        public string Title { get; } // 名稱

        public int PriceCode { get; set; } // 價格 (代號)

#pragma warning disable CA1024 // Use properties where appropriate
        public double GetCharge(int daysRented)
#pragma warning restore CA1024 // Use properties where appropriate
        {
            double result = 0;

#pragma warning disable IDE0010 // Add missing cases
            switch (this.PriceCode)
#pragma warning restore IDE0010 // Add missing cases
            {
            case REGULAR: // 普通片
                result += 2;
                if (daysRented > 2)
                {
                    result += (daysRented - 2) * 1.5;
                }

                break;

            case NEWRELEASE: // 新片
                result += daysRented * 3;
                break;

            case CHILDRENS: // 兒童片
                result += 1.5;
                if (daysRented > 3)
                {
                    result += (daysRented - 3) * 1.5;
                }

                break;
            }

            return result;
        }

        public int GetFrequentRenterPoints(int daysRented)
#pragma warning restore CA1024 // Use properties where appropriate
        {
            // add bonus for a two day new release rental
            if (this.PriceCode == NEWRELEASE &&
                daysRented > 1)
            {
                return 2;
            }

            return 1;
        }
    }
}
