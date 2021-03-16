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
using Microsoft.AspNetCore.Http;
using Core.Utilities.FileHelper;
using System.IO;
using Business.ValidationRules.FluentValdiation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Performance;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [SecuredOperation("image.add,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult AddCarImage(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [SecuredOperation("image.delete,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult DeleteCarImage(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            IResult result = BusinessRules.Run(FileHelper.Delete(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetImagesOfCar(Car car)
        {
            var result = _carImageDal.GetAll(p => p.CarId == car.Id);
            return new SuccessDataResult<List<CarImage>>(result, Messages.Listed);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAllCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [SecuredOperation("image.update,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult UpdateCarImage(IFormFile file, CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            carImage.ImagePath = FileHelper.Update(oldpath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int CarId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == CarId).Any();
            if (!result)
            {
                List<CarImage> carimage = new List<CarImage>();
                carimage.Add(new CarImage { CarId = CarId, ImagePath = @"\Images\default.jpg" });
                return new SuccessDataResult<List<CarImage>>(carimage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == CarId));
        }

        public IResult TransactionalAdd(IFormFile file, CarImage carImage)
        {
            AddCarImage(file, carImage);
            UpdateCarImage(file, carImage);
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
