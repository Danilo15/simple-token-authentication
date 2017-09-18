using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TokenService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITokenService
    {

        [OperationContract]
        TokenData GenerateToken();

        [OperationContract]
        bool ValidateToken(Guid token);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class TokenData
    {
        private Guid _Token;

        [DataMember]
        public Guid Token
        {
            get { return _Token; }
            set { _Token = value; }
        }

        private DateTime _Expire;

        public DateTime Expire
        {
            get { return _Expire; }
            set { _Expire = value; }
        }

        private string _TokenExpire;

        [DataMember]
        public string TokenExpire
        {
            get { return _TokenExpire; }
            set { _TokenExpire = value; }
        }




    }
}
