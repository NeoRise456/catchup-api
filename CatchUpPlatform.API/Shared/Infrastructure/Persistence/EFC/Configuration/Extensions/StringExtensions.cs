using Humanizer;

namespace CatchUpPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// String extensions
/// </summary>
/// <remarks>
/// this class contains the extension methods for string.
/// </remarks>
public static class StringExtensions
{
    
    /// <summary>
    /// Conver String to Snake Case
    /// </summary>
    /// <param name="text"> The string to convert </param>
    /// <returns>the string in Snake Case format </returns>
    public static string ToSnakeCase(this string text)
    {
        return new string(Convert(text.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;

            yield return char.ToLower(e.Current);

            while (e.MoveNext())
                if (char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
        }
    }
    
    /// <summary>
    /// Conversion of string to plural
    /// </summary>
    /// <param name="text"> The string to convert </param>
    /// <returns> the string in plural </returns>
    public static string ToPlural(this string text)
    {
        return text.Pluralize(false);
    }

}