using System;
using System.Reflection;

class Source
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

class Destination
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
}

class Program
{
    static void Main()
    {
        // Step 1: Create instances of Source and Destination classes
        Source sourceObject = new Source
        {
            Id = 5,
            Name = "Product",
            Price = 60.50
        };

        Destination destinationObject = new Destination();

        // Step 2: Call the MapProperties method to map properties
        MapProperties(sourceObject, destinationObject);

        // Step 3: Display the value of properties in the Destination class
        Console.WriteLine("Mapped Properties:");
        Console.WriteLine($"Id: {destinationObject.Id}");
        Console.WriteLine($"Name: {destinationObject.Name}");
        Console.WriteLine($"Price: {destinationObject.Price}");
        Console.WriteLine($"Description: {destinationObject.Description ?? "N/A"}");
    }

    // Step 2: Implement Dynamic Property Mapping using Reflection
    static void MapProperties(Source source, Destination destination)
    {
        PropertyInfo[] sourceProperties = typeof(Source).GetProperties();
        PropertyInfo[] destinationProperties = typeof(Destination).GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            var matchingDestinationProperty = Array.Find(destinationProperties, prop => prop.Name == sourceProperty.Name);

            if (matchingDestinationProperty != null && matchingDestinationProperty.PropertyType == sourceProperty.PropertyType)
            {
                // Map the property value from source to destination
                matchingDestinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }
    }
}
