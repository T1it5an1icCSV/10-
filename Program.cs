﻿public class Administrator
{
    public string Login { get; set; }
    public string Password { get; set; }
    // другие свойства и методы администратора
}

public class Cashier
{
    public string Login { get; set; }
    public string Password { get; set; }
    // другие свойства и методы кассира
}

public class PersonnelManager
{
    public static Dictionary<string, string> UserToEmployeeMap { get; set; }

    static PersonnelManager()
    {
        UserToEmployeeMap = new Dictionary<string, string>();
    }

    public static void AddMapping(string userLogin, string employeeName)
    {
        if (!UserToEmployeeMap.ContainsKey(userLogin))
        {
            UserToEmployeeMap.Add(userLogin, employeeName);
        }
        else
        {
            UserToEmployeeMap[userLogin] = employeeName;
        }
    }

    // другие методы
}

public class InformationSystem
{
    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в информационную систему магазина!");

            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string password = GetHiddenPassword();

            if (Authenticate(login, password))
            {
                Console.Clear();
                Console.WriteLine("Авторизация прошла успешно!\n");
                Console.WriteLine($"Вы вошли под логином {GetLoggedInUsername(login)}.\n");

                // Здесь вызывайте соответствующее меню в зависимости от роли
                if (PersonnelManager.UserToEmployeeMap.ContainsKey(login))
                {
                    string role = PersonnelManager.UserToEmployeeMap[login];
                    switch (role)
                    {
                        case "администратор":
                            ShowAdministratorMenu();
                            break;
                        case "кассир":
                            ShowCashierMenu();
                            break;
                        // Добавьте вызов методов для остальных должностей
                        default:
                            Console.WriteLine("Роль не определена.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Роль не определена.");
                }

                break;
            }
            else
            {
                Console.WriteLine("\nОшибка авторизации. Попробуйте еще раз.\n");
            }
        }

        Console.WriteLine("Нажмите любую клавишу для выхода.");
        Console.ReadKey();
    }

    private string GetHiddenPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (!string.IsNullOrEmpty(password))
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();

        return password;
    }

    private bool Authenticate(string login, string password)
    {
        // Реализуйте метод аутентификации с использованием введенных логина и пароля
        return true; // Верните true, если аутентификация успешна; иначе верните false
    }

    private string GetLoggedInUsername(string login)
    {
        // Получите имя пользователя для указанного логина
        return ""; // Замените пустую строку на соответствующий код
    }

    private void ShowAdministratorMenu()
    {
        // Реализуйте логику меню администратора
    }

    private void ShowCashierMenu()
    {
        // Реализуйте логику меню кассира
    }
}


class Program
{
    static void Main(string[] args)
    {
        InformationSystem system = new InformationSystem();
        system.Run();
    }
}
