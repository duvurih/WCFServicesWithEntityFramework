using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using HKWCFServices.Business.Sales.Contracts.Data;
using HKWCFServices.Business.Sales.Contracts.Service;
using HKWCFServices.Business.Shared.ExceptionHandling;

namespace HKWCFServices.Business.Sales.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SalesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SalesService.svc or SalesService.svc.cs at the Solution Explorer and start debugging.
    [GlobalExceptionHandlerBehavior(typeof(GlobalExceptionHandling))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SalesService : SalesServiceBase, ISalesMgmtService
    {

        public int GenerateOrderDetailID()
        {
            throw new NotImplementedException();
        }

        public int GenerateOrderID()
        {
            try
            {
                using (SalesEntities productRecordSet = new SalesEntities())
                {
                    return productRecordSet.Orders.Max(p => p.OrderID) + 1;
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("PROD005"));
                throw fe;
            }
        }

        public List<Order> GetAllOrders()
        {
            try
            {
                using (SalesEntities salesRecordSet = new SalesEntities())
                {
                    return salesRecordSet.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("PROD001"));
                throw fe;
            }
        }

        public Order GetOrderById(string orderId)
        {
            try
            {
                using (SalesEntities salesRecordSet = new SalesEntities())
                {
                    int Id = Convert.ToInt32(orderId);
                    return salesRecordSet.Orders.Single(c => c.OrderID == Id);
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("PROD002"));
                throw fe;
            }
        }

        public List<Order_Detail> GetOrderDetailsById(string orderDetailId, string productId)
        {
            try
            {
                using (SalesEntities salesRecordSet = new SalesEntities())
                {
                    int orderId = Convert.ToInt32(orderDetailId);
                    int prodId = Convert.ToInt32(productId);
                    return salesRecordSet.Order_Details.Where(c => c.OrderID.Equals(orderId)).ToList();
                }
            }
            catch (Exception ex)
            {
                FaultException fe = new FaultException(ex.Message, new FaultCode("PROD002"));
                throw fe;
            }
        }

        public void SaveOrder(Order dataSet)
        {
            throw new NotImplementedException();
        }

        public Order SearchOrder(byte[][] filters)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
