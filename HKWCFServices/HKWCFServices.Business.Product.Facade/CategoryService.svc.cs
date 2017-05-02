using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using HKWCFServices.Business.Product.Contracts.Data;
using HKWCFServices.Business.Product.Contracts.Service;
using HKWCFServices.Business.Shared.ExceptionHandling;

namespace HKWCFServices.Business.Product.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CategoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CategoryService.svc or CategoryService.svc.cs at the Solution Explorer and start debugging.
    [GlobalExceptionHandlerBehavior(typeof(GlobalExceptionHandling))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CategoryService : CategoryServiceBase, ICategoryMgmtService
    {
        
        public List<Category> GetAllCategories()
        {
            try
            {
                using (ProductEntities productRecordSet = new ProductEntities())
                {
                    return productRecordSet.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("CAT001"));
                throw fe;
            }
        }

        public Category GetCategoryById(string categoryId)
        {
            try
            {
                using (ProductEntities productRecordSet = new ProductEntities())
                {
                    int Id = Convert.ToInt32(categoryId);
                    return productRecordSet.Categories.Single(c => c.CategoryID == Id);
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("CAT002"));
                throw fe;
            }
        }

        public List<Category> GetCategoryByName(string categoryName)
        {
            try
            {
                using (ProductEntities productRecordSet = new ProductEntities())
                {
                    //var resultProduct = productRecordSet.Products.OfType<Contracts.Data.Product>().Where(x => x.ProductName == productName);
                    return productRecordSet.Categories.Where(x => x.CategoryName.Contains(categoryName)).ToList();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("PROD003"));
                throw fe;
            }
        }

        public void SaveCategory(Category dataSet)
        {
            throw new NotImplementedException();
        }

        public Category SearchCategory(byte[][] filters)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
