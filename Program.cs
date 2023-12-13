using motorok;
using System.Diagnostics;

var filePath = "Bikes.csv";

var fileservice = new FileServices();
var allProducts = fileservice.Reading(filePath);
var bike = SelectPhone();
var data = new Data();



Data SelectPhone()
{
    do
    {
        Console.WriteLine("Melyik telefon árát szeretnénk módosítani? (Id)");
        if (int.TryParse(Console.ReadLine(), out int productId))
        {
            var product = allProducts.FirstOrDefault(product => product.Id == productId);
            if (fileservice is not null)
                return product;

            Console.WriteLine("Bike not found!");
            continue;
        }

        Console.WriteLine("Wrong id!\r\n");
    } while (true);
}


Console.WriteLine("Give me a price: ");
int price = Convert.ToInt32(Console.ReadLine());
if (price >= 10000000)
{
    Console.WriteLine("Isn't this too much for you?");
    Environment.Exit(0);
}
else if (price <= 500000)
{
    Console.WriteLine("C'mon you really thought this is gonna be enough?");
    Environment.Exit(0);
}
Console.WriteLine("Give me a quantity number: ");
int quantity = Convert.ToInt32(Console.ReadLine());

fileservice.FileWrite(price,quantity,bike.Id);


Console.WriteLine($"Original data: {bike.Name}, {bike.Id}, {bike.Price}, {bike.Quantity}");
Console.WriteLine($"The updated data: {bike.Name}, {bike.Id}, {price}, {quantity}");

