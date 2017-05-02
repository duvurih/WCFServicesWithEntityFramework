using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using HKWCFServices.Business.Product.Contracts.Service;
using HKWCFServices.Business.Product.Contracts.Data;
using HKWCFServices.Business.Shared.ExceptionHandling;

namespace HKWCFServices.Business.Product.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    [GlobalExceptionHandlerBehavior(typeof(GlobalExceptionHandling))]
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall, ConcurrencyMode =ConcurrencyMode.Multiple)]
    public class ProductService : ProductServiceBase, IProductMgmtService
    {

        public List<Product.Contracts.Data.Product> GetAllProducts()
        {
            try
            { 
                using (ProductEntities productRecordSet = new ProductEntities())
                { 
                    return productRecordSet.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("PROD001"));
                throw fe;
            }
        }

        public Contracts.Data.Product GetProductById(string productId)
        {
            try
            { 
                using (ProductEntities productRecordSet = new ProductEntities())
                {
                    int Id = Convert.ToInt32(productId);
                    return productRecordSet.Products.Single(c => c.ProductID == Id);
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("PROD002"));
                throw fe;
            }
        }

        public List<Product.Contracts.Data.Product> GetProductsByName(string productName)
        {
            try
            { 
                using (ProductEntities productRecordSet = new ProductEntities())
                {
                    //var resultProduct = productRecordSet.Products.OfType<Contracts.Data.Product>().Where(x => x.ProductName == productName);
                    return productRecordSet.Products.Where(x => x.ProductName.Contains(productName)).ToList();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("PROD003"));
                throw fe;
            }
        }

        public List<Product.Contracts.Data.Product> GetProductByCategory(string categoryId)
        {
            try
            { 
                using (ProductEntities productRecordSet = new ProductEntities())
                {
                    int Id = Convert.ToInt32(categoryId);
                    //return productRecordSet.Products.ToList();
                    return productRecordSet.Products.Where(p => p.CategoryID == Id).ToList();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("PROD004"));
                throw fe;
            }
        }

        public int GenerateProductID()
        {
            try
            {
                using (ProductEntities productRecordSet = new ProductEntities())
                {
                    return productRecordSet.Products.Max(p => p.ProductID) + 1;
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("PROD005"));
                throw fe;
            }

        }

        public void SaveProduct(Contracts.Data.Product dataSet)
        {
            try
            {
                using (ProductEntities productRecordSet = new ProductEntities())
                {
                    productRecordSet.Products.Add(dataSet);
                    productRecordSet.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("CUST002"));
                throw fe;
            }
        }

        public Contracts.Data.Product SearchProduct(byte[][] filters)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
