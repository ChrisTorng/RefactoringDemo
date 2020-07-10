namespace RefactoringDemo9
{
    public class ChildrensPrice : Price
    {
        public override double GetCharge(int daysRented) =>
            daysRented <= 3 ? 1.5 : (daysRented - 2) * 1.5;
    }
}
