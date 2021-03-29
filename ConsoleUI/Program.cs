using Business.Concrete;
using Core.Entities.Concrete;
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
            //ListByDto();
            //AddUser1();
            //AddCustomer1();
            //Console.WriteLine(carManager.RemoveCar(4002).Message); 
            //Rent();
            //ViewCarImage();
        }

        private static void ViewCarImage()
        {
            CarImageManager carImageManager = new CarImageManager(new EfCarImageDal());

            foreach (var x in carImageManager.GetImagesOfCar(new Car { Id = 2 }).Data)
            {
                Console.WriteLine(x.ImagePath);
            }
        }

        private static void Rent()
        {
            Rental rent1 = new Rental { CarId = 2, CustomerId = 3, RentDate = new DateTime(2020, 2, 14), ReturnDate = new DateTime(2021, 1, 15) };

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.AddRental(rent1).Message);
        }

        private static void AddCustomer1()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer cr2 = new Customer { UserId = 1, CompanyName = "MHMT" };
            Console.WriteLine(customerManager.AddCustomer(cr2).Message);
        }

        private static void AddUser1()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User cr1 = new User { FirstName = "grkm", LastName = "ark", Email = "qwjeıqwjeqw" };
            Console.WriteLine(userManager.AddUser(cr1).Message);
        }

        private static void ListByDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
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
            foreach (var x in carManager.GetAllCars().Data)
            {
                Console.WriteLine(x.Description);
            }

            // GetById method.
            Console.WriteLine(carManager.GetById(3002).Data.ModelYear);
            Console.WriteLine("{0}", brandManager.GetById(1).Data.BrandName);
            Console.WriteLine("{0}", colorManager.GetById(2).Data.ColorName);

            // GetCarsByColorId method.
            foreach (var x in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(x.BrandId);
            }

            // GetCarsByBrandId method.
            foreach (var x in carManager.GetCarsByBrandId(256).Data)
            {
                Console.WriteLine(x.Description);
            }

            // AddCar method.
            Car car1 = new Car { BrandId = 256, ColorId = 125, DailyPrice = 250, Description = "New added car.", ModelYear = 2000 };
            carManager.AddCar(car1);

            // UpdateCar method.
            carManager.UpdateCar(new Car { Id = 1005, BrandId = 257, Description = "Modified car.", ColorId = 126, ModelYear = 2020, DailyPrice = 769 });

            // RemoveCar method.
            //carManager.DeleteCar(1008);
        }
    }
}
