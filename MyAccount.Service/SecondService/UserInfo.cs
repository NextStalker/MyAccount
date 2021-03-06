﻿using System;
using System.Runtime.Serialization;

namespace MyAccount.Service.SecondService
{
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public bool? AdvertisingOptIn { get; set; }

        [DataMember]
        public string CountryIsoCode { get; set; }

        [DataMember]
        public DateTime DateModified { get; set; }

        [DataMember]
        public string Locale { get; set; }

        [DataMember]
        public Guid UserId { get; set; }
    }
}
