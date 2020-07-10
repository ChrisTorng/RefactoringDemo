namespace RefactoringDemo7
{
    public class ChildrensPrice : Price
    {
        public override double GetCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
            {
                result += (daysRented - 3) * 1.5;
            }

            return result;
        }
    }
}
