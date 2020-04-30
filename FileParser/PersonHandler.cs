using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ObjectLibrary;



namespace FileParser {
    
    //public class Person { }  // temp class delete this when Person is referenced from dll
    
    public class PersonHandler {
        public List<Person> People;
        

        public int parseId(string id)
        {
            return int.Parse(id);
        }

        public List<List<string>> RemoveHashes(List<List<string>> data)
        {
            foreach (var row in data)
            {
                for (var index = 0; index < row.Count; index++)
                {
                    if (row[index][0] == '#')
                        row[index] = row[index].Remove(0, 1);

                }
            }
            return data;
        }

            /// <summary>
            /// Converts List of list of strings into Person objects for People attribute.
            /// </summary>
            /// <param name="people"></param>
            public PersonHandler(List<List<string>> people) {
            People = new List<Person>();

            DataParser dp = new DataParser();
            people = dp.StripQuotes(people);
            people = dp.StripWhiteSpace(people);
            people = RemoveHashes(people);

            for (int i = 1; i < people.Count; i++)
            {
                People.Add(new Person(parseId(people[i][0]), people[i][1], people[i][2], new DateTime(long.Parse(people[i][3]))));
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest() {
           
            DateTime dob = People.Select(i => i.Dob).Min();

            List<Person> result = People.Where(p => p.Dob == dob).ToList();


            return result; //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id) {

            People.Where(p => p.Id == id);

            List<Person> result = People.Where(p => p.Id == id).ToList();

            return result.ToString();  //-- return result here
        }

        public List<Person> GetOrderBySurname()
        {
            var orderByDescendingResult = from p in People
                                          orderby p.Surname ascending
                                          select p;

            return orderByDescendingResult.ToList();  //-- return result here

        } 

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {
            return 0;  //-- return result here
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            List<string> result = new List<string>();

            

            return result;  //-- return result here
        }
    }
}