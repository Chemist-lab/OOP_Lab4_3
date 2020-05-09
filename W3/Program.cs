using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace W3
{
    class Program
    {
        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";
        static void WeatherData()
        {
            while(true)
            {
                Console.WriteLine("             FAQ\n\n" +
                    "Add weather data - press 'A'\nSearch weather data - press 'S'" +
                    "\nShow all data - press 'T'\nClear console  - press 'Spacebar'\nExit - press 'Esc'");
                var data = JsonConvert.DeserializeObject<List<Weather_Data>>(File.ReadAllText(FilePath));
                if (Console.ReadKey().Key == ConsoleKey.A)
                {
                    Console.Clear();

                    Console.WriteLine("Enter Weather Data\n");
                    Console.WriteLine("Date(date format - YY.MM.DD): ");
                    string date = Console.ReadLine();
                    Console.WriteLine("City: ");
                    string city = Console.ReadLine();
                    Console.WriteLine("Pressure: ");
                    string pressure = Console.ReadLine();
                    Console.WriteLine("Temperature: ");
                    string temperature = Console.ReadLine();
                    Console.WriteLine("Wind Speed: ");
                    string windS = Console.ReadLine();

                    if (date != null && city != null && pressure != null && temperature != null && windS != null)
                    {
                        data.Add(new Weather_Data { Date = date, Сity = city, Pressure = pressure, Temperature = temperature, WindSpeed = windS });
                    }
                    else
                    {
                        Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                    }
                    Console.Clear();
                }

                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                }
                if (Console.ReadKey().Key == ConsoleKey.S)
                {
                    Console.Clear();
                    Console.WriteLine("Enter search city: ");
                    string city = Console.ReadLine();
                    if (Console.ReadLine() != null)
                    {
                        Console.Clear();
                        Weather_Data FoundData = data.Find(found => found.Сity == city);
                        Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                        Console.WriteLine("     Date    │    City    │ Pressure │ Temperature │  Wind speed");
                        Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                        Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", FoundData.Date,FoundData.Сity,FoundData.Pressure,FoundData.Temperature,FoundData.WindSpeed);
                        Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");


                        Console.WriteLine("\nTo edit press 'E'");
                        Console.WriteLine("\n\nTo edit press 'D'");
                        if (Console.ReadKey().Key == ConsoleKey.E)
                        {
                            Console.WriteLine("\nEdit Weather Data\n");
                            Console.WriteLine("Date(date format - YY.MM.DD): ");
                            string date = Console.ReadLine();
                            Console.WriteLine("City: ");
                            string citi = Console.ReadLine();
                            Console.WriteLine("Pressure: ");
                            string pressure = Console.ReadLine();
                            Console.WriteLine("Temperature: ");
                            string temperature = Console.ReadLine();
                            Console.WriteLine("Wind Speed: ");
                            string windS = Console.ReadLine();

                            if (date ==null || citi == null || pressure == null || temperature == null || windS ==null)
                            {
                                Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                            }
                            FoundData.Date = date;
                            FoundData.Сity = citi;
                            FoundData.Pressure = pressure;
                            FoundData.Temperature = temperature;
                            FoundData.WindSpeed = windS;
                            Console.Clear();
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                            Console.WriteLine("     Date    │    City    │ Pressure │ Temperature │  Wind speed");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                            Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", FoundData.Date, FoundData.Сity, FoundData.Pressure, FoundData.Temperature, FoundData.WindSpeed);
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                        }
                        if (Console.ReadKey().Key == ConsoleKey.D)
                        {
                            data.RemoveAll(x => x.Сity == city);
                        }
                    }
                }

                if (Console.ReadKey().Key == ConsoleKey.T)
                {
                    Console.Clear();
                    Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                    Console.WriteLine("     Date    │    City    │ Pressure │ Temperature │  Wind speed");
                    Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                    for (int i = 0; i < data.Count; i++)
                    {
                        Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", data[i].Date, data[i].Сity, data[i].Pressure, data[i].Temperature, data[i].WindSpeed);
                        Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");

                    }
                    Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                    Console.WriteLine("\nTo sort by date press 'S'");
                    if (Console.ReadKey().Key == ConsoleKey.S)
                    {
                        
                        Console.Clear();
                        List<Weather_Data> SortData = data.OrderBy(o => o.Date).ToList();
                        Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤══════════════╗");
                        Console.WriteLine("     Date    │    City    │ Pressure │ Temperature │  Wind speed");
                        Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                        for (int i = 0; i < data.Count; i++)
                        {
                            Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12}", SortData[i].Date, SortData[i].Сity, SortData[i].Pressure, SortData[i].Temperature, SortData[i].WindSpeed);
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪══════════════╣");
                        }
                        Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧══════════════╝");
                    }
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                    }
                }
                string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
                if (serialize.Count() > 1)
                {
                    if (!File.Exists(FileName))
                    {
                        File.Create(FileName).Close();
                    }
                    File.WriteAllText(FilePath, serialize, Encoding.UTF8);
                }
            } 
        }
        static void Main(string[] args)
        {
            WeatherData();
        }
    }

    public class Weather_Data
    {
        private string date;
        private string city;
        private string pressure;
        private string temperature;
        private string windSpeed;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Сity
        {
            get { return city; }
            set { city = value; }
        }
        public string Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        public string WindSpeed
        {
            get { return windSpeed; }
            set { windSpeed = value; }
        }

    }
}
