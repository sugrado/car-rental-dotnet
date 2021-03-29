using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarsinfoContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarsinfoContext context = new CarsinfoContext())
            {

                var result = from customer in filter == null ? context.Customers : context.Customers.Where(filter)
                             join user in context.Users on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.Id,
                                 CompanyName = customer.CompanyName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 FindexPoint  = customer.FindexPoint
                             };
                return result.ToList();
            }
        }

        public CustomerDetailDto GetCustomerDetail(int id)
        {
            using (CarsinfoContext context = new CarsinfoContext())
            {

                var result = from customer in context.Customers.Where(c => c.Id == id)
                             join user in context.Users on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.Id,
                                 CompanyName = customer.CompanyName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 FindexPoint = customer.FindexPoint
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
