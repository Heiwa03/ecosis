using System;
using Gtk;

class Program
{
    static void Main(string[] args)
    {
        Application.Init();

        Simulare simulare = new Simulare();
        simulare.Initializeaza();
        simulare.Ruleaza(10); // Run the simulation for 10 steps

        Ecosistem.Instance.PlotData(); // Plot the data after the simulation
    }
}