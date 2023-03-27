using dataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstraction
{
    public interface IRestaurant
    {
    bool AddRestaurant(Restaurant _restaurant);
        List<Restaurant> GetListRestaurant();
        Restaurant GetRestaurant(int Id);
        bool UpdateRestaurant(Restaurant restaurant);
        bool DeleteRestaurant(int Id);
    }
}
