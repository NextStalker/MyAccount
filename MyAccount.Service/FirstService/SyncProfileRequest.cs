using MyAccount.Service.FirstService.Abstract;
using System;
using System.Runtime.CompilerServices;

namespace MyAccount.Service.FirstService
{
    public class SyncProfileRequest : MyAccountRequestBase
    {
        public bool? AdvertisingOptIn { get; set; }

        public string CountryIsoCode { get; set; }

        public DateTime DateModified { get; set; }

        public string Locale { get; set; }
    }
}
