using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAllCarImages();
        IResult AddCarImage(CarImage carImage);
        IResult UpdateCarImage(CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
        IDataResult<List<CarImage>> GetImagesOfCar(Car car);
        
    }
}
