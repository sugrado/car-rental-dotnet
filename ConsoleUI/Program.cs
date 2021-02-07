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
            //Operations();
            CarManager carManager = new CarManager(new EfCarDal());
            
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Id: {0} / Brand: {1} / Color: {2} / Price: {3}", car.Id, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }

        private static void Operations()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            // GetAll method.
            foreach (var x in carManager.GetAll())
            {
                Console.WriteLine(x.Description);
            }

            // GetById method.
            Console.WriteLine(carManager.GetById(3002).ModelYear);
            Console.WriteLine("{0}", brandManager.GetById(1).Name);
            Console.WriteLine("{0}", colorManager.GetById(2).Name);

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
            carManager.UpdateCar(new Car { Id = 1005, BrandId = 257, Description = "Modified car.", ColorId = 126, ModelYear = 2020, DailyPrice = 769 });

            // RemoveCar method.
            carManager.RemoveCar(1008);
        }
    }
}
