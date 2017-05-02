using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

using SalesContract = HKWCFServices.Business.Sales.Contracts.Data;

namespace HKWCFServices.Business.Sales.Contracts.Service
{
    [ServiceContract(Namespace = "http://www.HKWCFService.com/HKServices/ISalesMgmtService")]
    public interface ISalesMgmtService
    {
        #region Get Sales Information

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllOrders")]
        List<SalesContract.Order> GetAllOrders();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetOrderById/{orderId}")]
        SalesContract.Order GetOrderById(string orderId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetOrderDetailsById/{orderDetailId}/{productId}")]
        List<SalesContract.Order_Detail> GetOrderDetailsById(string orderDetailId, string productId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GenerateOrderID")]
        int GenerateOrderID();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GenerateOrderDetailID")]
        int GenerateOrderDetailID();
        #endregion

        #region Search Product
        [OperationContract]
        SalesContract.Order SearchOrder(byte[][] filters);
        #endregion

        #region Save Product
        [OperationContract]
        void SaveOrder(SalesContract.Order dataSet);
        #endregion
    }
}
