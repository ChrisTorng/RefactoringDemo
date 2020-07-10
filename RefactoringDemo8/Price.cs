namespace RefactoringDemo8
{
    public abstract class Price
    {
        public abstract double GetCharge(int daysRented);

        public virtual int GetFrequentRenterPoints(int daysRented) =>
            1;
    }
}
