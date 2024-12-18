using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Введiть хеш для перевiрки: ");
            string Hash = Console.ReadLine(); // Користувач вводить хеш

            bool isFound = false; 
            for (int i = 0; i <= 99999; i++)    // Перебір паролів, від 00000 до 99999
            {
                string password = i.ToString("D5");

                string hash = MD5Hash(password);

                if (hash == Hash)
                {
                    Console.WriteLine($"Пароль: {password}");
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Пароль не знайдено.");
            }
            Console.WriteLine();
        }
    }

    static string MD5Hash(string input)  // Обчислення хешу
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}