using System;

namespace TODO_Konsolenapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] liste = new string[3];
            bool offen = true;
            string eingabe = "";
            int taskCount = 0;

            while (offen)
            {
                Console.WriteLine("Deine Auswahl: ADD, REMOVE, VIEW, CLOSE");
                eingabe = Console.ReadLine().ToUpper();

                switch (eingabe)
                {
                    case "ADD":
                        if (taskCount < 3)
                        {
                            Console.WriteLine("TODO hinzufügen:");
                            string neuesTodo = Console.ReadLine();
                            liste[taskCount] = neuesTodo;
                            taskCount++;
                        }
                        else
                        {
                            Console.WriteLine("Liste ist voll.");
                        }
                        break;

                    case "REMOVE":
                        if (taskCount > 0)
                        {
                            Console.WriteLine("Welche Position löschen? (0-2)");
                            if (int.TryParse(Console.ReadLine(), out int taskRemove) && taskRemove >= 0 && taskRemove < 3 && !string.IsNullOrEmpty(liste[taskRemove]))
                            {
                                liste[taskRemove] = null;
                                for (int i = taskRemove; i < 2; i++)
                                {
                                    liste[i] = liste[i + 1];
                                    liste[i + 1] = null;
                                }
                                taskCount--;
                            }
                            else
                            {
                                Console.WriteLine("Ungültige Position.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Keine TODOs zum Entfernen vorhanden.");
                        }
                        break;

                    case "VIEW":
                        Console.WriteLine("TODO Liste:");
                        for (int i = 0; i < 3; i++)
                        {
                            if (!string.IsNullOrEmpty(liste[i]))
                            {
                                Console.WriteLine($"{i}: {liste[i]}");
                            }
                        }
                        break;

                    case "CLOSE":
                        offen = false;
                        break;

                    default:
                        Console.WriteLine("Falsche Eingabe");
                        break;
                }
            }
        }
    }
}
