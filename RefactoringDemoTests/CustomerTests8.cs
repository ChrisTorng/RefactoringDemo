using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefactoringDemo8.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private static void StatementTest(Action<Customer> action, string expected)
        {
            Customer customer = new Customer("CustomerName");

            action(customer);
            string result = customer.Statement();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Statement_NoRental_Test()
        {
            string expected =
@"Rental Record for CustomerName
Amount owed is 0
You earned 0 frequent renter points";
            StatementTest(Program.NoRental, expected);
        }

        [TestMethod]
        public void Statement_OneRegular2Days_Test()
        {
            string expected =
$@"Rental Record for CustomerName
{'\t'}RegularMovie1{'\t'}2
Amount owed is 2
You earned 1 frequent renter points";
            StatementTest(Program.OneRegular2Days, expected);
        }

        [TestMethod]
        public void Statement_OneRegular3Days_Test()
        {
            string expected =
$@"Rental Record for CustomerName
{'\t'}RegularMovie2{'\t'}3.5
Amount owed is 3.5
You earned 1 frequent renter points";
            StatementTest(Program.OneRegular3Days, expected);
        }

        [TestMethod]
        public void Statement_OneNewRelease1Day_Test()
        {
            string expected =
$@"Rental Record for CustomerName
{'\t'}NewReleaseMovie1{'\t'}3
Amount owed is 3
You earned 1 frequent renter points";
            StatementTest(Program.OneNewRelease1Day, expected);
        }

        [TestMethod]
        public void Statement_OneNewRelease2Days_Test()
        {
            string expected =
$@"Rental Record for CustomerName
{'\t'}NewReleaseMovie2{'\t'}6
Amount owed is 6
You earned 2 frequent renter points";
            StatementTest(Program.OneNewRelease2Days, expected);
        }

        [TestMethod]
        public void Statement_OneChildren3Days_Test()
        {
            string expected =
$@"Rental Record for CustomerName
{'\t'}ChildrenMovie1{'\t'}1.5
Amount owed is 1.5
You earned 1 frequent renter points";
            StatementTest(Program.OneChildren3Days, expected);
        }

        [TestMethod]
        public void Statement_OneChildren4Days_Test()
        {
            string expected =
$@"Rental Record for CustomerName
{'\t'}ChildrenMovie2{'\t'}3
Amount owed is 3
You earned 1 frequent renter points";
            StatementTest(Program.OneChildren4Days, expected);
        }

        [TestMethod]
        public void Statement_AllMovies_Test()
        {
            string expected =
$@"Rental Record for CustomerName
{'\t'}RegularMovie1{'\t'}2
{'\t'}RegularMovie2{'\t'}3.5
{'\t'}NewReleaseMovie1{'\t'}3
{'\t'}NewReleaseMovie2{'\t'}6
{'\t'}ChildrenMovie1{'\t'}1.5
{'\t'}ChildrenMovie2{'\t'}3
Amount owed is 19
You earned 7 frequent renter points";
            StatementTest(Program.AllMovies, expected);
        }

        private static void HtmlStatementTest(Action<Customer> action, string expected)
        {
            Customer customer = new Customer("CustomerName");

            action(customer);
            string result = customer.HtmlStatement();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void HtmlStatement_NoRental_Test()
        {
            string expected =
@"<h1>Rental Record for <em>CustomerName</em></h1><p>
<p>Amount owed is <em>0</em><p>
You earned <em>0</em> frequent renter points";
            HtmlStatementTest(Program.NoRental, expected);
        }

        [TestMethod]
        public void HtmlStatement_OneRegular2Days_Test()
        {
            string expected =
@"<h1>Rental Record for <em>CustomerName</em></h1><p>
RegularMovie1: 2<br>
<p>Amount owed is <em>2</em><p>
You earned <em>1</em> frequent renter points";
            HtmlStatementTest(Program.OneRegular2Days, expected);
        }

        [TestMethod]
        public void HtmlStatement_OneRegular3Days_Test()
        {
            string expected =
@"<h1>Rental Record for <em>CustomerName</em></h1><p>
RegularMovie2: 3.5<br>
<p>Amount owed is <em>3.5</em><p>
You earned <em>1</em> frequent renter points";
            HtmlStatementTest(Program.OneRegular3Days, expected);
        }

        [TestMethod]
        public void HtmlStatement_OneNewRelease1Day_Test()
        {
            string expected =
@"<h1>Rental Record for <em>CustomerName</em></h1><p>
NewReleaseMovie1: 3<br>
<p>Amount owed is <em>3</em><p>
You earned <em>1</em> frequent renter points";
            HtmlStatementTest(Program.OneNewRelease1Day, expected);
        }

        [TestMethod]
        public void HtmlStatement_OneNewRelease2Days_Test()
        {
            string expected =
@"<h1>Rental Record for <em>CustomerName</em></h1><p>
NewReleaseMovie2: 6<br>
<p>Amount owed is <em>6</em><p>
You earned <em>2</em> frequent renter points";
            HtmlStatementTest(Program.OneNewRelease2Days, expected);
        }

        [TestMethod]
        public void HtmlStatement_OneChildren3Days_Test()
        {
            string expected =
@"<h1>Rental Record for <em>CustomerName</em></h1><p>
ChildrenMovie1: 1.5<br>
<p>Amount owed is <em>1.5</em><p>
You earned <em>1</em> frequent renter points";
            HtmlStatementTest(Program.OneChildren3Days, expected);
        }

        [TestMethod]
        public void HtmlStatement_OneChildren4Days_Test()
        {
            string expected =
@"<h1>Rental Record for <em>CustomerName</em></h1><p>
ChildrenMovie2: 3<br>
<p>Amount owed is <em>3</em><p>
You earned <em>1</em> frequent renter points";
            HtmlStatementTest(Program.OneChildren4Days, expected);
        }

        [TestMethod]
        public void HtmlStatement_AllMovies_Test()
        {
            string expected =
@"<h1>Rental Record for <em>CustomerName</em></h1><p>
RegularMovie1: 2<br>
RegularMovie2: 3.5<br>
NewReleaseMovie1: 3<br>
NewReleaseMovie2: 6<br>
ChildrenMovie1: 1.5<br>
ChildrenMovie2: 3<br>
<p>Amount owed is <em>19</em><p>
You earned <em>7</em> frequent renter points";
            HtmlStatementTest(Program.AllMovies, expected);
        }

        [ExcludeFromCodeCoverage]
        private static void InvalidMovie()
        {
            Movie.PriceCode invalidPriceCode = (Movie.PriceCode)(-1);
            _ = new Movie("InvalidMovie", invalidPriceCode);
        }

        [TestMethod]
        public void InvalidMovie_Test()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(InvalidMovie);
        }
    }
}
