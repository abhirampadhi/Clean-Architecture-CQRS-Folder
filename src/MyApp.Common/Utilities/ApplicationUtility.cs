namespace MyApp.Common.Utilities;
public class ApplicationUtility
{
    public static string RemoveSpaces(string input)
    {
        return input.Replace(" ", string.Empty);
    }
}
