using System;

public class Vehicle
{
    private readonly string _registrationNumber;

    /*
    public Vehicle()
    {
        Console.WriteLine("Vehicle is being initialised");
    }
    */

    public Vehicle(string registrationNumber)
    {
        _registrationNumber = registrationNumber;
        Console.WriteLine("Vehicle is being initialised: " + registrationNumber);
    }
}
