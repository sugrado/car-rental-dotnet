using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            // ------------ USE OF METHODS ------------

            // GetAll method.
            foreach (var x in carManager.GetAll())
            {
                Console.WriteLine(x.Description);
            }

            // GetCarsByColorId method.
            foreach (var x in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(x.BrandId);
            }

            // GetCarsByBrandId method.
            foreach (var x in carManager.GetCarsByBrandId(256))
            {
                Console.WriteLine(x.Description);
            }

            // AddCar method.
            Car car1 = new Car { BrandId = 256, ColorId = 125, DailyPrice = 250, Description = "New added car.", ModelYear = 2000 };
            carManager.AddCar(car1);

            // UpdateCar method.
            carManager.UpdateCar(new Car { BrandId = 55, ColorId = 2, DailyPrice = 900, Description = "Updated car.", ModelYear = 2000, Id = 1004 });

            // RemoveCar method.
            carManager.RemoveCar(1008); 
        }
    }
}
