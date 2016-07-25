using System;
using System.Collections.Generic;
using System.Linq;

namespace LuceneWrapper.TestApp
{
    public class Program
    {
        private static List<Person> people;
        private static List<PersonType2> peopleType2;

        static void Main(string[] args)
        {
            string dataFolder = @"C:\Temp\LuceneWrapper";

            LoadPeople();
            var writer = new Writer<Person>(dataFolder);
            writer.AddUpdateObjectsToIndex(people);

            var searcher = new Searcher<Person>(dataFolder);

            //Console.WriteLine("Search on first name Bart in FirstName field");
            //var res = searcher.SearchPeople<Person>("Bart");
            //PrintResult(res);

            //Console.WriteLine("Search on 2014 in LastName field");
            //res = searcher.SearchPeople<Person>("2014");
            //PrintResult(res);

            //Console.WriteLine("Search on 2014 in RegistrationString field");
            //res = searcher.SearchPeople<Person>("2014");
            //PrintResult(res);

            Console.WriteLine("Search on nl in all fields");
            var res = searcher.SearchObjects<Person>("nl");
            PrintResult(res);





            LoadPeopleType2();
            var writer2 = new Writer<PersonType2>(dataFolder);
            writer.AddUpdateObjectsToIndex(people);

            var searcher2 = new Searcher<PersonType2>(dataFolder);

            Console.WriteLine("Search on first name Bart in FirstName field");
            var res2 = searcher.SearchObjects<PersonType2>("Bart");
            PrintResult(res2);

            Console.ReadKey();

        }

        private static void PrintResult(SearchResult res)
        {
            Console.WriteLine();
            Console.WriteLine("Resuts found: {0}", res.Hits);
            foreach (var item in res.SearchResultItems)
            {
                Console.WriteLine("Result with ID: {0}", item.Id);
                Console.WriteLine(people.First(p => p.Id == item.Id));
            }

        }

        private static void LoadPeople()
        {
            var lang1 = new Language { Description = "Dutch", Id = 1, LanguageCode = "nl-BE" };
            var lang2 = new Language { Description = "French", Id = 2, LanguageCode = "nl-FR" };
            var lang3 = new Language { Description = "english", Id = 3, LanguageCode = "en-UK" };

            people = new List<Person>
            {
                new Person
                {
                    FirstName = "Bart",
                    LastName = "De Meyer",
                    EmailAddress = "test@localtest.me",
                    Id = 1,
                    RegistrationDate = new DateTime(2014, 1, 10),
                    RegistrationNumber = 1,
                    RegistrationSuffix = "a",
                    Languages = new List<Language> {lang1}
                },
                new Person
                {
                    FirstName = "Eddy",
                    LastName = "Janssens",
                    EmailAddress = "eddy@janssens.me",
                    Id = 2,
                    RegistrationDate = new DateTime(2014, 1, 4),
                    RegistrationNumber = 2,
                    Languages = new List<Language> {lang2, lang3}
                },
                new Person
                {
                    FirstName = "Luc",
                    LastName = "Peeters",
                    EmailAddress = "luc@peeters.me",
                    Id = 3,
                    RegistrationDate = new DateTime(2013, 12, 15),
                    RegistrationNumber = 3,
                    Languages = new List<Language> {lang1, lang3}
                },
                new Person
                {
                    FirstName = "Heike",
                    LastName = "Wouters",
                    EmailAddress = "heike@wouters.me",
                    Id = 4,
                    RegistrationDate = new DateTime(2013, 11, 20),
                    RegistrationNumber = 4,
                    Languages = new List<Language> {lang1, lang2}
                }
            };
        }


        private static void LoadPeopleType2()
        {
            var lang1 = new LanguageType2 { Description = "Dutch", Id = 1, LanguageCode = "nl-BE" };
            var lang2 = new LanguageType2 { Description = "French", Id = 2, LanguageCode = "nl-FR" };
            var lang3 = new LanguageType2 { Description = "english", Id = 3, LanguageCode = "en-UK" };

            peopleType2 = new List<PersonType2>
            {
                new PersonType2
                {
                    FirstName = "Bart",
                    LastName = "De Meyer",
                    EmailAddress = "test@localtest.me",
                    Id = 1,
                    RegistrationDate = new DateTime(2014, 1, 10),
                    RegistrationNumber = 1,
                    RegistrationSuffix = "a",
                    Languages = new List<LanguageType2> {lang1}
                },
                new PersonType2
                {
                    FirstName = "Eddy",
                    LastName = "Janssens",
                    EmailAddress = "eddy@janssens.me",
                    Id = 2,
                    RegistrationDate = new DateTime(2014, 1, 4),
                    RegistrationNumber = 2,
                    Languages = new List<LanguageType2> {lang2, lang3}
                },
                new PersonType2
                {
                    FirstName = "Luc",
                    LastName = "Peeters",
                    EmailAddress = "luc@peeters.me",
                    Id = 3,
                    RegistrationDate = new DateTime(2013, 12, 15),
                    RegistrationNumber = 3,
                    Languages = new List<LanguageType2> {lang1, lang3}
                },
                new PersonType2
                {
                    FirstName = "Heike",
                    LastName = "Wouters",
                    EmailAddress = "heike@wouters.me",
                    Id = 4,
                    RegistrationDate = new DateTime(2013, 11, 20),
                    RegistrationNumber = 4,
                    Languages = new List<LanguageType2> {lang1, lang2}
                }
            };
        }

    }
}
