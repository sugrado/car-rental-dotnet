using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValdiation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        //[SecuredOperation("rental.add,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult AddRental(Rental rental)
        {
            IResult result = BusinessRules.Run(IsRentable(rental));

            if (result != null)
            {
                return result;
            }

            if (rental.ReturnDate == null) 
                return new ErrorResult(Messages.ReturnDateIsNull);

            _rentalDal.Add(rental);
            
            return new SuccessResult(Messages.Processed);
        }

        [SecuredOperation("rental.delete,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult DeleteRental(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAllRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetAll().SingleOrDefault(p => p.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.Listed);
        }

        public IDataResult<RentalDetailDto> GetRentalDetailsById(int id)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetails().SingleOrDefault(r=>r.Id == id), Messages.Listed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [SecuredOperation("rental.update,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult UpdateRental(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }

        private IResult IsRentable(Rental rental)
        {
            var result = this.GetAllByCarId(rental.CarId).Data.LastOrDefault();
            var nowTime = DateTime.Now;
            if (result == null)
            {
                return new SuccessResult(Messages.Rentable);
            }
            else if (nowTime<result.ReturnDate)
            {
                return new ErrorResult(Messages.NotRentable);
            }
            return new SuccessResult(Messages.Rentable);
        }
    }
}
