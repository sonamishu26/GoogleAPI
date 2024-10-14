using Microsoft.Extensions.Configuration;
using System;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string clientId = config["ClientId"];
        string clientSecret = config["ClientSecret"];

        KeepServiceHelper keepServiceHelper = new KeepServiceHelper(clientId, clientSecret);
        keepServiceHelper.ListNotes();
    }
}
