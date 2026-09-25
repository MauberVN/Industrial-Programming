using Lab3.Parsing;
using Lab3.Services;
using Lab3.TextModel;
using Lab3.Tokens;

namespace Lab3
{
    internal static class Program
    {
        private static Text _text = new();
        private static string _sourceDescription = "";

        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine();

            LoadText();

            var running = true;
            while (running)
            {
                PrintMenu();
                var choice = Console.ReadLine()?.Trim();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "0": LoadText(); break;
                        case "1": Task1_SortByWordCount(); break;
                        case "2": Task2_SortByLength(); break;
                        case "3": Task3_WordsInQuestions(); break;
                        case "4": Task4_RemoveWordsByLengthAndConsonant(); break;
                        case "5": Task5_ReplaceWordsInSentence(); break;
                        case "6": Task6_RemoveStopWords(); break;
                        case "7": Task7_ExportXml(); break;
                        case "8": PrintCurrentText(); break;
                        case "q": case "Q":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Неизвестная команда.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                Console.WriteLine();
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($"Текущий текст: {_sourceDescription} ({_text.Sentences.Count} предл.)");
            Console.WriteLine("0 - Загрузить/сменить текст");
            Console.WriteLine("1 - Сортировать предложения по возрастанию количества слов");
            Console.WriteLine("2 - Состировать предложения по возрастанию длины");
            Console.WriteLine("3 - Перечислить слова заданной длины в вопросительных предложениях");
            Console.WriteLine("4 - Удалить слова заданной длины, начинающиеся на согласную");
            Console.WriteLine("5 - Заменить слова заданной длины в предложении на подстроку");
            Console.WriteLine("6 - Удалить стоп-слова");
            Console.WriteLine("7 - Экспортировать текст в XML");
            Console.WriteLine("8 - Показать текущий текст целиком");
            Console.WriteLine("Q - Выход");
            Console.Write("Выбор: ");
        }

        private static void LoadText()
        {
            const string baseFileName = "sample.txt";
            
            Console.WriteLine("Источник текста:");
            Console.WriteLine("1 - Data/sample.txt");
            Console.WriteLine("2 - указать свой путь к файлу");
            Console.Write("Выбор: ");
            var choice = Console.ReadLine()?.Trim();

            string raw;
            switch (choice)
            {
                case "2":
                    Console.Write("Путь к файлу: ");
                    var userPath = Console.ReadLine()?.Trim() ?? "";
                    raw = File.ReadAllText(userPath);
                    _sourceDescription = Path.GetFileName(userPath);
                    break;

                default:
                    var enPath = Path.Combine(AppContext.BaseDirectory, "Data", baseFileName);
                    raw = File.ReadAllText(enPath);
                    _sourceDescription = baseFileName;
                    break;
            }

            var parser = new TextParser();
            _text = parser.Parse(raw);
            Console.WriteLine($"Загружено предложений из {_sourceDescription}: {_text.Sentences.Count}");
        }

        private static void PrintCurrentText()
        {
            for (var i = 0; i < _text.Sentences.Count; i++)
                Console.WriteLine($"[{i}] {_text.Sentences[i]}");
        }

        private static void Task1_SortByWordCount()
        {
            var sorted = _text.Sentences.OrderBy(s => s.WordCount);
            foreach (var s in sorted)
                Console.WriteLine($"({s.WordCount,2} слов) {s}");
        }

        private static void Task2_SortByLength()
        {
            var sorted = _text.Sentences.OrderBy(s => s.Length);
            foreach (var s in sorted)
                Console.WriteLine($"({s.Length,3} симв.) {s}");
        }

        private static void Task3_WordsInQuestions()
        {
            var len = ReadInt("Длина слова: ");
            var result = new List<string>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var sentence in _text.Sentences.Where(s => s.IsQuestion()))
            {
                foreach (var word in sentence.Words.Where(w => w.Length == len))
                {
                    if (seen.Add(word.Value))
                        result.Add(word.Value);
                }
            }

            Console.WriteLine(result.Count == 0
                ? "Слова такой длины в вопросительных предложениях не найдены."
                : string.Join(", ", result));
        }

        private static void Task4_RemoveWordsByLengthAndConsonant()
        {
            var len = ReadInt("Длина слова: ");
            var removed = 0;

            foreach (var sentence in _text.Sentences)
            {
                removed += sentence.Tokens.RemoveAll(
                    t => t is Word w && w.Length == len && w.StartsWithConsonant());
            }

            Console.WriteLine($"Удалено слов: {removed}");
            PrintCurrentText();
        }

        private static void Task5_ReplaceWordsInSentence()
        {
            if (_text.Sentences.Count == 0)
            {
                Console.WriteLine("Текст пуст.");
                return;
            }

            var index = ReadInt($"Номер предложения (0..{_text.Sentences.Count - 1}): ");
            if (index < 0 || index >= _text.Sentences.Count)
            {
                Console.WriteLine("Некорректный номер предложения.");
                return;
            }

            var len = ReadInt("Длина слова: ");
            Console.Write("Строка для замены: ");
            var replacement = Console.ReadLine() ?? "";

            var sentence = _text.Sentences[index];
            var replaced = 0;
            foreach (var token in sentence.Tokens)
            {
                if (token is Word word && word.Length == len)
                {
                    word.Value = replacement;
                    replaced++;
                }
            }

            Console.WriteLine($"Заменено слов: {replaced}");
            Console.WriteLine(sentence);
        }

        private static void Task6_RemoveStopWords()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "stopwords.txt");

            var remover = StopWordsRemover.FromFile(path);
            var removed = remover.RemoveStopWords(_text);

            Console.WriteLine($"Удалено стоп-слов: {removed}");
            PrintCurrentText();
        }

        private static void Task7_ExportXml()
        {
            Console.Write("Имя файла для сохранения (например, output.xml): ");
            var name = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(name))
                name = "output.xml";

            TextXmlExporter.Export(_text, name);
            Console.WriteLine($"Сохранено в {Path.GetFullPath(name)}");
        }

        private static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
                Console.Write("Введите целое число: ");
            return value;
        }
    }
}
