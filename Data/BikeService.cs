using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cykeluthyrning.Data
{
    public class BikeService
    {
        private List<Bike> bikes;
        public event Action<Bike> BikeDeleted;

        public BikeService()
        {
            LoadDataFromJson();
        }

        public List<Bike> GetBikes()
        {
            return bikes;
        }

        public void AddBikes(Bike bike)
        {
            bikes.Add(bike);
            SaveDataToJson();
        }

        public void ChangeBikeStatus(Bike bike, Enums.Status status)
        {
            bike.Status = status;
            SaveDataToJson();
        }

        public void DeleteBike(Bike bike)
        {
            bikes.Remove(bike);
            SaveDataToJson();
            BikeDeleted?.Invoke(bike);
        }

        public void RentBike(Bike bike, string customernumber, string firstname, string lastname, string phone)
        {
            bike.LastRented = DateTime.Now;
            bike.Status = Enums.Status.Uthyrd;
            bike.LastCustomerNumber = customernumber;
            bike.LastCustomerName = $"{firstname} {lastname}";
            bike.LastCustomerPhone = phone;
            SaveDataToJson();
        }

        private void LoadDataFromJson()
        {
            var dataPath = "data.json";

            if (File.Exists(dataPath))
            {
                var dataJson = File.ReadAllText(dataPath);
                bikes = JsonSerializer.Deserialize<List<Bike>>(dataJson);
            }
            else
            {
                bikes = new List<Bike>();
            }
        }

        private void SaveDataToJson()
        {
            var dataPath = "data.json";
            var dataJson = JsonSerializer.Serialize(bikes);
            File.WriteAllText(dataPath, dataJson);
        }
    }
}
