using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValdiation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("customer.add,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("customer.delete,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult DeleteCustomer(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAllCustomers()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
        }

        //[CacheAspect]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.GetAll().SingleOrDefault(p=>p.Id == id));
        }

        public IDataResult<CustomerDetailDto> GetCustomerDetail(int customerId)
        {
            return new SuccessDataResult<CustomerDetailDto>(_customerDal.GetCustomerDetail(customerId));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomersDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(),Messages.Listed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("customer.update,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.Updated);
        }

        public IResult UpdateCustomerFindexScore(Customer customer)
        {
            if (customer.FindexPoint >= 1900)
            {
                return new ErrorResult(Messages.BecameVIP);
            }

            var customerToUpdate = GetById(customer.Id).Data;
            customerToUpdate.FindexPoint += 100;
            customerToUpdate.CompanyName = customer.CompanyName;
            customerToUpdate.UserId = customer.UserId;
            UpdateCustomer(customerToUpdate);

            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
