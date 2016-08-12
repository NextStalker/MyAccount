using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serilog;
using System.ServiceModel;
using MyAccount.Service.FirstService;
using MyAccount.Service.SecondService.Abstract;
using MyAccount.Service.Logging;

namespace MyAccount.Service.SecondService
{
    public class UserInfoProvider : IUserInfoProvider
    {
        private static ILogger logger = LogManager.GetLogger();

        public UserInfo GetUserInfo(Guid userId)
        {
            logger.Debug("Запрос пользователя UserId {UserId}", userId);
            SyncProfileRequest request = SyncProfileRequestList.Instance.Get(userId);
            if (request == null)
            {
                logger.Error("Пользователь не найден UserId {@request}", userId);
                throw new FaultException<UserNotFound>(new UserNotFound("User not found"));
            }
            logger.Debug("Формируем ответ UserInfo");
            logger.Debug("Копируем поля SyncProfileRequest в UserInfo");
            UserInfo info = new UserInfo
            {
                AdvertisingOptIn = request.AdvertisingOptIn,
                CountryIsoCode = request.CountryIsoCode,
                DateModified = request.DateModified,
                Locale = request.Locale,
                UserId = request.UserId
            };
            logger.Debug("Поля скопированы");
            logger.Debug("Отправляем ответ {@UserInfo}", info);
            return info;
        }
    }
}