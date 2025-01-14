using System;
using System.Security.Cryptography;
using System.Text;

class Program {
    static void Main() {
        while (true) {
            Console.Write("Введiть хеш: ");
            string Hash = Console.ReadLine(); 

            bool isFound = false; 
            for (int i = 0; i <= 99999; i++) {
                string password = i.ToString("D5");
                string hash = MD5Hash(password);

                if (hash == Hash) {
                    Console.WriteLine($"Пароль: {password}");
                    isFound = true;
                    break;
                }
            }

            if (!isFound) {
                Console.WriteLine("Пароль не знайдено.");
            } 
            Console.WriteLine();
        }
    }

    static string MD5Hash(string input) {
        using (MD5 md5 = MD5.Create()) {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes) {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}