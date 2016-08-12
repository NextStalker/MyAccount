using MyAccount.Service.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAccount.Service.FirstService
{
    public sealed class SyncProfileRequestList
    {
        private static SyncProfileRequestList instance = new SyncProfileRequestList();
        private static IList<SyncProfileRequest> list = new List<SyncProfileRequest>();
        private static ILogger logger = LogManager.GetLogger();

        private SyncProfileRequestList() { }

        public int Count { get { return list.Count; } }
        public static SyncProfileRequestList Instance { get { return instance; } }

        public void Add(SyncProfileRequest item)
        {
            logger.Debug("Запрос на добавление с список SyncProfileRequestList");
            logger.Debug("Проверяем SyncProfileRequest на null");
            if (item == null)
            {
                logger.Warning("Отклоняем добавление, так как SyncProfileReques равен null", new object[0]);
            }
            else
            {
                SyncProfileRequest request = this.Get(item.UserId);
                if (request == null)
                {
                    logger.Information("Элемент с UserId {UserId} не найден с списке, соответственно добавляем его", item.UserId);
                    list.Add(item);
                    logger.Debug("Элемент добавлен {@item}", item);
                }
                else
                {
                    logger.Information("Элемент с UserId {UserId} найден в списке, обновляём поля", item.UserId);
                    request.AdvertisingOptIn = item.AdvertisingOptIn;
                    request.CountryIsoCode = item.CountryIsoCode;
                    request.DateModified = item.DateModified;
                    request.Locale = item.Locale;
                    request.RequestId = item.RequestId;
                    logger.Debug("Элемент обновлён {@item}", new object[] { item });
                }
            }
        }

        public void Clear()
        {
            list.Clear();
        }

        public SyncProfileRequest Get(Guid userId)
        {
            logger.Debug("Выполяем поиск в SyncProfileRequestList по UserId {UserId}", new object[] { userId });
            return list.FirstOrDefault<SyncProfileRequest>(a => (a.UserId == userId));
        }
    }
}
