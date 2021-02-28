using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Core.Utilities.Results;
using Core.Utilities.Business;
using Business.Constants;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadsController : ControllerBase
    {
        ICarImageService _carImageService;

        public ImageUploadsController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.AddCarImage(file, carImage);

            if (result.Success) return Ok(result);
            return BadRequest(result);  
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAllCarImages();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesById([FromForm(Name = ("CarId"))] int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
        {
            var carImage = _carImageService.Get(Id).Data;
            var result = _carImageService.UpdateCarImage(file, carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int id)
        {
            var carImage = _carImageService.Get(id).Data;
            var result = _carImageService.DeleteCarImage(carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
