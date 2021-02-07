using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCar(Car car)
        {
            if(car.Description.Length>2 && car.DailyPrice>0)
            _carDal.Add(car);
            else Console.WriteLine("Description must be at least 2 characters. The daily fee should be above zero.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void RemoveCar(int id)
        {
            Car forDelete = _carDal.GetAll().SingleOrDefault(p => p.Id == id);
            _carDal.Delete(forDelete);
        }

        public void UpdateCar(Car car)
        {
            _carDal.Update(car);
        }
    }
}
