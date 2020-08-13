using System;
using System.Linq;
using System.Collections.Generic;
using LinqBasic.Abstract;
using System.Runtime.CompilerServices;

namespace LinqBasic
{

    public class ClassHome : IPersonRetriver
    {
        public IEnumerable<int> GetMalesId(IEnumerable<Person> persons)
        {
            IEnumerable<int> isMale = persons.Where(person => person.PersonGender == Gender.Male)
                .Select(person => person.Id);
            return isMale;
        }

        public IEnumerable<Person> GetOddIds(IEnumerable<Person> persons)
        {
            IEnumerable<Person> idIsOdd = persons.Where(q => q.Id % 2 != 0);
            return idIsOdd;
            

        }

        public IEnumerable<Person> OrderById(IEnumerable<Person> persons)
        {
            IEnumerable<Person> idBigToSmall = persons.OrderByDescending(persons => persons.Id);
            return idBigToSmall;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
