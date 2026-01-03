using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementSystem.Models.Locations
{
    public class Street
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;


        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; } = null!;
    }
}
