using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarsinfoContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarsinfoContext context = new CarsinfoContext())
            {
                var result = from re in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join ca in context.Cars on re.CarId equals ca.Id
                             join br in context.Brands on ca.BrandId equals br.BrandId
                             join cu in context.Customers on re.CustomerId equals cu.Id
                             join us in context.Users on cu.UserId equals us.Id
                             select new RentalDetailDto
                             {
                                 Id = re.Id,
                                 CarId = ca.Id,
                                 CustomerId = cu.Id,
                                 BrandName = br.BrandName,
                                 CustomerName = us.FirstName + " " + us.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };


                return result.ToList();
            }
        }
    }
}
