using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace motorok
{
    public class FileServices
    {
        public List<Data> Reading(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            var allProducts = new List<Data>();
            foreach (var line in lines.Skip(1))
            {
                var row = line.Replace(", ", ",");
                var data = row.Split(',');

                var newProduct = new Data();
                newProduct.Id = int.Parse(data[0]);
                newProduct.Name = data[1];
                newProduct.Quantity = int.Parse(data[2]);
                newProduct.Price = decimal.Parse(data[3].Replace(".", ","));
                allProducts.Add(newProduct);
            }
            return allProducts;
        }
        public void FileWrite(decimal Price, int Quantity, int recordId)
        {
            
            List<string> lines = File.ReadAllLines("bikes.csv").ToList();
            for (int i = 1; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split(',');

                // Az ID megtalálása a sorban
                if (int.TryParse(parts[0], out int id) && id == recordId)
                {
                    // A quantity és price frissítése
                    parts[3] = Quantity.ToString();
                    parts[4] = Price.ToString();

                    // Az eredmény visszaírása a listába
                    lines[i] = string.Join(",", parts);
                    File.WriteAllLines("bikes.csv", lines);

                    // Az azonosító beállítása a data objektumban
                    var data = new Data
                    {
                        Id = recordId,
                        Name = parts[1],
                        Quantity = Quantity,
                        Price = Price
                    };

                    // A megfelelő rekord megtalálása után nincs szükség további iterációra
                    break;
                }
            }
        }

    }
}