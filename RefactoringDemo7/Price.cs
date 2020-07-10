namespace RefactoringDemo7
{
    public abstract class Price
    {
        public abstract double GetCharge(int daysRented);

        public virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}
