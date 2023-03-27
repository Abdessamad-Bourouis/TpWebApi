using BLL.Abstraction;
using dataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class RestaurantRepository : IRestaurant
    {
        private readonly AppDBContext _appDBContext;

        public RestaurantRepository(AppDBContext appDBContext) 
        {
            _appDBContext = appDBContext;
        }
        

        public bool AddRestaurant(Restaurant _restaurant)
        {
            try
            {
                 _appDBContext.Restaurant.Add(_restaurant);
                 _appDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public  bool DeleteRestaurant(int Id)
        {
            var restaurant = GetRestaurant(Id);
            if (restaurant != null)
            {
                _appDBContext.Restaurant.Remove(restaurant);
                _appDBContext.SaveChanges();
                return true;
            }

            return false;
        }
            
        public List<Restaurant> GetListRestaurant()
        {
            return _appDBContext.Restaurant.ToList();
        }

        public Restaurant GetRestaurant(int Id)
        {
            var restaurant = _appDBContext.Restaurant.Where(x => x.Id == Id).FirstOrDefault();
            if (restaurant == null)
                return new Restaurant();
            return restaurant;
        }

        public bool UpdateRestaurant(Restaurant restaurant)
        {
            var res = GetRestaurant(restaurant.Id);
            if (res == null)
                return false;

            res.Name = restaurant.Name;
            res.Description = restaurant.Description;
            _appDBContext.Restaurant.Add(res);
            _appDBContext.SaveChanges();
            return true;
        }
        
    }
}
