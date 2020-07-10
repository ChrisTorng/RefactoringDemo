using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefactoringDemo9
{
    public class Customer
    {
        private readonly List<Rental> rentals;

        static Customer()
        {
            StatementBuilder.BuildTemplate("TextStatement.cshtml").Wait();
            StatementBuilder.BuildTemplate("HtmlStatement.cshtml").Wait();
        }

        public Customer(string name)
        {
            this.Name = name;
            this.rentals = new List<Rental>();
            this.UpdateRentals();
        }

        public string Name { get; } // 姓名

        public IReadOnlyCollection<Rental> Rentals { get; private set; }

        public void AddRental(Rental rental)
        {
            this.rentals.Add(rental);
            this.UpdateRentals();
        }

        private void UpdateRentals()
        {
            this.Rentals = this.rentals.AsReadOnly();
        }

        private StatementData GetStatementData()
        {
            List<(string, double)> rentalData = new List<(string, double)>();
            foreach (Rental rental in this.Rentals)
            {
                // show figures for this rental (顯示此筆租借資料)
                rentalData.Add((rental.Movie.Title, rental.GetCharge()));
            }

            return new StatementData(
                this.Name,
                rentalData.AsReadOnly(),
                this.GetTotalCharge(),
                this.GetTotalFrequentRenterPoints());
        }

        public async Task<string> Statement()
        {
            StatementData data = this.GetStatementData();
            return await StatementBuilder.BuildResult("TextStatement.cshtml", data);
        }

        public async Task<string> HtmlStatement()
        {
            StatementData data = this.GetStatementData();
            return await StatementBuilder.BuildResult("HtmlStatement.cshtml", data);
        }

        private double GetTotalCharge() =>
            this.Rentals.Aggregate(0.0, (result, next) =>
                result += next.GetCharge());

        private int GetTotalFrequentRenterPoints() =>
            this.Rentals.Aggregate(0, (result, next) =>
                result += next.GetFrequentRenterPoints());
    }
}
