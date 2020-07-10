using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RefactoringDemoTests")]

// page 22-25
namespace RefactoringDemo4
{
    public static class Program
    {
        [ExcludeFromCodeCoverage]
        public static void Main()
        {
            Execute(nameof(NoRental), NoRental);
            Execute(nameof(OneRegular2Days), OneRegular2Days);
            Execute(nameof(OneRegular3Days), OneRegular3Days);
            Execute(nameof(OneNewRelease), OneNewRelease);
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
        }

        internal static void NoRental(Customer customer)
        {
        }

        internal static void OneRegular2Days(Customer customer)
        {
            Movie regularMovie = new Movie("RegularMovie1", Movie.REGULAR);
            Rental rental = new Rental(regularMovie, 2);
            customer.AddRental(rental);
        }

        internal static void OneRegular3Days(Customer customer)
        {
            Movie regularMovie = new Movie("RegularMovie2", Movie.REGULAR);
            Rental rental = new Rental(regularMovie, 3);
            customer.AddRental(rental);
        }

        internal static void OneNewRelease(Customer customer)
        {
            Movie newReleaseMovie = new Movie("NewReleaseMovie", Movie.NEWRELEASE);
            Rental rental = new Rental(newReleaseMovie, 3);
            customer.AddRental(rental);
        }

        internal static void OneChildren3Days(Customer customer)
        {
            Movie childrenMovie = new Movie("ChildrenMovie1", Movie.CHILDRENS);
            Rental rental = new Rental(childrenMovie, 3);
            customer.AddRental(rental);
        }

        internal static void OneChildren4Days(Customer customer)
        {
            Movie childrenMovie = new Movie("ChildrenMovie2", Movie.CHILDRENS);
            Rental rental = new Rental(childrenMovie, 4);
            customer.AddRental(rental);
        }

        internal static void AllMovies(Customer customer)
        {
            OneRegular2Days(customer);
            OneRegular3Days(customer);
            OneNewRelease(customer);
            OneChildren3Days(customer);
            OneChildren4Days(customer);
        }
    }
}
