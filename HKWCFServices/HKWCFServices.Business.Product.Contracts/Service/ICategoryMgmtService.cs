using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

using HKWCFServices.Business.Product.Contracts.Data;

namespace HKWCFServices.Business.Product.Contracts.Service
{
    [ServiceContract(Namespace = "http://www.HKWCFService.com/HKServices/ICategoryMgmtService")]
    public interface ICategoryMgmtService
    {
        #region Get Category Information

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCategoryById/{categoryId}")]
        Category GetCategoryById(string categoryId);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCategoryByName/{categoryName}")]
        List<Category> GetCategoryByName(string categoryName);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllCategories")]
        List<Category> GetAllCategories();

        #endregion

        #region Search Category
        [OperationContract]
        Category SearchCategory(byte[][] filters);
        #endregion

        #region Save Category
        [OperationContract]
        void SaveCategory(Category dataSet);
        #endregion
    }
}
