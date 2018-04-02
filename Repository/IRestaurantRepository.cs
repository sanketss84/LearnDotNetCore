using firstApp.Models;
using System.Collections.Generic;

namespace firstApp.Repository
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAll();
    }
    
}