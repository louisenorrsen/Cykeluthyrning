using Enums;

namespace Cykeluthyrning.Data
{
    public class Bike
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public Enums.Type Type { get; set; }
        public Enums.Status Status { get; set; }
        public DateTime? LastRented { get; set; }
        public string? LastCustomerName { get; set; }
        public string? LastCustomerNumber { get; set; }
        public string? LastCustomerPhone { get; set; }

        public Bike(int id, int size, Enums.Type type)
        {
            Id = id;
            Size = size;
            Type = type;
            Status = Status.Ledig;
        }
    }
}
