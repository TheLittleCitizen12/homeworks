using System;
using System.Linq;
using System.Collections.Generic;
using LinqBasic.Abstract;

namespace LinqBasic
{
    class Program
    {
        static void Main(string[] args)
        {
        }
         
        static public void GetMalesId(IEnumerable<Person> persons)
        {
            var isMale = persons.Where(persons => persons.PersonGender == Gender.Male);
            foreach (var i in isMale)
            {
                Console.WriteLine("Id of Male: {0} ",i.Id);
                Console.ReadLine();
            }
            
        }

        static public void OrderById(IEnumerable<Person> persons)
        {
            var idBigToSmall = persons.OrderByDescending(persons => persons.Id);
            foreach (var j in idBigToSmall)
            {
                Console.WriteLine("Id: {0} ", j.Id);
            }


        }

        static public void GetOddIds(IEnumerable<Person> persons)
        {
            var idIsOdd = persons.Where(p => p.Id % 2 != 0)
                .GroupBy(persons => persons.Id);

            foreach(var val in idIsOdd)
            {
                Console.WriteLine("Group By Odd id: {0}", val.Key);

                foreach( Person p in val)
                {
                    Console.WriteLine("Person Id: {0}  Name: {1} Gender: {2}\n", p.Id, p.Name, p.PersonGender);
                }
            }

        }



    }
}

