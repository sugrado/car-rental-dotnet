using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void AddBrand(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAllBrand()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.GetAll().SingleOrDefault(p => p.Id == id);
        }

        public void UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);

        }
    }
}
