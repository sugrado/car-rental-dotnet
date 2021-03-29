using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.AddCar(car);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.UpdateCar(car);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.DeleteCar(car);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAllCars();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbyid")]
        public IActionResult GetCarDetailsById(int id)
        {
            var result = _carService.GetCarDetailsById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbymultipleid")]
        public IActionResult GetByMultipleId(int brandId, int colorId)
        {
            var result = _carService.GetByMultipleId(brandId, colorId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbybrand")]
        public IActionResult GetCarDetailsByBrand(int id)
        {
            var result = _carService.GetCarDetailsByBrand(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcardetailsbycolor")]
        public IActionResult GetCarDetailsByColor(int id)
        {
            var result = _carService.GetCarDetailsByColor(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("checkifrentable")]
        public IActionResult CheckIfRentable(int id)
        {
            var result = _carService.CheckIfRentable(id);
            if (result.Success) return Ok(result.Success);
            return BadRequest(result.Success);
        }
    }
}