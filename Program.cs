using System;
using Avalonia;

class Program
{
    static void Main(string[] args)
    {
        Simulare simulare = new Simulare();
        simulare.Initializeaza();
        simulare.Ruleaza(10); // Run the simulation for 10 steps

        Ecosistem.Instance.PlotData(); // Plot the data after the simulation
    }
}