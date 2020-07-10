using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringDemo8
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

        public string Statement()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Rental Record for {this.Name}");

            // 取得一筆租借記錄
            foreach (Rental rental in this.Rentals)
            {
                // show figures for this rental (顯示此筆租借資料)
                result.AppendLine($"\t{rental.Movie.Title}\t{rental.GetCharge()}");
            }

            // add footer lines (結尾列印)
            result.AppendLine($"Amount owed is {this.GetTotalCharge()}");
            result.Append($"You earned {this.GetTotalFrequentRenterPoints()} frequent renter points");
            return result.ToString();
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
