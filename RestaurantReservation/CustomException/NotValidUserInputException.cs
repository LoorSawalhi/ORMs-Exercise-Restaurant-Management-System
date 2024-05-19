namespace RestaurantReservation.CustomException;

public abstract class NotValidUserInputException(string message) : Exception(message);