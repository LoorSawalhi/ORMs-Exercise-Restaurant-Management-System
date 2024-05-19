namespace RestaurantReservation.CustomException;
public sealed class NotValidUserInputException(string message) : Exception(message);