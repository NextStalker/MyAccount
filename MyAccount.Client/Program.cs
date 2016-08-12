using MyAccount.Service.SecondService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyAccount.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInfoProviderClient client = new UserInfoProviderClient();

            try
            {
                var userInfo = client.GetUserInfo(new Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8"));
                
                Console.WriteLine("AdvertisingOptIn: " + userInfo.AdvertisingOptIn);
                Console.WriteLine("CountryIsoCode: " + userInfo.CountryIsoCode);
                Console.WriteLine("DateModified: " + userInfo.DateModified);
                Console.WriteLine("Locale: " + userInfo.Locale);
                Console.WriteLine("UserId: " + userInfo.UserId);
            }
            catch (FaultException<UserNotFound> ex)
            {
                Console.WriteLine(ex.Detail.CustomError);
            }
            
            client.Close();

            Console.ReadLine();
        }
    }
}
