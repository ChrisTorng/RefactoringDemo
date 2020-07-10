using System.Collections.Generic;

namespace RefactoringDemo4
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
            double totalAmount = 0; // 總消費金額
            int frequentRenterPoints = 0; // 常客積點
            string result = "Rental Record for " + this.Name + "\n";

            // 取得一筆租借記錄
            foreach (Rental each in this.Rentals)
            {
                frequentRenterPoints += each.GetFrequentRenterPoints();

                // show figures for this rental (顯示此筆租借資料)
                result += "\t" + each.Movie.Title + "\t" +
                    each.GetCharge().ToString() + "\n";
                totalAmount += each.GetCharge();
            }

            // add footer lines (結尾列印)
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() +
                " frequent renter points";
            return result;
        }
    }
}
