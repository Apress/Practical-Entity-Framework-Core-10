namespace EF10_InventoryManager.ConsoleHelpers;

public class UserInput
{
    private const int MAX_TRIES = 3;

    /// <summary>
    /// Get input from the user as a string
    /// </summary>
    /// <param name="prompt">text to present to the user</param>
    /// <param name="shouldConfirm">ability to reject given value for typo or changed mind</param>
    /// <returns>the value entered and optionally confirme by the user as a string</returns>
    public static string GetInputFromUser(string prompt, bool shouldConfirm)
    {
        bool confirmed = true;
        string response;

        do
        {
            //ask the question
            Console.WriteLine(prompt);

            //get a response and store it
            response = Console.ReadLine();

            if (shouldConfirm)
            {
                //confirm the response
                Console.WriteLine($"You said: {response}.  Is this correct [y/n]?");

                //what to do with the confirmation
                var confirmationResponse = Console.ReadLine();

                confirmed = confirmationResponse.StartsWith("y", StringComparison.OrdinalIgnoreCase);

                if (!confirmed)
                {
                    Console.WriteLine("Giving you another chance. Try again!");
                }
            }
        } while (!confirmed);

        return response;
    }

    /// <summary>
    /// Get input from the user as an integer
    /// </summary>
    /// <param name="prompt">The prompt to present to the user</param>
    /// <param name="shouldConfirm">the ability to correct back input or change the value</param>
    /// <param name="min">minimum acceptable value</param>
    /// <param name="max">maximum acceptable value</param>
    /// <returns>the value entered by the user and optionally confirmed as a valid integer in range</returns>
    public static int GetInputFromUser(string prompt, bool shouldConfirm, int min = int.MinValue, int max = int.MaxValue)
    {
        double value = GetInputFromUser(prompt, shouldConfirm, (double)min, (double)max);
        return (int)value;
    }

    /// <summary>
    /// Get input from the user as a double
    /// </summary>
    /// <param name="prompt">text to present to user</param>
    /// <param name="shouldConfirm">ability to say that the input was incorrect after gathering</param>
    /// <param name="min">minimum value allowed</param>
    /// <param name="max">maximum value allowed</param>
    /// <returns>the value entered by the user and optionally confirmed as a double in range</returns>
    public static double GetInputFromUser(string prompt, bool shouldConfirm, double min = double.MinValue, double max = double.MaxValue)
    {
        double returnValue = double.MinValue;

        for (int i = 0; i < MAX_TRIES; i++)
        {
            var response = GetInputFromUser(prompt, shouldConfirm);
            bool success = double.TryParse(response, out returnValue);
            if (success)
            {
                if (returnValue < min || returnValue > max)
                {
                    Console.WriteLine("Invalid Input.  Please try again!");
                    continue;
                }
                break;
            }

            if (i == MAX_TRIES - 1)
            {
                Console.WriteLine("Too many tries. Sorry");
            }
        }
        return returnValue;
    }

    /// <summary>
    /// Get input from a user as a boolean
    /// </summary>
    /// <param name="prompt">The text to present to the user</param>
    /// <param name="startsWithCheck">The text to validate for return true</param>
    /// <param name="shouldConfirm">The ability to validate the input was correctly gathered</param>
    /// <returns>true if input matches startsWithCheck, otherwise false</returns>
    public static bool GetInputFromUserBool(string prompt, string startsWithCheck, bool shouldConfirm)
    {
        var response = GetInputFromUser(prompt, shouldConfirm);
        return response.StartsWith(startsWithCheck, StringComparison.OrdinalIgnoreCase);
    }
}