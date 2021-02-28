using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValdiation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcers.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Car>> GetAllCars()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetAll().SingleOrDefault(p => p.Id == id), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), Messages.Listed);
        }

        public IResult RemoveCar(int id)
        {
            Car forDelete = _carDal.GetAll().SingleOrDefault(p => p.Id == id);
            _carDal.Delete(forDelete);
            return new SuccessResult(Messages.Deleted);
        }
        
        [ValidationAspect(typeof(CarValidator))]
        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
