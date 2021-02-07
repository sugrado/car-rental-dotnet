using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void AddColor(Color color)
        {
            _colorDal.Add(color);
        }

        public void DeleteColor(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAllColor()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.GetAll().SingleOrDefault(p => p.Id == id);
        }

        public void UpdateColor(Color color)
        {
            _colorDal.Update(color);

        }
    }
}
