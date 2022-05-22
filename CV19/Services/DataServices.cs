using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CV19.Models;

namespace CV19.Services
{
    public class DataServices
    {
        private const string data_url = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }
        private static IEnumerable<string> GetDataLines()
        {
            var data_stream = Task.Run(GetDataStream).Result;
            var data_reader = new StreamReader(data_stream);
            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();
                if (string.IsNullOrEmpty(line)) continue;
                yield return line.Replace("Korea, ", "Korea -").Replace("Helena,", "Helena -").Replace("Bonaire,", "Bonaire -");
            }
        }
        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();
        private static IEnumerable<(string Country, string Province,(double Lat, double Lon) Plase, int[] Counts)> GetCountriesData()
        {
            var lines = GetDataLines()
                .Skip(1)
                .Select(line => line.Split(','));

            foreach (var row in lines)
            {
                var province = row[0].Trim();
                var countryName = row[1].Trim(' ', '"');
                var latitude = row[2] == "" ? 0 : double.Parse(row[2], CultureInfo.InvariantCulture);
                var longitude = row[3] == "" ? 0 : double.Parse(row[3], CultureInfo.InvariantCulture);
                var counts = row.Skip(4)
                    .Select(int.Parse)
                    .ToArray();
                yield return (countryName, province,(latitude, longitude), counts);
            }
        }
        public IEnumerable<CountryInfo> GetData()
        {
            var dates = GetDates();
            var countries = GetCountriesData().GroupBy(d => d.Country);
            foreach(var country_inf in countries)
            {
                var country = new CountryInfo
                {
                    Name = country_inf.Key,
                    ProvinceCounts = country_inf.Select(c => new PlaseInfo
                    {
                        Name = c.Country,
                        Location = new Point(c.Plase.Lat, c.Plase.Lon),
                        Counts = dates.Zip(c.Counts, (date, count) => new ConfirmedCount { Count=count, Date=date })
                    }),
                };
                yield return country;
            }
        }
    }
}
