using System;
using System.Collections.Generic;
using System.Text;
using MyOdeToFood.Core;

namespace MyOdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Create(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int GetCountOfRestaurants();
        int Commit();
    }
}
