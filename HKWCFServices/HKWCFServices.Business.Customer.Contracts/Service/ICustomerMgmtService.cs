using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HKWCFServices.Business.Customer.Contracts.Service
{
    [ServiceContract(Namespace = "http://www.HKWCFService.com/HKServices/ICustomerMgmtService")]
    public interface ICustomerMgmtService
    {
        #region Get Customer Information
        //[OperationContract(ProtectionLevel =ProtectionLevel.None)]
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCustomerById/{customerId}")]
        Customer.Contracts.Data.Customer GetCustomerById(string customerId);

        //[OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetAllCustomers")]
        List<Customer.Contracts.Data.Customer> GetAllCustomers();

        //[OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCustomerByName/{customerName}")]
        List<Customer.Contracts.Data.Customer> GetCustomerByName(string customerName);
        #endregion Get Customer Information

        #region Search Customer
        //[OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        [OperationContract]
        List<Customer.Contracts.Data.Customer> SearchCustomers(byte[][] filters);
        #endregion Search Customer

        #region Save Customer
        //[OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        [OperationContract]
        //[WebInvoke(Method ="POST", ResponseFormat =WebMessageFormat.Json, UriTemplate = "SaveCustomer/{dataSet}")]
        void SaveCustomer(Customer.Contracts.Data.Customer dataSet);
        #endregion Save Customer

    }
}
