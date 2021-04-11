using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValdiation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcers.Caching;
using Core.CrossCuttingConcers.Validation.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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

       // [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult AddCar(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            AddCar(car);
            UpdateCar(car);
            return new SuccessResult(Messages.Updated);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAllCars()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
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

        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult DeleteCar(Car car)
        {
            IResult result = BusinessRules.Run(IsDeletable(car));

            if (result != null)
            {
                return result;
            }

            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        //[SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == id), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.ColorId == id), Messages.Listed);
        }

        public IDataResult<CarDetailDto> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetail(id), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetByMultipleId(int brandId, int colorId)
        {
            if(brandId==0 && colorId==0) return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Listed);
            else if (brandId==0 && colorId != 0) return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId), Messages.Listed);
            else if (colorId==0 && brandId != 0) return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId), Messages.Listed);
            else return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId), Messages.Listed);
        }

        private IResult IsDeletable(Car car)
        {
            IRentalService rentalService = new RentalManager(new EfRentalDal());
            var nowTime = DateTime.Now;
            var result = rentalService.GetAllByCarId(car.Id).Data.Any();
            var result2 = rentalService.GetAllByCarId(car.Id).Data.LastOrDefault();
            if (result)
            {
                if (nowTime < result2.ReturnDate)
                    return new ErrorResult(Messages.UsingNow);
            }
            
            return new SuccessResult();
        }

        public IResult CheckIfRentable(int id)
        {
            IRentalService rentalService = new RentalManager(new EfRentalDal());
            var nowTime = DateTime.Now;
            var forCheck = _carDal.GetAll(p => p.Id == id).SingleOrDefault();
            var result = rentalService.GetAllByCarId(forCheck.Id).Data.LastOrDefault();
            if (result == null)
            {
                return new SuccessResult(Messages.Rentable);
            }
            else if (nowTime < result.ReturnDate)
            {
                return new ErrorResult(Messages.NotRentable);
            }
            return new SuccessResult(Messages.Rentable);
        }
    }
}
