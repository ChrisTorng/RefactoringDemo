////using System;
////using System.Diagnostics.CodeAnalysis;
////using System.Threading.Tasks;
////using Microsoft.VisualStudio.TestTools.UnitTesting;

////namespace RefactoringDemo9.Tests
////{
////    [TestClass]
////    public class CustomerTests
////    {
////        private static async Task StatementTest(Action<Customer> action, string expected)
////        {
////            Customer customer = new Customer("CustomerName");

////            action(customer);
////            string result = await customer.Statement();

////            Assert.AreEqual(expected, result);
////        }

////        [TestMethod]
////        public async Task Statement_NoRental_Test()
////        {
////            string expected =
////@"Rental Record for CustomerName
////Amount owed is 0
////You earned 0 frequent renter points";
////            await StatementTest(Program.NoRental, expected);
////        }

////        [TestMethod]
////        public async Task Statement_OneRegular2Days_Test()
////        {
////            string expected =
////$@"Rental Record for CustomerName
////{'\t'}RegularMovie1{'\t'}2
////Amount owed is 2
////You earned 1 frequent renter points";
////            await StatementTest(Program.OneRegular2Days, expected);
////        }

////        [TestMethod]
////        public async Task Statement_OneRegular3Days_Test()
////        {
////            string expected =
////$@"Rental Record for CustomerName
////{'\t'}RegularMovie2{'\t'}3.5
////Amount owed is 3.5
////You earned 1 frequent renter points";
////            await StatementTest(Program.OneRegular3Days, expected);
////        }

////        [TestMethod]
////        public async Task Statement_OneNewRelease1Day_Test()
////        {
////            string expected =
////$@"Rental Record for CustomerName
////{'\t'}NewReleaseMovie1{'\t'}3
////Amount owed is 3
////You earned 1 frequent renter points";
////            await StatementTest(Program.OneNewRelease1Day, expected);
////        }

////        [TestMethod]
////        public async Task Statement_OneNewRelease2Days_Test()
////        {
////            string expected =
////$@"Rental Record for CustomerName
////{'\t'}NewReleaseMovie2{'\t'}6
////Amount owed is 6
////You earned 2 frequent renter points";
////            await StatementTest(Program.OneNewRelease2Days, expected);
////        }

////        [TestMethod]
////        public async Task Statement_OneChildren3Days_Test()
////        {
////            string expected =
////$@"Rental Record for CustomerName
////{'\t'}ChildrenMovie1{'\t'}1.5
////Amount owed is 1.5
////You earned 1 frequent renter points";
////            await StatementTest(Program.OneChildren3Days, expected);
////        }

////        [TestMethod]
////        public async Task Statement_OneChildren4Days_Test()
////        {
////            string expected =
////$@"Rental Record for CustomerName
////{'\t'}ChildrenMovie2{'\t'}3
////Amount owed is 3
////You earned 1 frequent renter points";
////            await StatementTest(Program.OneChildren4Days, expected);
////        }

////        [TestMethod]
////        public async Task Statement_AllMovies_Test()
////        {
////            string expected =
////$@"Rental Record for CustomerName
////{'\t'}RegularMovie1{'\t'}2
////{'\t'}RegularMovie2{'\t'}3.5
////{'\t'}NewReleaseMovie1{'\t'}3
////{'\t'}NewReleaseMovie2{'\t'}6
////{'\t'}ChildrenMovie1{'\t'}1.5
////{'\t'}ChildrenMovie2{'\t'}3
////Amount owed is 19
////You earned 7 frequent renter points";
////            await StatementTest(Program.AllMovies, expected);
////        }

////        private static async Task HtmlStatementTest(Action<Customer> action, string expected)
////        {
////            Customer customer = new Customer("CustomerName");

////            action(customer);
////            string result = await customer.HtmlStatement();

////            Assert.AreEqual(expected, result);
////        }

////        [TestMethod]
////        public async Task HtmlStatement_NoRental_Test()
////        {
////            string expected =
////$@"<h1>Rental Record for <em>CustomerName</em></h1><p>
////<p>Amount owed is <em>0</em><p>
////You earned <em>0</em> frequent renter points";
////            await HtmlStatementTest(Program.NoRental, expected);
////        }

