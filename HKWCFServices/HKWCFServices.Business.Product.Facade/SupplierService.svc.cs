using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using HKWCFServices.Business.Product.Contracts.Service;
using HKWCFServices.Business.Product.Contracts.Data;
using HKWCFServices.Business.Shared.ExceptionHandling;

namespace HKWCFServices.Business.Product.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SupplierService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SupplierService.svc or SupplierService.svc.cs at the Solution Explorer and start debugging.
    [GlobalExceptionHandlerBehavior(typeof(GlobalExceptionHandling))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SupplierService : SupplierServiceBase, ISupplierMgmtService
    {
        public List<Supplier> GetAllSuppliers()
        {
            try
            {
                using (ProductEntities supplierRecordSet = new ProductEntities())
                {
                    return supplierRecordSet.Suppliers.ToList();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("SUP001"));
                throw fe;
            }
        }

        public Supplier GetSupplierById(string supplierId)
        {
            try
            {
                using (ProductEntities supplierRecordSet = new ProductEntities())
                {
                    int Id = Convert.ToInt32(supplierId);
                    return supplierRecordSet.Suppliers.Single(c => c.SupplierID == Id);
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("SUP002"));
                throw fe;
            }
        }

        public List<Supplier> GetSupplierByName(string supplierName)
        {
            try
            {
                using (ProductEntities supplierRecordSet = new ProductEntities())
                {
                    //var resultProduct = productRecordSet.Products.OfType<Contracts.Data.Product>().Where(x => x.ProductName == productName);
                    return supplierRecordSet.Suppliers.Where(x => x.CompanyName.Contains(supplierName)).ToList();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("SUP003"));
                throw fe;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
