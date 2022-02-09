using System;
using System.IO;

namespace Writing_and_reading_files
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Passport { get; set; }
        public byte Age { get; set; }
        public double Payment { get; set; }
        public Client()
        {
            string path = @"C:\SomeDir";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists){dirInfo.Create();}
            using (FileStream fstream = new FileStream($"{path}\\note.txt", FileMode.OpenOrCreate)) {}
        }
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
        public int InputDigits()
        {
            int digits = 0;
            for (; ; )
            {
                if (!int.TryParse(Console.ReadLine(), out digits) || digits > 99999999 || digits < 10000000) { Console.WriteLine("Invalid input. Please try again!"); }
                else
                    return digits;
            }
        }
        public byte InputAge()
        {
            byte digits = 0;
            for (; ; )
            {
                if (!byte.TryParse(Console.ReadLine(), out digits) || digits > 115 || digits < 18) { Console.WriteLine("Invalid input. Please try again!"); }
                else
                    return digits;
            }
        }
        public double InputAmount()
        {
            double digits = 0;
            for (; ; )
            {
                if (!double.TryParse(Console.ReadLine(), out digits) || digits <= 0) { Console.WriteLine("Invalid input. Please try again!"); }
                else
                    return digits;
            }
        }
        public void Add()
        {
            string writePath = @"C:\SomeDir\note.txt"; 
            Console.Write($"Enter name: ");
            Name = Input();
            Console.Write($"Enter passport number(8 digits): ");
            Passport = InputDigits();
            Console.Write($"Enter age: ");
            Age = InputAge();
            Console.Write($"Enter payment amount: ");
            Payment = InputAmount();
            ID = Math.Abs(Name.GetHashCode());
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
            bool exit = false;
            for (; ; )
            {
                if (exit) break;
                Console.WriteLine("To add records, enter 1");
                Console.WriteLine("To read data from a file, enter 2");
                Console.WriteLine("To exit the program, enter 0");
                switch (Console.ReadLine())
                {
                    case "1":
                        client.Add();
                        break;
                    case "2":
                        string path = @"C:\SomeDir\note.txt";
                        using (StreamReader sr = new StreamReader(path))
                        {
                            Console.WriteLine(sr.ReadToEnd());
                        }
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("There is not this option!");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}

