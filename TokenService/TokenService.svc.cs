using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TokenService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TokenService : ITokenService
    {
        private static TokenData lastToken;

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "GenerateToken/")]
        public TokenData GenerateToken()
        {
            TokenData data = new TokenData();

            data.Expire = DateTime.Now.AddMinutes(1);
            data.Token = Guid.NewGuid();
            data.TokenExpire = data.Expire.ToString("dd/MM/yyyy HH:mm");
            lastToken = data;

            return data;
        }

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "ValidateToken/")]
        public bool ValidateToken(Guid token)
        {
            return token == lastToken.Token && DateTime.Now <= lastToken.Expire;
        }
    }
}
