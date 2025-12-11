using System.Text;

namespace EF10_NewFeatureDemos.ConsoleHelpers;
public class MenuGenerator
{
    public static string GenerateMenu(string menuHeader, string menuPrompt, List<string> menuLines, int lineLength)
    {
        var sb = new StringBuilder();
        //Header
        sb.AppendLine(new string('*', lineLength));
        sb.AppendLine(menuHeader);
        sb.AppendLine(new string('*', lineLength));
        //prompt
        sb.AppendLine($"* {menuPrompt}");
        sb.AppendLine(new string('-', lineLength));
        //menu
        int i = 1;
        foreach (var line in menuLines)
        {
            sb.AppendLine($"{i++}] {line}");
        }
        sb.AppendLine(new string('*', 40));
        return sb.ToString();
    }

}