using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using HKWCFServices.Business.Customer.Contracts.Service;
using HKWCFServices.Business.Customer.Contracts.Data;
using HKWCFServices.Business.Shared.ExceptionHandling;

namespace HKWCFServices.Business.Customer.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    [GlobalExceptionHandlerBehavior(typeof(GlobalExceptionHandling))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode =ConcurrencyMode.Multiple, AddressFilterMode =AddressFilterMode.Any)]
    public class CustomerService : CustomerServiceBase, ICustomerMgmtService
    {

        public List<Customer.Contracts.Data.Customer> GetAllCustomers()
        {
            try
            {
                using (CustomerEntity customerRecordSet = new CustomerEntity())
                {
                    //var x = from n in connectionObjectContext.Customers select n;
                    //return x.ToList<Customer.Contracts.Data.Customer>();

                    return customerRecordSet.Customers.ToList();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("CUST001"));
                throw fe;
            }
        }

        public Customer.Contracts.Data.Customer GetCustomerById(string customerId)
        {
            try
            {
                using (CustomerEntity customerRecordSet = new CustomerEntity())
                {
                    return customerRecordSet.Customers.Single(c => c.CustomerID == customerId);
                }
            }
            catch(Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("CUST002"));
                throw fe;
            }
        }

        public List<Customer.Contracts.Data.Customer> GetCustomerByName(string customerName)
        {
            try
            {
                using (CustomerEntity customerRecordSet = new CustomerEntity())
                {
                    return customerRecordSet.Customers.Where(x => x.CompanyName.Contains(customerName)).ToList();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("CUST003"));
                throw fe;
            }
        }

        public void SaveCustomer(Customer.Contracts.Data.Customer dataSet)
        {
            try
            {
                using (CustomerEntity customerRecordSet = new CustomerEntity())
                {
                    customerRecordSet.Customers.Add(dataSet);
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("CUST002"));
                throw fe;
            }
        }
      
        public List<Customer.Contracts.Data.Customer> SearchCustomers(byte[][] filters)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
