namespace RestaurantReservation.CustomException;

public sealed class EmptyQueryResultException(string message) : Exception(message);