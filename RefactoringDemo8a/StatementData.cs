using System.Collections.Generic;

namespace RefactoringDemo8a
{
    public class StatementData
    {
        public StatementData(string name,
            IReadOnlyCollection<(string, double)> rentalData,
            double totalCharge,
            int totalFrequentRenterPoints)
        {
            this.Name = name;
            this.RentalData = rentalData;
            this.TotalCharge = totalCharge;
            this.TotalFrequentRenterPoints = totalFrequentRenterPoints;
        }

        public string Name { get; }

        public IReadOnlyCollection<(string, double)> RentalData { get; }

        public double TotalCharge { get; }

        public int TotalFrequentRenterPoints { get; }
    }
}
