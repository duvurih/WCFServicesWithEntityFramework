using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

using ProductContract = HKWCFServices.Business.Product.Contracts.Data;

namespace HKWCFServices.Business.Product.Contracts.Service
{
    [ServiceContract(Namespace = "http://www.HKWCFService.com/HKServices/IProductMgmtService")]
    public interface IProductMgmtService
    {
        #region Get Product Information

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetProductById/{productId}")]
        ProductContract.Product GetProductById(string productId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetProductByName/{productName}")]
        List<ProductContract.Product> GetProductsByName(string productName);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllProducts")]
        List<ProductContract.Product> GetAllProducts();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetProductByCategory/{categoryId}")]
        List<ProductContract.Product> GetProductByCategory(string categoryId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GenerateProductID")]
        int GenerateProductID();
        #endregion

        #region Search Product
        [OperationContract]
        ProductContract.Product SearchProduct(byte[][] filters);
        #endregion

        #region Save Product
        [OperationContract]
        void SaveProduct(ProductContract.Product dataSet);
        #endregion
    }
}
