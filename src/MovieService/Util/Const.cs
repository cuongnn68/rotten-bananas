namespace MovieService.Util;

public static class Const {
    public const string DATE_FORMAT = "dd/MM/yyyy";
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
}