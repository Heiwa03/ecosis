using System;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.GtkSharp;
using Gtk;

public class Logger
{
    private List<string> logs;
    private List<(string action, (int x, int y) position, string details)> detailedLogs;

    public Logger()
    {
        logs = new List<string>();
        detailedLogs = new List<(string action, (int x, int y) position, string details)>();
    }

    public void LogAction(string action, (int x, int y) position, string details)
    {
        string logEntry = $"{DateTime.Now}: {action} at ({position.x}, {position.y}) - {details}";
        logs.Add(logEntry);
        detailedLogs.Add((action, position, details));
        Console.WriteLine(logEntry);
    }

    public void GenerateReport()
    {
        foreach (var log in logs)
        {
            Console.WriteLine(log);
        }
    }

    public void PlotData()
    {
        var plotModel = new PlotModel { Title = "Ecosystem Actions" };

        var scatterSeries = new ScatterSeries { MarkerType = MarkerType.Circle };

        foreach (var log in detailedLogs)
        {
            scatterSeries.Points.Add(new ScatterPoint(log.position.x, log.position.y, 5, 1, log.action));
        }

        plotModel.Series.Add(scatterSeries);

        var plotView = new PlotView
        {
            Model = plotModel
        };

        var window = new Window("Ecosystem Actions Plot")
        {
            DefaultWidth = 800,
            DefaultHeight = 600
        };

        window.Add(plotView);
        window.ShowAll();
        window.DeleteEvent += (o, args) => Application.Quit();

        Application.Run();
    }
}