using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IdentityModel.Tokens;
using System.IdentityModel.Selectors;

namespace HKWCFServices.Business.Shared.Security
{
    /// <summary>
    /// Class to handle Authentication using custom user credentials.
    /// </summary>
    internal sealed class CustomUserNamePasswordValidator : UserNamePasswordValidator
    {
        /// <summary>
        ///This class intercepts the SOAP message and extracts the username and password through the 
        ///<c>Validate</c> method.This method is called before the <c>WCFServiceBase</c> constructor.
        ///This class name should be referenced in the <securityCredentials> section of the Web.config.
        ///<serviceCredentials>
        ///    <userNameAuthentication userNamePasswordValidationMode="Custom" 
        ///     customUserNamePasswordValidatorType="Logica.Utility.Foundation.Server.Web.CustomUserNamePasswordValidator, Logica.Utility.Foundation.Server"/>
        ///  </serviceCredentials>
        /// </summary>
        public override void Validate(string userName, string password)
        {
            //string[] loginInfo = userName.Split(';');
            //string user = loginInfo[0];                 //UserName
            //int database = Int32.Parse(loginInfo[1]);  //Database
            //int company = Int32.Parse(loginInfo[2]);   //Company

            try
            {
                //ServerSession.Authenticate(Session.eAuthenticationType.Custom, user, password, company, database);
                if (userName == "hkindia" && password == "indian")
                {

                }
                else
                {
                    throw new SecurityTokenException("Invalid Account");
                }

            }
            catch (SecurityTokenValidationException)
            {
                throw new FaultException("AUTHENTICATION");
            }
            catch (Exception)
            {
                throw new FaultException("UNKNOWN");
            }
        }
    }
}
