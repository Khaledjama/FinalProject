using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleAppTestable
{
    class Program
    {

        static void Main(string[] args)
        {

            if(!Program.CheckIsNotExisted())
                Console.WriteLine("Is Existed");
            else
                Console.WriteLine("Is Not Existed");
        }
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }
        public static bool CheckIsNotExisted()
        {
            var data = new List<Person>{
                new Person { Id=1,Name="Khaled"} ,
                new Person { Id=2,Name="Khaled"} ,
                new Person { Id=3,Name="Khaled"} ,
                new Person { Id=4,Name="Khaled"} ,
                new Person { Id=5,Name="Khaled"} ,

            };
            var Dm = data.Where(s => s.Id == 5).FirstOrDefault();
            if (Dm is  null)
            {

                return true;
            }
            else
            {
                return false;
            }
                
        }

    }
}
