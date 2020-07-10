using System.Collections.Generic;

namespace RefactoringDemo5
{
    public class Customer
    {
        public Customer(string name)
        {
            this.Name = name;
            this.Rentals = new List<Rental>();
        }

        public string Name { get; } // 姓名

        public List<Rental> Rentals { get; } // 租借記錄

        public void AddRental(Rental rental)
        {
            this.Rentals.Add(rental);
        }

        public string Statement()
        {
            string result = "Rental Record for " + this.Name + "\n";

            // 取得一筆租借記錄
            foreach (Rental each in this.Rentals)
            {
                // show figures for this rental (顯示此筆租借資料)
                result += "\t" + each.Movie.Title + "\t" +
                    each.GetCharge().ToString() + "\n";
            }

            // add footer lines (結尾列印)
            result += "Amount owed is " + this.GetTotalCharge().ToString() + "\n";
            result += "You earned " + this.GetTotalFrequentRenterPoints().ToString() +
                " frequent renter points";
            return result;
        }

        public string HtmlStatement()
        {
            string result = "<h1>Rental Record for <em>"
                + this.Name
                + "</em></h1><p>\n";

            // 取得一筆租借記錄
            foreach (Rental each in this.Rentals)
            {
                // show figures for this rental (顯示此筆租借資料)
                result += each.Movie.Title + ": " +
                    each.GetCharge().ToString() + "<br>\n";
            }

            // add footer lines (結尾列印)
            result += "<p>Amount owed is <em>"
                + this.GetTotalCharge().ToString()
                + "</em><p>\n";
            result += "You earned <em>"
                + this.GetTotalFrequentRenterPoints().ToString()
                + "</em> frequent renter points";
            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0;
            foreach (Rental each in this.Rentals)
            {
                result += each.GetCharge();
            }

            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            int result = 0; // 常客積點

            // 取得一筆租借記錄
            foreach (Rental each in this.Rentals)
            {
                result += each.GetFrequentRenterPoints();
            }

            return result;
        }
    }
}
