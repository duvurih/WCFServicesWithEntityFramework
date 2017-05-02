using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKWCFServices.Business.Shared.Customer
{
    public static class AccountDef
    {
        public static Dictionary<long, string> GetEnumNames(Type enumType)
        {
            Dictionary<long, string> enumDict = new Dictionary<long, string>();
            if (enumType.Equals(typeof(CustomerType)))
            {
                enumDict.Add((long)CustomerType.Consumer,
                  "Consumer");
                enumDict.Add((long)CustomerType.Corporate,
                  "Corporate");
            }
            return enumDict;
        }
    }

    public enum CustomerType : int
    {
        NotSpecified = 0,
        Consumer = 1,
        Corporate = 2
    }
}
