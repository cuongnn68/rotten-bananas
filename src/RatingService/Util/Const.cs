namespace RatingService.Util;

public static class Const {
    public const string DATE_FORMAT = "dd/MM/yyyy";
    public const string DATE_TIME_FORMAT = "hh:mm:ss dd/MM/yyyy";

    public const string NEW_MOVIE_TOPIC = "new-movie";
    public const string NEW_USER_TOPIC = "new-user";
}

public static class Validator {
    public static bool IsDateValid(string input) {
        return DateTime.TryParseExact(
            input, 
            Const.DATE_FORMAT, 
            null, 
            System.Globalization.DateTimeStyles.None, 
            out _);
    }

        public static bool IsDateTimeValid(string input) {
        return DateTime.TryParseExact(
            input, 
            Const.DATE_TIME_FORMAT, 
            null, 
            System.Globalization.DateTimeStyles.None, 
            out _);
    }
}