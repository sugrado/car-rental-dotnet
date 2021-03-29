using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAllCars();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult AddCar(Car car);
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);
        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int id);
        IDataResult<CarDetailDto> GetCarDetailsById(int id);
        IDataResult<List<CarDetailDto>> GetByMultipleId(int brandId, int colorId);
        IResult CheckIfRentable(int id);
    }
}
