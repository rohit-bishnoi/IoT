namespace IoT.Services.Interfaces
{
    public interface IIoTDataService
    {
        IEnumerable<object> GetDailyAverages();
        double GetWeeklyAverage();
        double GetCustomAverage(DateTime startDate, DateTime endDate);
    }
}
