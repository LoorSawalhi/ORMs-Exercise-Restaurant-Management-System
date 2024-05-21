using RestaurantReservation.CustomException;

namespace RestaurantReservation;

using System.Globalization;

internal abstract class Utilities
{
    private const string InvalidOption = "Invalid Option !!! Try again.";
    private static int _inputLine;

    public static void Menu()
    {
        InputHandling.HandleUserInput<NotValidUserInputException>(() =>
            {
                Console.Write("""
                              Hi, Choose your option:
                              1) List all managers
                              2) Get reservations by customer id
                              3) List orders and menu items by reservation id
                              4) List ordered menu items by reservation id
                              5) Calculates the average order amount for a specific employee

                              Option : 
                              """);
                _inputLine = ReadOption();
                Options(_inputLine);
            });
    }

    private static void Options(int option)
    {
            switch (option)
            {
                case 1:
                    // GetAllManagers();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    throw new NotValidUserInputException(InvalidOption);
            }
    }

    public static int ReadOption()
    {
        var readLine = Console.ReadLine();
        Console.WriteLine();
        if (readLine == null || !int.TryParse(readLine, out var option))
            throw new NotValidUserInputException(InvalidOption);

        return option;
    }

    public static string ReadString(string message)
    {
        Console.Write(message);
        var readLine = Console.ReadLine();
        Console.WriteLine();
        if (readLine == null)
            throw new EmptyStringException("Empty Input!!");

        return readLine;
    }

    public static float ReadPrice(string message)
    {
        Console.Write(message);
        var readLine = Console.ReadLine();
        Console.WriteLine();
        if (readLine == null || !float.TryParse(readLine, out var price) || price < 0)
            throw new NotValidUserInputException("Invalid Price");

        return price;
    }

    public static DateTime ReadDate()
    {
        Console.Write("""
                      Please enter a date in the format 2001-01-30
                      
                      Date :
                      """);
        var input = Console.ReadLine();

        if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            return date;

        throw new NotValidUserInputException("Wrong Date Format!!");
    }
}