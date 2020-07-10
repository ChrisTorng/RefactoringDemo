using System;

namespace RefactoringDemo9
{
    public class Movie
    {
        public enum PriceCode
        {
            Regular,
            NewRelease,
            Childrens,
        }

        public Movie(string title, PriceCode priceCode)
        {
            this.Title = title;
            this.SetPriceCode(priceCode);
        }

        public string Title { get; } // 名稱

        private Price price;

        private void SetPriceCode(PriceCode priceCode) =>
            this.price = priceCode switch
            {
                PriceCode.Regular => new RegularPrice(),
                PriceCode.NewRelease => new NewReleasePrice(),
                PriceCode.Childrens => new ChildrensPrice(),
                _ => throw new ArgumentOutOfRangeException(nameof(priceCode)),
            };

        public double GetCharge(int daysRented) =>
            this.price.GetCharge(daysRented);

        public int GetFrequentRenterPoints(int daysRented) =>
            this.price.GetFrequentRenterPoints(daysRented);
    }
}
