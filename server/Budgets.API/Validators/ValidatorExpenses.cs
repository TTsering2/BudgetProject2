using System.Text.RegularExpressions;




/// <summary>
/// Contains methods to validate expense properties.

public class ValidatorExpenses
{
    /// <summary>
    /// Validates the title of an expense.
    /// </summary>
    /// <param name="title">The title to validate.</param>
    /// <returns>True if the title is valid, otherwise false.</returns>
    public static bool ValidateTitle(string title)
    {
        if (Regex.IsMatch(title, @"[!@#$%^&*]") || title == "" || title == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Validates the type of an expense.
    /// </summary>
    /// <param name="type">The type to validate.</param>
    /// <returns>True if the type is valid, otherwise false.</returns>
    public static bool ValidateType(string type)
    {
        if (Regex.IsMatch(type, @"[!@#$%^&*]") || type == "" || type == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Validates the amount of an expense.
    /// </summary>
    /// <param name="amount">The amount to validate.</param>
    /// <returns>True if the amount is valid, otherwise false.</returns>
    public static bool ValidateAmount(decimal amount)
    {
        if (amount < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Validates all properties of an expense.
    /// </summary>
    /// <param name="title">The title to validate.</param>
    /// <param name="type">The type to validate.</param>
    /// <param name="amount">The amount to validate.</param>
    /// <returns>True if all properties are valid, otherwise false.</returns>
    public static bool ValidateAll(string title, string type, decimal amount)
    {
        if (ValidateTitle(title) && ValidateType(type) && ValidateAmount(amount))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}