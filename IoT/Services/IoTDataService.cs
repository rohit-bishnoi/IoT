using IoT.Models;
using IoT.Services.Interfaces;

namespace IoT.Services
{
    public class IoTDataService : IIoTDataService
    {
        private readonly List<DataEntry> _dataEntries;

        public IoTDataService()
        {
            _dataEntries = SimulateDataService.GenerateMockData();
        }

        public IEnumerable<object> GetDailyAverages()
        {
            return _dataEntries.GroupBy(e => e.Timestamp.Date)
                               .Select(g => new { Date = g.Key, Average = g.Average(e => e.DataValue) });
        }

        public double GetWeeklyAverage()
        {
            var last7Days = _dataEntries.Where(e => e.Timestamp >= DateTime.Today.AddDays(-7));
            return last7Days.Any() ? last7Days.Average(e => e.DataValue) : 0;
        }

        public double GetCustomAverage(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate || !_dataEntries.Any(e => e.Timestamp >= startDate && e.Timestamp <= endDate))
            {
                throw new ArgumentException("Invalid date range or no data available.");
            }

            var customRangeData = _dataEntries.Where(e => e.Timestamp >= startDate && e.Timestamp <= endDate);
            return customRangeData.Average(e => e.DataValue);
        }
    }
}