////        [TestMethod]
////        public async Task HtmlStatement_OneRegular2Days_Test()
////        {
////            string expected =
////$@"<h1>Rental Record for <em>CustomerName</em></h1><p>
////RegularMovie1: 2<br>
////<p>Amount owed is <em>2</em><p>
////You earned <em>1</em> frequent renter points";
////            await HtmlStatementTest(Program.OneRegular2Days, expected);
////        }

////        [TestMethod]
////        public async Task HtmlStatement_OneRegular3Days_Test()
////        {
////            string expected =
////$@"<h1>Rental Record for <em>CustomerName</em></h1><p>
////RegularMovie2: 3.5<br>
////<p>Amount owed is <em>3.5</em><p>
////You earned <em>1</em> frequent renter points";
////            await HtmlStatementTest(Program.OneRegular3Days, expected);
////        }

////        [TestMethod]
////        public async Task HtmlStatement_OneNewRelease1Day_Test()
////        {
////            string expected =
////$@"<h1>Rental Record for <em>CustomerName</em></h1><p>
////NewReleaseMovie1: 3<br>
////<p>Amount owed is <em>3</em><p>
////You earned <em>1</em> frequent renter points";
////            await HtmlStatementTest(Program.OneNewRelease1Day, expected);
////        }

////        [TestMethod]
////        public async Task HtmlStatement_OneNewRelease2Days_Test()
////        {
////            string expected =
////$@"<h1>Rental Record for <em>CustomerName</em></h1><p>
////NewReleaseMovie2: 6<br>
////<p>Amount owed is <em>6</em><p>
////You earned <em>2</em> frequent renter points";
////            await HtmlStatementTest(Program.OneNewRelease2Days, expected);
////        }

////        [TestMethod]
////        public async Task HtmlStatement_OneChildren3Days_Test()
////        {
////            string expected =
////$@"<h1>Rental Record for <em>CustomerName</em></h1><p>
////ChildrenMovie1: 1.5<br>
////<p>Amount owed is <em>1.5</em><p>
////You earned <em>1</em> frequent renter points";
////            await HtmlStatementTest(Program.OneChildren3Days, expected);
////        }

////        [TestMethod]
////        public async Task HtmlStatement_OneChildren4Days_Test()
////        {
////            string expected =
////$@"<h1>Rental Record for <em>CustomerName</em></h1><p>
////ChildrenMovie2: 3<br>
////<p>Amount owed is <em>3</em><p>
////You earned <em>1</em> frequent renter points";
////            await HtmlStatementTest(Program.OneChildren4Days, expected);
////        }

////        [TestMethod]
////        public async Task HtmlStatement_AllMovies_Test()
////        {
////            string expected =
////$@"<h1>Rental Record for <em>CustomerName</em></h1><p>
////RegularMovie1: 2<br>
////RegularMovie2: 3.5<br>
////NewReleaseMovie1: 3<br>
////NewReleaseMovie2: 6<br>
////ChildrenMovie1: 1.5<br>
////ChildrenMovie2: 3<br>
////<p>Amount owed is <em>19</em><p>
////You earned <em>7</em> frequent renter points";
////            await HtmlStatementTest(Program.AllMovies, expected);
////        }

////        [ExcludeFromCodeCoverage]
////        private static void InvalidMovie()
////        {
////            Movie.PriceCode invalidPriceCode = (Movie.PriceCode)(-1);
////            _ = new Movie("InvalidMovie", invalidPriceCode);
////        }

////        [TestMethod]
////        public void InvalidMovie_Test()
////        {
////            Assert.ThrowsException<ArgumentOutOfRangeException>(InvalidMovie);
////        }

////        [TestMethod]
////        public async Task StatementBuilder_Test()
////        {
////            string path = "Hello.cshtml";

////            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() =>
////                StatementBuilder.BuildResult(path,
////                    new StatementData("Name", null, 0, 0)));

////            await StatementBuilder.BuildTemplate(path);

////            string result = await StatementBuilder.BuildResult(
////                path, new StatementData("Name", null, 0, 0));

////            Assert.AreEqual("Hello, Name", result);

////            string result2 = await StatementBuilder.BuildResult(
////                path, new StatementData("Name2", null, 0, 0));

////            Assert.AreEqual("Hello, Name2", result2);
////        }
////    }
////}
