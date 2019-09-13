using AppSheet.Endpoint;
using AppSheet.Service;
using Refit;
using System;

namespace AppSheet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching Data...");

            var peopleEndpoint = RestService.For<IPeopleEndpoint>("https://appsheettest1.azurewebsites.net/sample/");
            var peopleService = new PeopleService(peopleEndpoint);

            var peopleToDisplay = peopleService.GetAnswerToCodingAssessment();
            foreach (var person in peopleToDisplay)
            {
                Console.WriteLine($"Id: {person.Id} Name: {person.Name} Age: {person.Age} Number: {person.Number}");
            }
            Console.ReadLine();
        }
    }
}
