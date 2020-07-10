using System.Collections.Generic;

namespace RefactoringDemo2
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
                double thisAmount = 0;

                thisAmount = AmountFor(each); // 計算一筆租片費用

                // add frequent renter points (累加 常客積點)
                frequentRenterPoints++;

                // add bonus for a two day new release rental
                if (each.Movie.PriceCode == Movie.NEWRELEASE &&
                    each.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }

                // show figures for this rental (顯示此筆租借資料)
                result += "\t" + each.Movie.Title + "\t" +
                    thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            // add footer lines (結尾列印)
            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() +
                " frequent renter points";
            return result;
        }

        // 計算一筆租片費用
        private static double AmountFor(Rental rental)
        {
            double result = 0;

#pragma warning disable IDE0010 // Add missing cases
            switch (rental.Movie.PriceCode)
#pragma warning restore IDE0010 // Add missing cases
            {
            case Movie.REGULAR: // 普通片
                result += 2;
                if (rental.DaysRented > 2)
                {
                    result += (rental.DaysRented - 2) * 1.5;
                }

                break;

            case Movie.NEWRELEASE: // 新片
                result += rental.DaysRented * 3;
                break;

            case Movie.CHILDRENS: // 兒童片
                result += 1.5;
                if (rental.DaysRented > 3)
                {
                    result += (rental.DaysRented - 3) * 1.5;
                }

                break;
            }

            return result;
        }
    }
}
