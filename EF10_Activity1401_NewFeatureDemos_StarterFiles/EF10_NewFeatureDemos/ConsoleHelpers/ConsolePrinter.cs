using System.Text;

namespace EF10_NewFeatureDemos.ConsoleHelpers;

public class ConsolePrinter
{
    public static string PrintBoxedList<T>(IEnumerable<T> items,
                                            Func<T, string>? formatter = null,
                                            string title = "Results",
                                            int width = 60)
    {
        formatter ??= (x => x?.ToString() ?? string.Empty);

        var sb = new StringBuilder();

        // Top border
        sb.AppendLine(new string('*', width));

        // Title
        if (!string.IsNullOrWhiteSpace(title))
        {
            sb.AppendLine(title);
            sb.AppendLine(new string('-', width));
        }

        // Items
        foreach (var item in items)
        {
            sb.AppendLine(formatter(item));
            sb.AppendLine(new string('-', width));
        }

        // Bottom border
        sb.AppendLine(new string('*', width));

        return sb.ToString();
    }

    public static string PrintFormattedMessage(string message, string title, int width = 60)
    {
        var sb = new StringBuilder();
        sb.AppendLine(new string('*', width));
        sb.AppendLine(title);
        sb.AppendLine(new string('-', width));
        sb.AppendLine(message);
        sb.AppendLine(new string('*', width));
        return sb.ToString();
    }
}

