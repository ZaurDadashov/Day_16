using System;
using System.IO;
using System.Collections;

namespace Writing_and_reading_files
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Passport { get; set; }
        public int Age { get; set; }
        public int Payment { get; set; }
        public string Input()
        {
            for (; ; )
            {
                string input = Console.ReadLine();
                string error = "1234567890-=!@#$%~^&*()_+`|\\,./<>?;':|[]{} ";
                int counter = 0;
                foreach (int i in input)
                {
                    int temp = i;
                    foreach (int j in error)
                    {
                        if (temp == j)
                            counter++;
                    }
                }
                if (counter == 0 && input != "")
                {
                    return input;
                }
                else
                    Console.WriteLine("Invalid input.Please try again!");
            }
        }
        public static int InputDigits()
        {
            int digits = 0;
            for (; ; )
            {
                if (!int.TryParse(Console.ReadLine(), out digits) || digits <= 0) { Console.WriteLine("Invalid input. Please try again!"); }
                else
                    return digits;
            }
        }
        public void Add()
        {
            string path = @"C:\SomeDir";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                using (FileStream fstream = new FileStream($"{path}\\note.txt", FileMode.OpenOrCreate)) { }
            }
            string writePath = @"C:\SomeDir\note.txt";
            Console.Write($"Enter ID: ");   
            ID = InputDigits();
            Console.Write($"Enter name: ");
            Name = Input();
            Console.Write($"Enter passport number: ");
            Passport = InputDigits();
            Console.Write($"Enter age: ");
            Age = InputDigits();
            Console.Write($"Enter payment amount: ");
            Payment = InputDigits();
            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine($"ID: {ID}; Name: {Name}; Passport: AZE{Passport}; Age: {Age}; Payment: {Payment}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Add();
            string path = @"C:\SomeDir\note.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
            Console.ReadKey();
        }
    }
}

