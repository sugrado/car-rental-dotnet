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
<<<<<<< Updated upstream
        IWebHostEnvironment _webHostEnvironment;

        public ImageUploadsController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("add")]
        public IActionResult Post([FromForm] List<IFormFile> formFile, [FromForm] CarImage carImage)
        {
            List<IResult> results = new List<IResult>();

            foreach (var image in formFile)
            {
                if (image.Length > 0)
                {
                    string imageExtension = Path.GetExtension(image.FileName);
                    string newImageName = string.Format("{0}{1}", Guid.NewGuid().ToString("D"), imageExtension);
                    string imageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    string fullImagePath = Path.Combine(imageFolder, newImageName);
                    string webImagePath = string.Format("/Images/{0}", newImageName);

                    // _webHostEnvironment.WebRootPath = D:\Documents\VSProjects\ReCapProject-CarRentalCompany\WebAPI\wwwroot
                    // fullImagePath = D:\Documents\VSProjects\ReCapProject-CarRentalCompany\WebAPI\wwwroot\Images\image.bmp
                    // webImagePath = /Images/image.bmp

                    if (!Directory.Exists(imageFolder))
                        Directory.CreateDirectory(imageFolder);
                    using (FileStream fileStream = System.IO.File.Create(fullImagePath))
                    {
                        image.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    results.Add(_carImageService.AddCarImage(new CarImage()
                    {
                        ImagePath = webImagePath,
                        CarId = carImage.CarId
                    })); 
                }
            }
            
            var check = BusinessRules.Run(results.ToArray());
            if (check == null)
            {
                return Ok(new SuccessResult(Messages.Added));
            }
            return BadRequest(check);  
=======

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
>>>>>>> Stashed changes
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAllCarImages();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

<<<<<<< Updated upstream
        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.UpdateCarImage(carImage);
=======
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
>>>>>>> Stashed changes
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
<<<<<<< Updated upstream
        public IActionResult Delete(CarImage carImage)
        {
=======
        public IActionResult Delete([FromForm(Name = ("Id"))] int id)
        {
            var carImage = _carImageService.Get(id).Data;
>>>>>>> Stashed changes
            var result = _carImageService.DeleteCarImage(carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
