using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAllCarImages();
        IResult AddCarImage(IFormFile file, CarImage carImage);
        IResult UpdateCarImage(IFormFile file, CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarImage>> GetImagesOfCar(Car car);
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
        IResult TransactionalAdd(IFormFile file, CarImage carImage);
    }
}
