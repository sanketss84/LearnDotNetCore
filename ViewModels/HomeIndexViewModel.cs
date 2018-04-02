using System.Collections.Generic;
using firstApp.Models;

namespace firstApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants {get; set;}
        
        public string CurrentMessage { get; set; }

    }

}