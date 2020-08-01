using System.Collections.Generic;
using OdeToFood.Data;
using System.Linq;
using OdeToFood.Core;
using static OdeToFood.Core.Restaurant;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
         IEnumerable<Restaurant> GetRestaurantsByname(string name);        
         Restaurant GetById(int restaurantId);
    }
  
    public class InMemoryResturantData : IRestaurantData 
    {
         readonly List<Restaurant> restaurants;
        public InMemoryResturantData()
        {
            restaurants = new List<Restaurant>() 
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Willian's Burgues", Location = "London", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "Smith Paladin", Location = "California", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 4, Name = "Dominos Pizza", Location = "Rio de Janeiro", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 5, Name = "Amazon Restaurant", Location = "California", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 6, Name = "IhalaIhala", Location = "Paris", Cuisine = CuisineType.None },
            };

        }

        public Restaurant GetById(int id) 
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
        public IEnumerable<Restaurant> GetRestaurantsByname(string name = null) 
        {
            return from r in restaurants    
                    where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                    orderby r.Name 
                    select r;                  
        }
    }
}