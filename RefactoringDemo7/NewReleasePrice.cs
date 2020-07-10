namespace RefactoringDemo7
{
    public class NewReleasePrice : Price
    {
        public override double GetCharge(int daysRented)
        {
            return daysRented * 3;
        }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            // add bonus for a two day new release rental
            return daysRented > 1 ? 2 : 1;
        }
    }
}
