using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automobile_Library.DataAccess;
namespace Automobile_Library.Repository
{
    public class CarRepository: ICarRepository
    {
        public Car GetCarByID(int carId) => CarManagement.Instance.GetCarByID(carId);

        public IEnumerable<Car> GetCars() => CarManagement.Instance.GetCarList();

        public void InsertCar(Car carId) => CarManagement.Instance.AddNew(carId);

        public void UpdateCar(Car carId) => CarManagement.Instance.UpdateCar(carId);

        public void DeleteCar(int carId) => CarManagement.Instance.Remove(carId);
    }
}
