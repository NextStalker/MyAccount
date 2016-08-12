using System;
using System.Runtime.Serialization;

namespace MyAccount.Service.SecondService
{
    [DataContract]
    public class UserNotFound
    {
        [DataMember]
        public string CustomError;

        public UserNotFound(string error)
        {
            this.CustomError = error;
        }
    }
}
