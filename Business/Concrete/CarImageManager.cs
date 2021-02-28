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
<<<<<<< Updated upstream
=======
using Microsoft.AspNetCore.Http;
using Core.Utilities.FileHelper;
using System.IO;
using Business.ValidationRules.FluentValdiation;
using Core.Aspects.Autofac.Validation;
>>>>>>> Stashed changes

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

<<<<<<< Updated upstream
        public IResult AddCarImage(CarImage carImage)
=======
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult AddCarImage(IFormFile file, CarImage carImage)
>>>>>>> Stashed changes
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

<<<<<<< Updated upstream
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteCarImage(CarImage carImage)
        {
=======
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult DeleteCarImage(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            IResult result = BusinessRules.Run(FileHelper.Delete(oldpath));

            if(result != null)
            {
                return result;
            }

>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
        public IResult UpdateCarImage(CarImage carImage)
        {
=======
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult UpdateCarImage(IFormFile file, CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            carImage.ImagePath = FileHelper.Update(oldpath, file);
            carImage.Date = DateTime.Now;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }

         private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\Images\default.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id).ToList());
        }
>>>>>>> Stashed changes
    }
}
