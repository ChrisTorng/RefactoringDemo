using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RazorLight;

namespace RefactoringDemo8a
{
    public class Customer
    {
        private readonly List<Rental> rentals;

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

        public StatementData GetStatementData()
        {
            List<(string, double)> rentalData = new List<(string, double)>();

            foreach (Rental rental in this.Rentals)
            {
                rentalData.Add((rental.Movie.Title, rental.GetCharge()));
            }

            return new StatementData(this.Name,
                rentalData,
                this.GetTotalCharge(),
                this.GetTotalFrequentRenterPoints());
        }

        public async Task<string> Statement()
        {
            var engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(Program))
                .UseMemoryCachingProvider()
                .Build();

            return await engine.CompileRenderStringAsync("templateKey",
                template.ToString(),
                this.GetStatementData());
        }

        public string HtmlStatement()
        {
            StringBuilder result = new StringBuilder();
            result.Append("<h1>Rental Record for <em>");
            result.Append(this.Name);
            result.AppendLine("</em></h1><p>");

            // 取得一筆租借記錄
            foreach (Rental each in this.Rentals)
            {
                // show figures for this rental (顯示此筆租借資料)
                result.AppendFormat("{0}: {1}<br>\r\n", each.Movie.Title, each.GetCharge());
            }

            // add footer lines (結尾列印)
            result.AppendLine($"<p>Amount owed is <em>{this.GetTotalCharge()}</em><p>");
            result.Append("You earned <em>");
            result.Append(this.GetTotalFrequentRenterPoints());
            result.Append("</em> frequent renter points");
            return result.ToString();
        }

        private double GetTotalCharge() =>
            this.Rentals.Aggregate(0.0, (result, next) =>
                result += next.GetCharge());

        private int GetTotalFrequentRenterPoints() =>
            this.Rentals.Aggregate(0, (result, next) =>
                result += next.GetFrequentRenterPoints());
    }
}
