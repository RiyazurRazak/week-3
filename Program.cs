namespace week_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Translator translator = new Translator();
            Console.WriteLine(translator.PigLatinTranslator("Do you think it is going to rain today?"));
        }
    }
}