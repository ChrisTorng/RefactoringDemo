using System;

namespace RefactoringDemo7
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEWRELEASE = 1;

        public Movie(string title, int priceCode)
        {
            this.Title = title;
            this.SetPriceCode(priceCode);
        }

        public string Title { get; } // 名稱

        private Price price;

        public void SetPriceCode(int priceCode)
        {
            this.price = priceCode switch
            {
                REGULAR => new RegularPrice(),
                CHILDRENS => new ChildrensPrice(),
                NEWRELEASE => new NewReleasePrice(),
                _ => throw new ArgumentOutOfRangeException(nameof(priceCode)),
            };
        }

        public double GetCharge(int daysRented)
        {
            return this.price.GetCharge(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return this.price.GetFrequentRenterPoints(daysRented);
        }
    }
}
