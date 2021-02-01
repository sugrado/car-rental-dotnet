using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("\n--GetAll Function--\n");
            foreach (var x in carManager.GetAll())
            {
                Console.WriteLine(x.Description);
            }

            Console.WriteLine("\n--Add Function--\n");
            carManager.Add(new Car { BrandId = 4, ColorId = 000, DailyPrice = 950, Description = "Batman", Id = 56, ModelYear = 2056 });
            foreach (var x in carManager.GetAll())
            {
                Console.WriteLine(x.Description);
            }

            Console.WriteLine("\n--Update Function--\n");
            carManager.Update(new Car { Id = 2, BrandId = 4, ColorId = 000, DailyPrice = 950, Description = "Guncellendi", ModelYear = 2055 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\n--GetById Function--\n");
            Console.WriteLine(carManager.GetById(3).Description);

            Console.WriteLine("\n--Delete Function--\n");
            carManager.Delete(4);
            foreach (var x in carManager.GetAll())
            {
                Console.WriteLine(x.Description);
            }
        }
    }
}
