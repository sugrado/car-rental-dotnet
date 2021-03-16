using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car {Id=1, Description="Sports", BrandId=2, ModelYear=1996,ColorId=1,DailyPrice=120},
                new Car {Id=2, Description="Sedan", BrandId=3, ModelYear=2010,ColorId=1,DailyPrice=300},
                new Car {Id=3, Description="Coupe", BrandId=3, ModelYear=2018,ColorId=1,DailyPrice=400},
                new Car {Id=4, Description="Hatchback", BrandId=2, ModelYear=2013,ColorId=1,DailyPrice=310},
                new Car {Id=5, Description="Station Wagon", BrandId=5, ModelYear=2020,ColorId=1,DailyPrice=450},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int id)
        {
            Car forDelete = _cars.SingleOrDefault(d => id == d.Id);
            _cars.Remove(forDelete);
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(g => g.Id == id);
        }

        public Car GetById(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car forUpdate = _cars.SingleOrDefault(u => u.Id == car.Id);
            forUpdate.BrandId = car.BrandId;
            forUpdate.ColorId = car.ColorId;
            forUpdate.DailyPrice = car.DailyPrice;
            forUpdate.Description = car.Description;
            forUpdate.ModelYear = car.ModelYear;
        }
    }
}
