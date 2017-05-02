using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

using ProductContract = HKWCFServices.Business.Product.Contracts.Data;

namespace HKWCFServices.Business.Product.Contracts.Service
{
    [ServiceContract(Namespace = "http://www.HKWCFService.com/HKServices/ISupplierMgmtService")]
    public interface ISupplierMgmtService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetSupplierById/{supplierId}")]
        ProductContract.Supplier GetSupplierById(string supplierId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetSupplierByName/{supplierName}")]
        List<ProductContract.Supplier> GetSupplierByName(string supplierName);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllSuppliers")]
        List<ProductContract.Supplier> GetAllSuppliers();
    }
}
