namespace Service.Helpers
{
    public static class Helper
    {
        public static void WriteConsole(ConsoleColor color ,string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void WriteException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now} [{ex.GetType().Name}] {ex.Message}");
            Console.ResetColor();
        }
    }
}
