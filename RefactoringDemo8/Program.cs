using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RefactoringDemoTests")]

// 8 Better .NET
namespace RefactoringDemo8
{
    public static class Program
    {
        [ExcludeFromCodeCoverage]
        public static void Main()
        {
            Execute(nameof(NoRental), NoRental);
            Execute(nameof(OneRegular2Days), OneRegular2Days);
            Execute(nameof(OneRegular3Days), OneRegular3Days);
            Execute(nameof(OneNewRelease1Day), OneNewRelease1Day);
            Execute(nameof(OneNewRelease2Days), OneNewRelease2Days);
            Execute(nameof(OneChildren3Days), OneChildren3Days);
            Execute(nameof(OneChildren4Days), OneChildren4Days);
            Execute(nameof(AllMovies), AllMovies);
        }

        [ExcludeFromCodeCoverage]
        private static void Execute(string name, Action<Customer> action = null)
        {
            Customer customer = new Customer("CustomerName");

            action?.Invoke(customer);

            Console.WriteLine($"{name}:\n{customer.Statement()}\n");
            Console.WriteLine($"{name}:\n{customer.HtmlStatement()}\n");
        }

        internal static void NoRental(Customer customer)
        {
        }

        internal static void OneRegular2Days(Customer customer)
        {
            Movie regularMovie = new Movie("RegularMovie1", Movie.PriceCode.Regular);
            Rental rental = new Rental(regularMovie, 2);
            customer.AddRental(rental);
        }

        internal static void OneRegular3Days(Customer customer)
        {
            Movie regularMovie = new Movie("RegularMovie2", Movie.PriceCode.Regular);
            Rental rental = new Rental(regularMovie, 3);
            customer.AddRental(rental);
        }

        internal static void OneNewRelease1Day(Customer customer)
        {
            Movie newReleaseMovie = new Movie("NewReleaseMovie1", Movie.PriceCode.NewRelease);
            Rental rental = new Rental(newReleaseMovie, 1);
            customer.AddRental(rental);
        }

        internal static void OneNewRelease2Days(Customer customer)
        {
            Movie newReleaseMovie = new Movie("NewReleaseMovie2", Movie.PriceCode.NewRelease);
            Rental rental = new Rental(newReleaseMovie, 2);
            customer.AddRental(rental);
        }

        internal static void OneChildren3Days(Customer customer)
        {
            Movie childrenMovie = new Movie("ChildrenMovie1", Movie.PriceCode.Childrens);
            Rental rental = new Rental(childrenMovie, 3);
            customer.AddRental(rental);
        }

        internal static void OneChildren4Days(Customer customer)
        {
            Movie childrenMovie = new Movie("ChildrenMovie2", Movie.PriceCode.Childrens);
            Rental rental = new Rental(childrenMovie, 4);
            customer.AddRental(rental);
        }

        internal static void AllMovies(Customer customer)
        {
            OneRegular2Days(customer);
            OneRegular3Days(customer);
            OneNewRelease1Day(customer);
            OneNewRelease2Days(customer);
            OneChildren3Days(customer);
            OneChildren4Days(customer);
        }
    }
}
