using System;
using System.IO;
using System.Collections.Generic;

namespace Ticketing_System
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string file = "tickets.csv";
            string choice;

            do
            {
                Console.WriteLine("1) Read data from file");
                Console.WriteLine("2) Create file from data");
                Console.WriteLine("Enter any other key to exit.");
                
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    StreamReader sr = new StreamReader(file);
                    if (File.Exists(file))
                    {
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                        sr.Close();
                    }else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file, true);
                    char response;
                    do
                    {
                        Console.WriteLine("Enter a Ticket (Y/N)?");
                        response = Convert.ToChar(Console.ReadLine().ToUpper());
                        if(response == 'N')
                            break;
                        
                        Console.WriteLine("Enter the ticket ID");
                        string id = Console.ReadLine();
                        Console.WriteLine("Enter the ticket summary.");
                        string summary = Console.ReadLine();
                        Console.WriteLine("Enter ticket status");
                        string status = Console.ReadLine();
                        Console.WriteLine("Enter ticket priority");
                        string priority = Console.ReadLine();
                        Console.WriteLine("Enter name of person who submitted ticket");
                        string submitter = Console.ReadLine();
                        Console.WriteLine("Enter name of person who assigned ticket");
                        string assigned = Console.ReadLine();
                        char watchingResp;
                        string watchers;
                        List<string> watchingUsers = new List<string>();
                        do
                        {
                            Console.WriteLine("Enter A Watching User? (Y/N)?");
                            watchingResp = Convert.ToChar(Console.ReadLine().ToUpper());
                            if(watchingResp == 'N')
                                break;
                            Console.WriteLine("Enter Watching User's Name (First Last)");
                            watchingUsers.Add(Console.ReadLine());
                        } while (watchingResp == 'Y');
                        
                        watchers = string.Join("|", watchingUsers);
                        
                        sw.WriteLine($"{id},{summary},{status},{priority},{submitter},{assigned},{watchers}");
                    } while (response == 'Y');
                    sw.Close();
                }


            }while (choice == "1" || choice == "2");
            
        }
    }
}