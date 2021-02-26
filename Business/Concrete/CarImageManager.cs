using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult AddCarImage(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteCarImage(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetImagesOfCar(Car car)
        {
            var result = _carImageDal.GetAll(p=>p.CarId == car.Id);
            return new SuccessDataResult<List<CarImage>>(result, Messages.Listed);
        }

        public IDataResult<List<CarImage>> GetAllCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IResult UpdateCarImage(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var x = _carImageDal.GetAll().Where(p => p.CarId == carId).ToList();
            
            if (x.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLımıtExceeded);
            }
            return new SuccessResult();
        }
    }
}
