﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RefactoringDemo6.Tests
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
                "Rental Record for CustomerName\n" +
                "Amount owed is 0\n" +
                "You earned 0 frequent renter points";
            StatementTest(Program.NoRental, expected);
        }

        [TestMethod]
        public void Statement_OneRegular2Days_Test()
        {
            string expected =
                "Rental Record for CustomerName\n" +
                "\tRegularMovie1\t2\n" +
                "Amount owed is 2\n" +
                "You earned 1 frequent renter points";
            StatementTest(Program.OneRegular2Days, expected);
        }

        [TestMethod]
        public void Statement_OneRegular3Days_Test()
        {
            string expected =
                "Rental Record for CustomerName\n" +
                "\tRegularMovie2\t3.5\n" +
                "Amount owed is 3.5\n" +
                "You earned 1 frequent renter points";
            StatementTest(Program.OneRegular3Days, expected);
        }

        [TestMethod]
        public void Statement_OneNewRelease_Test()
        {
            string expected =
                "Rental Record for CustomerName\n" +
                "\tNewReleaseMovie\t9\n" +
                "Amount owed is 9\n" +
                "You earned 2 frequent renter points";
            StatementTest(Program.OneNewRelease, expected);
        }

        [TestMethod]
        public void Statement_OneChildren3Days_Test()
        {
            string expected =
                "Rental Record for CustomerName\n" +
                "\tChildrenMovie1\t1.5\n" +
                "Amount owed is 1.5\n" +
                "You earned 1 frequent renter points";
            StatementTest(Program.OneChildren3Days, expected);
        }

        [TestMethod]
        public void Statement_OneChildren4Days_Test()
        {
            string expected =
                "Rental Record for CustomerName\n" +
                "\tChildrenMovie2\t3\n" +
                "Amount owed is 3\n" +
                "You earned 1 frequent renter points";
            StatementTest(Program.OneChildren4Days, expected);
        }

        [TestMethod]
        public void Statement_AllMovies_Test()
        {
            string expected =
                "Rental Record for CustomerName\n" +
                "\tRegularMovie1\t2\n" +
                "\tRegularMovie2\t3.5\n" +
                "\tNewReleaseMovie\t9\n" +
                "\tChildrenMovie1\t1.5\n" +
                "\tChildrenMovie2\t3\n" +
                "Amount owed is 19\n" +
                "You earned 6 frequent renter points";
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
                "<h1>Rental Record for <em>CustomerName</em></h1><p>\n" +
                "<p>Amount owed is <em>0</em><p>\n" +
                "You earned <em>0</em> frequent renter points";
            HtmlStatementTest(Program.NoRental, expected);
        }

        [TestMethod]
        public void HtmlStatement_OneRegular2Days_Test()
        {
            string expected =
                "<h1>Rental Record for <em>CustomerName</em></h1><p>\n" +
                "RegularMovie1: 2<br>\n" +
                "<p>Amount owed is <em>2</em><p>\n" +
                "You earned <em>1</em> frequent renter points";
            HtmlStatementTest(Program.OneRegular2Days, expected);
        }

        [TestMethod]
        public void HtmlStatement_OneRegular3Days_Test()
        {
            string expected =
                "<h1>Rental Record for <em>CustomerName</em></h1><p>\n" +
                "RegularMovie2: 3.5<br>\n" +
                "<p>Amount owed is <em>3.5</em><p>\n" +
                "You earned <em>1</em> frequent renter points";
            HtmlStatementTest(Program.OneRegular3Days, expected);
        }

        [TestMethod]
        public void HtmlStatement_OneNewRelease_Test()
        {
            string expected =
                "<h1>Rental Record for <em>CustomerName</em></h1><p>\n" +
                "NewReleaseMovie: 9<br>\n" +
                "<p>Amount owed is <em>9</em><p>\n" +
                "You earned <em>2</em> frequent renter points";
            HtmlStatementTest(Program.OneNewRelease, expected);
        }

        [TestMethod]
        public void HtmlStatement_OneChildren3Days_Test()
        {
            string expected =
                "<h1>Rental Record for <em>CustomerName</em></h1><p>\n" +
                "ChildrenMovie1: 1.5<br>\n" +
                "<p>Amount owed is <em>1.5</em><p>\n" +
                "You earned <em>1</em> frequent renter points";
            HtmlStatementTest(Program.OneChildren3Days, expected);
        }

        [TestMethod]
        public void HtmlStatement_OneChildren4Days_Test()
        {
            string expected =
                "<h1>Rental Record for <em>CustomerName</em></h1><p>\n" +
                "ChildrenMovie2: 3<br>\n" +
                "<p>Amount owed is <em>3</em><p>\n" +
                "You earned <em>1</em> frequent renter points";
            HtmlStatementTest(Program.OneChildren4Days, expected);
        }

        [TestMethod]
        public void HtmlStatement_AllMovies_Test()
        {
            string expected =
                "<h1>Rental Record for <em>CustomerName</em></h1><p>\n" +
                "RegularMovie1: 2<br>\n" +
                "RegularMovie2: 3.5<br>\n" +
                "NewReleaseMovie: 9<br>\n" +
                "ChildrenMovie1: 1.5<br>\n" +
                "ChildrenMovie2: 3<br>\n" +
                "<p>Amount owed is <em>19</em><p>\n" +
                "You earned <em>6</em> frequent renter points";
            HtmlStatementTest(Program.AllMovies, expected);
        }
    }
}
