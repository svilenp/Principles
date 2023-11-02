namespace Examples.Mocks;

public static class MockAddressBook
{
    //public static IEnumerable<string> Addresses => new List<string>
    //{
    //    "",
    //    "",
    //}

    private static Random random = new Random();

    public static List<string> Addresses(int numberOfAddresses)
    {
        List<string> addresses = new List<string>();

        for (int i = 0; i < numberOfAddresses; i++)
        {
            string address = GenerateRandomAddress();
            addresses.Add(address);
        }

        return addresses;
    }

    private static string GenerateRandomAddress()
    {
        string[] streetNames = { "Main St", "Elm St", "Oak Ave", "Maple Ln", "Cedar Rd" };
        string[] cities = { "New York", "Los Angeles", "Chicago", "Houston", "Miami" };
        string[] states = { "CA", "NY", "TX", "FL", "IL" };
        string[] zipCodes = { "10001", "90001", "60601", "77001", "33101" };

        string streetName = streetNames[random.Next(streetNames.Length)];
        int streetNumber = random.Next(1, 1000);
        string city = cities[random.Next(cities.Length)];
        string state = states[random.Next(states.Length)];
        string zipCode = zipCodes[random.Next(zipCodes.Length)];

        return $"{streetNumber} {streetName}, {city}, {state} {zipCode}";
    }
}
