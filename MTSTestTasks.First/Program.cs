using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            FailProcess();
        }
        catch { }

        Console.WriteLine("Failed to fail process!");
        Console.ReadKey();
    }

    static void FailProcess()
    {
        FifthSolution();
    }




    static void FirstSolution()
    {
        Environment.Exit(0);
    }

    static void SecondSolution()
    {
        var process = Process.GetCurrentProcess();
        process.Kill();
        process.WaitForExit();
    }

    static void ThirdSolution() /////////////ОСТОРОЖНО ПЕРЕЗАПУСК ПК
    {
        Process.Start("shutdown", "/r /t 0");
        StopCurrentThread();
    }

    static void FourthSolution()
    {
        var process = Process.GetCurrentProcess();
        Process.Start(new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = $"/c taskkill /PID {process.Id} /F",
        });
        process.WaitForExit();
    }

    static void FifthSolution()
    {
        var process = Process.GetCurrentProcess();
        StopCurrentThread();
    }

    private static void StopCurrentThread() //Вспомогательный метод
    {
        AutoResetEvent waitHandler = new AutoResetEvent(false);
        waitHandler.WaitOne(); //Остановить текущий поток
    }
}
