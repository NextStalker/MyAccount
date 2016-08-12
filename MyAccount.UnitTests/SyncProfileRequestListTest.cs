using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAccount.Service.Logging;
using MyAccount.Service.FirstService;

namespace MyAccount.UnitTests
{
    [TestClass]
    public class SyncProfileRequestListTest
    {
        [TestMethod]
        public void Can_Add_SyncProfileRequest()
        {
            var list = GetList();
            list.Clear();
            list.Add(new SyncProfileRequest());

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void Cannot_Add_Nonexistent_SyncProfileRequest()
        {
            var list = GetList();
            list.Add(null);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Can_Edit_SyncProfileRequest()
        {
            var list = GetList();
            list.Add(new SyncProfileRequest { UserId = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4") });

            SyncProfileRequest item = new SyncProfileRequest
                {
                    AdvertisingOptIn = true,
                    CountryIsoCode = "RU",
                    DateModified = DateTime.Today.AddDays(-1),
                    Locale = "en-US",
                    UserId = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4")
                };

            list.Add(item);

            Assert.AreEqual(1, list.Count);

            var itemFromList = list.Get(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"));

            Assert.IsNotNull(itemFromList);
            Assert.AreEqual(item.AdvertisingOptIn, itemFromList.AdvertisingOptIn);
            Assert.AreEqual(item.CountryIsoCode, itemFromList.CountryIsoCode);
            Assert.AreEqual(item.DateModified, itemFromList.DateModified);
            Assert.AreEqual(item.Locale, itemFromList.Locale);
            Assert.AreEqual(item.RequestId, itemFromList.RequestId);
            Assert.AreEqual(item.UserId, itemFromList.UserId);
        }
        
        [TestMethod]
        public void Can_Get_SyncProfileRequest()
        {
            var list = GetList();
            
            var userId = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");

            list.Add(new SyncProfileRequest { UserId = userId });

            var account = list.Get(userId);

            Assert.IsNotNull(account);

            Assert.AreEqual(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), account.UserId);

        }

        [TestMethod]
        public void Can_Clear_List()
        {
            var list = GetList();
            list.Add(new SyncProfileRequest { UserId = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E1") });
            list.Add(new SyncProfileRequest { UserId = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E2") });
            list.Add(new SyncProfileRequest { UserId = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E3") });
            list.Add(new SyncProfileRequest { UserId = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4") });
            list.Add(new SyncProfileRequest { UserId = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E5") });

            Assert.AreEqual(5, list.Count);

            list.Clear();

            Assert.AreEqual(0, list.Count);
        }

        public SyncProfileRequestList GetList()
        {
            var list = SyncProfileRequestList.Instance;
            list.Clear();

            return list;
        }
    }
}
