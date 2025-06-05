using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPatternDemo
{
    public interface IBike
    {
        void GetDetails();
    }

    public class RegularBike : IBike
    {
        public void GetDetails()
        {
            Console.WriteLine(" Regular Bike Details ");
        }
    }


    public class SportrBike : IBike
    {
        public void GetDetails()
        {
            Console.WriteLine("Race Bike Details ");
        }
    }

    public interface ICar
    {
        void GetDetails();
    }
    public class RegularCar : ICar
    {
        public void GetDetails()
        {
            Console.WriteLine(" Regular car Details ");
        }
    }


    public class SportsCar : ICar
    {
        public void GetDetails()
        {
            Console.WriteLine("Sports Car Details ");
        }
    }


   public interface IVehicleFactory
    {
        //abstract 
        IBike CreateBike();
        ICar CreateCar();
    }


    public class RegularVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new RegularBike();
        }

            public ICar CreateCar()
        {
           return new RegularCar();
        }
    }
    public class SportsVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new SportrBike();
        }

        public ICar CreateCar()
        {
            return new SportsCar();
        }
    }



}
