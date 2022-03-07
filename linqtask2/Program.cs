using System;
using System.Linq;
using System.Collections.Generic;

namespace linqtask2
{
    public enum Color
    {
        Red, Green, Yellow
    }
    public class Fruit
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public double Price { get; set; }
    }
    class Program
    {  
        static void Main(string[] args)
        {
            List<Fruit> fruits = new List<Fruit>
            {
                new Fruit{ Id ="f1", Name ="Apple", Color = Color.Red ,Price = 23.0},
                new Fruit{ Id ="f2", Name ="Banana", Color = Color.Yellow,Price = 10.0},
                new Fruit{ Id ="f3", Name ="Pineapple", Color = Color.Yellow,Price = 55.0},
                new Fruit{ Id ="f4", Name ="Cherry", Color = Color.Red,Price = 40.0},
                new Fruit{ Id ="f5", Name ="Watermelon", Color = Color.Green,Price = 28.0},
                new Fruit{ Id ="f6", Name ="Strawberry", Color = Color.Red,Price = 33.0},

            };

            var lowestprice = 20;
            var highestprice = 50;
            var budget = 40;

            var fruitdescending = (from fru in fruits
                                  orderby fru.Name descending
                                  select fru).ToList();
            var fruiascending = (from fru in fruits
                                   orderby fru.Name ascending
                                   select fru).ToList();

            var fruitsbycolor = (from fru in fruits
                                   where fru.Color == Color.Red || fru.Color == Color.Green
                                   select fru).ToList();

            var cheapestfruit = (from fru in fruits
                                 where fru.Price <= lowestprice
                                 select fru).ToList();

            var highestfruit = (from fru in fruits
                                 where fru.Price >= highestprice
                                 select fru).ToList();

            var Budgetfruit = (from fru in fruits
                               where fru.Price <= budget
                               select fru).ToList();

            var countfruit = (from fru in fruits
                             where fru.Color == Color.Red
                             select fru).Count();

            var orderbyname = from fru in fruits
                              group fru by fru.Color  into fruitgroup
                             // orderby fruitgroup.Key
                              select fruitgroup;

            var FruitsOrderedLambda = fruits.GroupBy(Fruit => Fruit.Color);
            Console.WriteLine("1) Ordered fruits in descending order.");
            DisplayFruit(fruits: fruitdescending);
            Console.WriteLine("");
            Console.WriteLine("2) Ordered fruits in ascending order.");
            DisplayFruit(fruits: fruiascending);
            Console.WriteLine("");
            Console.WriteLine("3) Ordered fruits in color order.");
            DisplayFruit(fruits: fruitsbycolor);
            Console.WriteLine("");
            Console.WriteLine("4) Ordered fruits in cheapest fruit.");
            DisplayFruit(fruits: cheapestfruit);
            Console.WriteLine("");
            Console.WriteLine("5) Ordered fruits in highest price fruit.");
            DisplayFruit(fruits: highestfruit);
            Console.WriteLine("");

            Console.WriteLine("6) Ordered fruits in budget fruit.");
            DisplayFruit(fruits: Budgetfruit);
            Console.WriteLine("");
            Console.WriteLine("7) count of red color fruit" + countfruit);
            Console.WriteLine("");

            foreach (var fruitgroup in FruitsOrderedLambda)
            {
                Console.WriteLine(fruitgroup.Key);
                foreach (var fruit in fruitgroup)
                {
                    Console.WriteLine("   "+fruit.Name);
                }
            }

            static void DisplayFruit(List<Fruit> fruits)
            {
                foreach (var fruit in fruits)
                {

                    Console.WriteLine(fruit.Name);

                }
            }

        }

        

    }
}

