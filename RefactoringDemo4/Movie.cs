namespace RefactoringDemo4
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
    }
}
