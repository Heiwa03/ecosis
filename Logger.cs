using System;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Avalonia;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

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

        var scatterSeries = new OxyPlot.Series.ScatterSeries { MarkerType = MarkerType.Circle };

        foreach (var log in detailedLogs)
        {
            scatterSeries.Points.Add(new ScatterPoint(log.position.x, log.position.y, 5, 1, log.action));
        }

        plotModel.Series.Add(scatterSeries);

        var plotView = new PlotView
        {
            Model = plotModel
        };

        var window = new Window
        {
            Title = "Ecosystem Actions Plot",
            Width = 800,
            Height = 600,
            Content = plotView
        };

        window.Show();
        AppBuilder.Configure<App>().UsePlatformDetect().StartWithClassicDesktopLifetime(new string[0]);
    }
}

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
}