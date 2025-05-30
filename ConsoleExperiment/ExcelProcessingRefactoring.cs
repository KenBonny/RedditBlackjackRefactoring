using Microsoft.Extensions.Configuration;

namespace ConsoleExperiment;

/// <summary>
/// Refactoring of a Reddit thread with code
/// </summary>
public class ExcelProcessingRefactoring
{
    private const string Process = "1";
    private const string Export = "2";
    private const string Translate = "3";
    private const string End = "4";
    public async Task Run() {// Set up configuration and services
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .Build();
        try
        {
            var excelTranslationService = new ExcelTranslationService();
            var inputPath = configuration["Excel:InputPath"];
            if (inputPath is null)
            {
                Console.WriteLine("Excel Input Path is empty. Please set it in appsettings.json");
                return;
            }

            var (inputFile, outputFile) = InAndOutputFilePaths(inputPath);

            while (true)
            {
                var choice = Choose();
                if (choice == End)
                    break;

                ExcelCommand excelCommand = choice switch
                {
                    Process => new ProcessRange(
                        inputFile,
                        outputFile,
                        ReadNumber("Skip rows"),
                        ReadNumber("Take rows"),
                        ReadNumber("Chunk size")),
                    Export => new ExportTranslatedRows(
                        inputFile,
                        outputFile,
                        ReadNumber("Skip rows"),
                        ReadNumber("Take rows"),
                        ReadNumber("Chunk size")),
                    Translate => new CleanEnglish(inputFile, outputFile),
                    _ => new Unknown()
                };

                await ProcessExcel(excelCommand, excelTranslationService);
            }
        }
        finally { }
    }

    private static (string input, string output) InAndOutputFilePaths(string inputPath)
    {
        var projectRoot = Path.GetFullPath(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\SavedFile\collection"), inputPath);
        var inputFile = Path.Combine(projectRoot, inputPath);
        var outputFile = Path.Combine(
            Path.GetDirectoryName(inputFile) ?? projectRoot,
            $"Cleaned_{Path.GetFileName(inputFile)}");
        return (inputFile, outputFile);
    }

    private static string? Choose()
    {
        Console.WriteLine();
        Console.WriteLine("Select an operation:");
        Console.WriteLine("1. Process Excel Range");
        Console.WriteLine("2. Export Translated Rows");
        Console.WriteLine("3. Clean English Body HTML");
        Console.WriteLine("4. Exit");

        var choice = Console.ReadLine();
        return choice;
    }

    private static int ReadNumber(string message)
    {
        Console.Write($"{message}: ");
        return int.Parse(Console.ReadLine() ?? "0");
    }

    private static async Task ProcessExcel(ExcelCommand command, ExcelTranslationService excelTranslationService)
    {
        switch (command)
        {
            case ProcessRange range:
                await excelTranslationService.ProcessExcelRangeAsync(range.Input, range.Output, range.Skip, range.Take, range.Chunk);
                break;
            case ExportTranslatedRows range:
                await excelTranslationService.ExportOnlyTranslatedRowsAsync(range.Input, range.Output, range.Skip, range.Take, range.Chunk);
                break;
            case CleanEnglish clean:
                excelTranslationService.CleanEnglishBodyHtmlColumn(clean.Input, clean.Output);
                break;
        }
    }
}

internal abstract record ExcelCommand;
internal record Unknown : ExcelCommand;
internal record ProcessRange(string Input, string Output, int Skip, int Take, int Chunk) : ExcelCommand;
internal record ExportTranslatedRows(string Input, string Output, int Skip, int Take, int Chunk) : ExcelCommand;
internal record CleanEnglish(string Input, string Output) : ExcelCommand;

internal class ExcelTranslationService
{
    public async Task ProcessExcelRangeAsync(
        string inputFile,
        string outputFile,
        int skipRows,
        int takeRows,
        int chunkSize)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(200));
    }

    public async Task ExportOnlyTranslatedRowsAsync(
        string inputFile,
        string outputFile,
        int skipRows,
        int takeRows,
        int chunkSize)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(200));
    }

    public void CleanEnglishBodyHtmlColumn(string inputFile, string outputFile) { }
}