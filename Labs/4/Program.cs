using _4.Parsing;
using _4.TextModel;

namespace _4
{
    internal static class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var text = LoadText();

            Console.WriteLine($"Загружено предложений: {text.Sentences.Count}");
            Console.WriteLine();

            var concordance = text.BuildConcordance();
            var lines = concordance.Format().ToList();

            const int previewLimit = 50;
            foreach (var line in lines.Take(previewLimit))
                Console.WriteLine(line);

            if (lines.Count > previewLimit)
                Console.WriteLine($"... показано {previewLimit} из {lines.Count}");

            Console.Write("Введите имя файла куда сохранить конкорданс (Enter - не сохранять): ");
            var name = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(name))
                return;

            File.WriteAllLines(name, lines, new System.Text.UTF8Encoding(false));
            Console.WriteLine($"Сохранено в {Path.GetFullPath(name)}");
        }

        private static Text LoadText()
        {
            Console.WriteLine("Источник текста:");
            Console.WriteLine("1 - Data/sample.txt");
            Console.WriteLine("2 - указать свой путь к файлу");
            Console.Write("Выбор: ");

            var path = Console.ReadLine()?.Trim() == "2"
                ? PromptPath()
                : Path.Combine(AppContext.BaseDirectory, "Data", "sample.txt");

            return new TextParser().Parse(File.ReadAllText(path));
        }

        private static string PromptPath()
        {
            Console.Write("Путь к файлу: ");
            return Console.ReadLine()?.Trim() ?? "";
        }
    }
}
