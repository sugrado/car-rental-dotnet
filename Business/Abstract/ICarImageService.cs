using Core.Utilities.Results;
using Entities.Concrete;
<<<<<<< Updated upstream
=======
using Microsoft.AspNetCore.Http;
>>>>>>> Stashed changes
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAllCarImages();
<<<<<<< Updated upstream
        IResult AddCarImage(CarImage carImage);
        IResult UpdateCarImage(CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
        IDataResult<List<CarImage>> GetImagesOfCar(Car car);
        
=======
        IResult AddCarImage(IFormFile file, CarImage carImage);
        IResult UpdateCarImage(IFormFile file, CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarImage>> GetImagesOfCar(Car car);
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
>>>>>>> Stashed changes
    }
}
