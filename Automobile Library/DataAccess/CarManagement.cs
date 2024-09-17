using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFramework;

namespace Automobile_Library.DataAccess
{
    public class CarManagement
    {
        private static CarManagement instance=null;
        private static readonly object instanceLock= new object();
        private CarManagement();
        public static CarManagement Instance { 
            get {
                lock (instanceLock) { 
                    if (instance==null)
                        instance = new CarManagement();
                    return instance;
                }       
            } 
        }
        //----------------------------------------
        public IEnumerable<Car> GetCarList()
        {
            List<Car> cars;
            try
            {
                var myStockDB = new MyStockContext();
                cars = myStockDB.Cars.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.message);
               
            }
            return cars;
        }
        //------------------------------------------

        public Car GetCarByID(int carID)
        {
            Car car=null;
            try
            {
                var myStockDB= new MyStockContext();
                car= myStockDB.Cars.SingleOrDefault(car=> car.CarID==carID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.message);

            }
            return car;
        }
        //-----------------------

        public void AddNew(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if(_car==null)
                {
                    var mystockDB= new MyStockContext();
                    mystockDB.Cars.Add(car);
                    mystockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This car has already existed");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //--------------------

        public void UpdateCar(Car car)
        {
            try
            {
                Car _car=GetCarByID(car.CarId);
                if(_car!=null)
                {
                    var mystockDB = new MyStockContext();
                    mystockDB.Entry<Car>(car).State = EntityState.Modified;
                    mystockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This car does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }
        //-------------------

        public void Remove(Car car)
        {
            try
            {
                Car _car = GetCarByID(car.CarId);
                if (_car != null)
                {
                    var mystockDB = new MyStockContext();
                    mystockDB.Cars.Remove(_car);
                    mystockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This car does not exist!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
