using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAccount.Service.SecondService;
using System.ServiceModel;
using MyAccount.Service.FirstService;

namespace MyAccount.UnitTests
{
    [TestClass]
    public class UserInfoProviderTest
    {
        [TestMethod]
        [ExpectedException(exceptionType: typeof(FaultException<UserNotFound>))]
        public void Cannot_Get_Nonexisting_UserInfo()
        {
            UserInfoProvider provider = new UserInfoProvider();

            UserInfo userInfo = provider.GetUserInfo(new Guid());
        }

        [TestMethod]
        public void Can_Get_UserInfo()
        {
            Guid guid = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");

            SyncProfileRequest item = new SyncProfileRequest { UserId = guid };
            SyncProfileRequestList list = SyncProfileRequestList.Instance;
            list.Clear();
            list.Add(item);
            
            UserInfoProvider provider = new UserInfoProvider();
            UserInfo userInfo = provider.GetUserInfo(guid);
            
            Assert.IsNotNull(userInfo);
            Assert.AreEqual(userInfo.AdvertisingOptIn, item.AdvertisingOptIn);
            Assert.AreEqual(userInfo.CountryIsoCode, item.CountryIsoCode);
            Assert.AreEqual(userInfo.DateModified, item.DateModified);
            Assert.AreEqual(userInfo.Locale, item.Locale);
            Assert.AreEqual(userInfo.UserId, item.UserId);
        }
    }
}
