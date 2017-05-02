using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HKWCFServices.Business.Customer.Contracts.Service
{
    [ServiceContract(Namespace = "http://www.HKWCFService.com/HKServices/IAccountMgmtService")]
    public interface IAccountMgmtService
    {
        [OperationContract]
        String GetAccountById(string accountId);
    }
}
