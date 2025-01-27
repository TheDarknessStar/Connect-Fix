using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    private static bool displayMenuFirstStart = false;
    private const string VariableName = "OPENSSL_ia32cap";
    private const string VariableValue = "~0x200000200000000";

    static void Main(string[] args)
    {
        Console.Title = "Connect Fix v1.0.2";
        DisplayMenu();
    }

    static void DisplayMenu()
    {
        if (!displayMenuFirstStart)
        {
            displayMenuFirstStart = true;
        }
        else
        {
            Thread.Sleep(2000);
            Console.Clear();
        }
        Console.WriteLine("   ____                            _   _____ _      \r\n  / ___|___  _ __  _ __   ___  ___| |_|  ___(_)_  __\r\n | |   / _ \\| '_ \\| '_ \\ / _ \\/ __| __| |_  | \\ \\/ /\r\n | |__| (_) | | | | | | |  __/ (__| |_|  _| | |>  < \r\n  \\____\\___/|_| |_|_| |_|\\___|\\___|\\__|_|   |_/_/\\_\\\r\n                                                    ");
        Console.WriteLine("\n欢迎使用泰坦陨落二服务器连接修复工具\nbilibili: https://space.bilibili.com/3493268113328579");

        Console.WriteLine("\n1.添加系统变量");
        Console.WriteLine("2.移除系统变量");

        while (true)
        {
            Console.Write("请输入数字: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddSystemVariable();
                    return;
                case "2":
                    RemoveSystemVariable();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("无效的选择，请重新输入");
                    DisplayMenu();
                    break;
            }
        }
    }

    static void AddSystemVariable()
    {
        Console.Clear();
        string variableValue = Environment.GetEnvironmentVariable(VariableName, EnvironmentVariableTarget.Machine);

        if (variableValue != null)
        {
            Console.WriteLine($"系统变量{VariableName}已存在，无需添加");
            DisplayMenu();
            return;
        }

        try
        {
            Console.WriteLine("正在添加系统变量...");
            Environment.SetEnvironmentVariable(VariableName, VariableValue, EnvironmentVariableTarget.Machine);
            Console.WriteLine("系统变量添加完成!!!");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"权限不足，无法添加系统变量: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"添加系统变量时出错: {ex.Message}");
        }

        DisplayMenu();
    }

    static void RemoveSystemVariable()
    {
        Console.Clear();
        Console.WriteLine("正在移除系统变量...");
        string variableValue = Environment.GetEnvironmentVariable(VariableName, EnvironmentVariableTarget.Machine);

        try
        {
            if (variableValue != null)
            {
                Environment.SetEnvironmentVariable(VariableName, null, EnvironmentVariableTarget.Machine);
                Console.WriteLine($"系统变量{VariableName}已删除!!!");
            }
            else
            {
                Console.WriteLine($"未找到系统变量{VariableName}请添加系统变量");
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"权限不足，无法移除系统变量: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"移除系统变量时出错: {ex.Message}");
        }

        DisplayMenu();
    }
}