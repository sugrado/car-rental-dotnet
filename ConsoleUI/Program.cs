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

            //foreach (var x in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(x.BrandId);
            //}
            Car car1 = new Car { BrandId = 256, ColorId = 125, DailyPrice = 250, Description = "New added car.", ModelYear = 2000 };
            carManager.AddCar(car1);

            //carManager.RemoveCar(1008);
            
            foreach (var x in carManager.GetAll())
            {
                Console.WriteLine(x.Description);
            }
        }
    }
}
