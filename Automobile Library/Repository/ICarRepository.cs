using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automobile_Library.DataAccess;

namespace Automobile_Library.Repository
{
    public class ICarRepository
    {
        IEnumerable<Car> GetCar();
        void InsertCar(Car car);
        void DeleteCar(Car car);
        void UpdateCar(Car car);
    }
}
