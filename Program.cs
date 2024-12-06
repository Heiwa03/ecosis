using System;
using System.Collections.Generic;
using System.Linq;

// Main program loop
class Program
{
    static void Main(string[] args)
    {
        Simulare simulare = new Simulare();
        simulare.Initializeaza();
        simulare.Ruleaza(1000); // Run the simulation for 10 steps
    }
}