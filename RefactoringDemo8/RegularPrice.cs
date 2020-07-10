namespace RefactoringDemo8
{
    public class RegularPrice : Price
    {
        public override double GetCharge(int daysRented) =>
            daysRented <= 2 ? 2 : 2 + ((daysRented - 2) * 1.5);
    }
}
