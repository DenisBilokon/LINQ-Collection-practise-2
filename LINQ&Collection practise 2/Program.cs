using LINQ_Collection_practise_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LINQ_Сollections_practise
{
    internal class Program
    {
       static Random rnd = new Random();
        // ebuchie getters / setters
        static void Main(string[] args)
        {
            var products = new List<Product>();
            #region LINQ
            for (var i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Product" + i,
                    Energy = rnd.Next(10, 12)
                };
                products.Add(product);
            }

            var result = from item in products
                         where item.Energy < 200
                         orderby item.Energy
                         select item; //преобразование (вернуть тот же тип, который есть)
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region ExpansionM
            var result2 = products.Where(item => item.Energy < 200 || item.Energy > 400);
            //  .Where(item => item.Energy % 2 == 0)
            //  .OrderByDescending(item => item);

            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            var selectCollection = products.Select(product => product.Energy); //берем продукт, преобразовываем в энергию
            //вытащили с колекции продуктов, вытащили колекцию энергии (целых чисел)

            foreach (var item in selectCollection)
            {
                Console.WriteLine(item);
            }


            var orderbyCollection = products.OrderBy(product => product.Energy).ThenByDescending(product => product.Name);
            //сначала упорядочим по енергии (от большего к меньшему) потом по названию от меньшего к большему
            foreach (var item in orderbyCollection)
            {
                Console.WriteLine(item);
            }


            var groupbyCollection = products.GroupBy(product => product.Energy);
            foreach (var group in groupbyCollection)
            {
                Console.WriteLine($"Ключ: {group.Key}"); //выводим ключ, по которому сортируються элементы
                foreach (var item in group)
                {
                    Console.WriteLine($"\t {item}");
                }
                //группа - первый элемент это ключ, второй - коллекцией, содержавший элементы, которые подходят под ключ
            }


            products.Reverse(); // !!! Не возвращает тип ( реверс) (без начала писать)
            foreach (var item in products)
            {
                Console.WriteLine($"\t {item}");
            }


            Console.WriteLine(products.All(item => item.Energy == 10));  //bool если все соответствуют условию, тогда True (ALL)
            Console.WriteLine(products.Any(item => item.Energy == 10)); //bool если ХОТЯ БЫ 1 соответствует (AnY)
            Console.WriteLine(products.Contains(products[5]));  //bool если Коллекция СОДЕРЖИТ 5тый элемент - тогда True


            var union = products.Union(products); //дублируем лист продуктов
            // intersect - опереация, которая определяет ОБЩИЕ элементы для обоих Колекций !!!!!!!!!!!
            // except - опереация, которая определяет РАЗНЫЕ элементы обоих Колекций       !!!!!!!!!!!



            var sum = products.Sum(item => item.Energy); //сумму энергий
            var min = products.Min(item => item.Energy); //минимальныя Энергия
            var max = products.Max(item => item.Energy); //максимальная энергия
            // aggregate - SHTO ETO ????!!!!
            Console.WriteLine($"Сумма - {sum} минимум - {min} максимум - {max}");


            var sum2 = products.Skip(2).Take(3).Sum(item => item.Energy);
            //пропускаем 2 Элемента(skip),  потом берем 3 (ближайших после пропусков ?) (take) и игнорим остальные
            Console.WriteLine(sum2);


            var first = products.First(/* product => product.Energy == 10 (первый который равен 10) */);
            //берем первый элемент ... ЗАЧЕМ ??!"!?!?!? (хотя бы 1 должен быть, иначе ошибка)
            var first2 = products.FirstOrDefault(); //тоже самое, только будет не ошибка а null либо 0;
            //тоже самое с last, LastOrDefault... (последний элемент)
            var single = products.Single(product => product.Energy == 10); // тоже самое что First, выбирает один что б был 
            // равен 10, НО если будет хотя бы еще 1 элемент равный 10, будет ошибка
            // тоже есть значение OrDefault, что б не было ошибки
            var elementAt = products.ElementAt(5); //получить элемент по индексу ( начиная с 0)



            Console.ReadLine();
        }

    }
}
