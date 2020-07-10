namespace RefactoringDemo8a
{
    public abstract class Price
    {
        public abstract double GetCharge(int daysRented);

        public virtual int GetFrequentRenterPoints(int daysRented) =>
            1;
    }
}
