using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

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
        FifthSolution(); //Вставлять сюда
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
        TerminateProcess((IntPtr)process.Id);
    }

    private static void StopCurrentThread() //Вспомогательный метод
    {
        AutoResetEvent waitHandler = new AutoResetEvent(false);
        waitHandler.WaitOne(); //Остановить текущий поток
    }

    #region WinAPI

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, IntPtr dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool TerminateProcess(int hProcess, uint uExitCode);

    const uint PROCESS_TERMINATE = 0x1;

    private static void TerminateProcess(IntPtr PID)
    {
        IntPtr hProcess = OpenProcess(PROCESS_TERMINATE, false, PID);

        if (hProcess == IntPtr.Zero)
            throw new Win32Exception(
            Marshal.GetLastWin32Error());

        if (!TerminateProcess((int)hProcess, 0))
            throw new Win32Exception(
            Marshal.GetLastWin32Error());

        CloseHandle(hProcess);
    }

    #endregion
}