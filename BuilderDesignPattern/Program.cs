namespace BuilderDesignPattern;

public class Program
{
    class Car
    {
        public string? Type { get; set; }
        public string? Model { get; set; }
        public double Engine { get; set; }
        public string? Make { get; set; }
        public int Seats { get; set; }
        public bool HasGPS { get; set; }
        public bool HasTripComputer { get; set; }

        public override string ToString()
=> @$"
        Model {Model}
        Engine {Engine}
        Make {Make}
        Seats {Seats}
        HasGPS {HasGPS}
        HasTripComputer {HasTripComputer}
      ";

        public Car GetResult()
        {
            return new Car();
        }

    }
    interface IBuilder
    {
        Car Car { get; set; }
        IBuilder SetSeats(int number);
        IBuilder SetModel(string model);
        IBuilder SetMake(string make);
        IBuilder SetEngine(double engine);
        IBuilder SetTripComputer();
        IBuilder SetGPS();
        void Reset();
        Car Build();
    }
    class CarBuilder : IBuilder
    {
        public Car Car { get; set; } = new Car() { Type = "Automatic" };

        public Car GetResult()
        {
            return Car;
        }

        public void Reset() => Car = new Car();


        public IBuilder SetEngine(double engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetGPS()
        {
            Car.HasGPS = true;
            return this;
        }

        public IBuilder SetMake(string make)
        {
            Car.Make = make;
            return this;
        }

        public IBuilder SetModel(string model)
        {
            Car.Model = model;
            return this;
        }

        public IBuilder SetSeats(int seats)
        {
            Car.Seats = seats;
            return this;
        }

        public IBuilder SetTripComputer()
        {
            Car.HasTripComputer = true;
            return this;
        }
        public Car Build() => Car;

    }
    class CarManualBuilder : IBuilder
    {
        public Car Car { get; set; } = new Car { Type = "Manual" };

        public Car GetResult()
        {
            return Car;
        }

        public void Reset() => Car = new Car();


        public IBuilder SetEngine(double engine)
        {
            Car.Engine = engine;
            return this;
        }

        public IBuilder SetGPS()
        {
            Car.HasGPS = true;
            return this;
        }

        public IBuilder SetMake(string make)
        {
            Car.Make = make;
            return this;
        }

        public IBuilder SetModel(string model)
        {
            Car.Model = model;
            return this;
        }

        public IBuilder SetSeats(int seats)
        {
            Car.Seats = seats;
            return this;
        }

        public IBuilder SetTripComputer()
        {
            Car.HasTripComputer = true;
            return this;
        }
        public Car Build() => Car;
    }
    class Director
    {
        public void MakeSUV(IBuilder builder)
        {
            builder.Reset();
            builder.SetMake("Mazda");
            builder.SetModel("MX-5");
            builder.Reset();
            builder.SetSeats(4);
            builder.SetEngine(2.0);
            builder.SetTripComputer();
            builder.SetGPS();
        }
        public void MakeSportCars(IBuilder builder)
        {
            builder.Reset();
            builder.SetMake("McLaren ");
            builder.SetModel("720S");
            builder.SetSeats(2);
            builder.SetEngine(3.5);
            builder.SetTripComputer();
            builder.SetGPS();
        }
    }
    static void Main(string[] args)
    {


        Director director = new Director();
        CarBuilder builder = new CarBuilder();
        director.MakeSportCars(builder);
        Car car = builder.GetResult();
        Console.WriteLine(car);


        IBuilder builder1 = new CarBuilder();
        Car carAutomatic = builder1
            .SetMake("Mercedes-Benz")
            .SetModel("A-class")
            .SetEngine(3.5)
            .SetGPS()
            .SetSeats(5)
            .Build();
        Console.WriteLine(carAutomatic);

        IBuilder builder2 = new CarManualBuilder();
        Car carManual= builder2
            .SetMake("Lada")
            .SetModel("Niva")
            .SetSeats(5)
            .SetEngine(1.6)
            .Build();
        Console.WriteLine(carManual);
    }
}