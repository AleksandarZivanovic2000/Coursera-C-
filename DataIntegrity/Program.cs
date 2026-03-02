using System;
using System.Text.Json;

public class Person
{
    public string UserName { get; set; }
    public int UserAge { get; set; }
}

public class Program
{
    public static void Main()
    {
        try
        {
            var jsonData = "{\"UserName\": \"Dana\"}";
            var deserializedPerson = JsonSerializer.Deserialize<Person>(jsonData);

            if (string.IsNullOrEmpty(deserializedPerson.UserName))
                throw new Exception("UserName is required");

            Console.WriteLine("Data Integrity Verified");
            Console.WriteLine($"UserName: {deserializedPerson.UserName}, UserAge: {deserializedPerson.UserAge}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during deserialization: {ex.Message}");
        }
    }
}