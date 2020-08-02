using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public partial class Restaurant
    {        
        public int Id { get; set; }

        [Required,StringLength(10)]
        public string Name { get; set; }

        [Required,StringLength(10)]
        public string  Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
