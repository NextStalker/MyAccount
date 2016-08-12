using MyAccount.Service.SecondService;
using System;
using System.ServiceModel;

namespace MyAccount.Service.SecondService.Abstract
{
    [ServiceContract]
    public interface IUserInfoProvider
    {
        [OperationContract, FaultContract(typeof(UserNotFound))]
        UserInfo GetUserInfo(Guid userId);
    }
}