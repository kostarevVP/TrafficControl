﻿using Lukomor.Domain.Features;
using Lukomor.Extentions;
using System.Text.RegularExpressions;

public class AnalyticLogService : Feature, IAnalyticService
{

    public void LogEvent(string name, string parameterName, string parameterValue) => 
        Print(name, parameterName, parameterValue);

    public void LogEvent(string name, string parameterName, double parameterValue) => 
        Print(name, parameterName, parameterValue.ToString());

    public void LogEvent(string name, string parameterName, long parameterValue) => 
        Print(name, parameterName, parameterValue.ToString());

    public void LogEvent(string name, string parameterName, int parameterValue) => 
        Print(name, parameterName, parameterValue.ToString());

    public void LogEvent(string name) => 
        Print(name, "NONE", "NONE");

    private void Print(string name, string parameterName, string parameterValue) => 
        Log.PrintWarning($"[ANALYTIC] " +
            $"name_{name} \n" +
            $"parameterName_{parameterName} \n" +
            $"parametrValue_{parameterValue} \n"
            , this);

    private string DeleteAllWhiteSpaces(string message)
    {
        string formattedMessage = Regex.Replace(message, @"\s+", "_"); // Replace spaces with underscores
        formattedMessage = formattedMessage.ToLower(); // Convert to lowercase

        return formattedMessage;
    }
}
