using System.Collections.Generic;
using System.Linq;
using firstApp.Models;

namespace firstApp.Repository
{
    public class InMemoryRestaurantRepository : IRestaurantRepository
    {
        List<Restaurant> _restaurants;
        
        public InMemoryRestaurantRepository()
        {
            _restaurants = new List<Restaurant> {
                new Restaurant { Id = 1 , Name = "Over Story"},
                new Restaurant { Id = 2 , Name = "Joeys Pizza"},
                new Restaurant { Id = 3 , Name = "Dominos Pizza"}
            };
        }

        // Remember a list is not thread safe
        // A single instance across multiple requests and we can run into threading issues.
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }
    }
    
}