using System.Collections.ObjectModel;

namespace RefactoringDemo9
{
    public class StatementData
    {
        public StatementData(string name,
            ReadOnlyCollection<(string, double)> rentalData,
            double totalCharge,
            int totalFrequentRenterPoints)
        {
            this.Name = name;
            this.RentalData = rentalData;
            this.TotalCharge = totalCharge;
            this.TotalFrequentRenterPoints = totalFrequentRenterPoints;
        }

        public string Name { get; }

        public ReadOnlyCollection<(string, double)> RentalData { get; }

        public double TotalCharge { get; }

        public int TotalFrequentRenterPoints { get; }
    }
}
