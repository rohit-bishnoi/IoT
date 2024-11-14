using IoT.Models;

namespace IoT.Services
{
    public class SimulateDataService
    {
        public static List<DataEntry> GenerateMockData()
        {
            var dataEntries = new List<DataEntry>();
            var random = new Random();

            // Generate data for the last 15 days up to the current date
            for (int i = 15; i >= 1; i--)
            {
                int entriesCount = random.Next(5, 50); // Random number of entries between 5 and 50 for each day

                for (int j = 0; j < entriesCount; j++)
                {
                    dataEntries.Add(new DataEntry
                    {
                        Timestamp = DateTime.Today.AddDays(-i).AddMinutes(random.Next(0, 1440)), // Random time within the day
                        DataValue = random.Next(1, 100) // Random value between 1 and 100
                    });
                }
            }

            return dataEntries;
        }

    }
}
