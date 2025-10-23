namespace Bibliotek
{
    internal class Program
    {
        static string[] books =
            ["Filler", "The thorns of Aurelion", "Silverfire and shadowglass", "The ranger of broken pines", "Beneath the willow's shadow", "Paradox engines", "Orbitfall"]; //Booktitles
        static int[] available = new int[7]; //Global int array to show availability of each book
        static int[] borrowed = new int[7]; //Global int array to show the borrowed books
        static string filePathOne = "..\\..\\..\\log.txt"; //Path for availability log
        static string filePathU1 = "..\\..\\..\\borrow1.txt"; //Path for borrow log
        static string filePathU2 = "..\\..\\..\\borrow2.txt"; //Path for borrow log
        static string filePathU3 = "..\\..\\..\\borrow3.txt"; //Path for borrow log
        static string filePathU4 = "..\\..\\..\\borrow4.txt"; //Path for borrow log
        static string filePathU5 = "..\\..\\..\\borrow5.txt"; //Path for borrow log
        static int user;


        static void Main(string[] args)
        {
            user = 0;
            int choice = 0;
            while (choice != 2)
            {
                Console.WriteLine("Välkommen till biblioteket!");
                Console.WriteLine("1. Logga in");
                Console.WriteLine("2. Avsluta");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 1)
                    {
                        Create(); //Only does something the first time
                        bool signedIn = WelcomeSignIn(); //Welcome & sign in page
                        if (signedIn)
                        {
                            Output();
                            Console.WriteLine("Log in Success");
                            Choice(); //Coice menu
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (choice == 3) //log restart
                    {
                        File.Delete(filePathOne);
                        File.Delete(filePathU1);
                        File.Delete(filePathU2);
                        File.Delete(filePathU3);
                        File.Delete(filePathU4);
                        File.Delete(filePathU5);
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Hejdå! Hoppas vi ses snart igen!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Fel input");
                    }
                }
            }
        }



        static void Create()
        {
            if (!File.Exists(filePathOne)) //Will only run if the files don't exist - Creates start value for availability.
            {
                available = [0, 2, 1, 4, 5, 1, 3];
                borrowed = [0, 0, 0, 0, 0, 0, 0];

                Input(); //Take values of the global arrays into files.
            }
            
        }
        static void Input() //translate int - string array, file's input x2
        {

            string[] inputOne = new string[available.Length];
            int i = 0;
            // (int[]) available -> (string[]) inputOne - Start
            foreach (int num in available)
            {
                inputOne[i] = num.ToString();
                i++;
            }
            // (int[]) available -> (string[]) inputOne - End
            File.WriteAllLines(filePathOne, inputOne); //Input to File.



            string[] inputTwo = new string[borrowed.Length];
            i = 0;
            // (int[]) borrowed -> (string[]) inputTwo - Start
            foreach (int num in borrowed)
            {
                inputTwo[i] = num.ToString();
                i++;
            }
            if (!File.Exists(filePathU1))
            {
                File.WriteAllLines(filePathU1, inputTwo);
                File.WriteAllLines(filePathU2, inputTwo);
                File.WriteAllLines(filePathU3, inputTwo);
                File.WriteAllLines(filePathU4, inputTwo);
                File.WriteAllLines(filePathU5, inputTwo);
            }
            // (int[]) borrowed -> (string[]) inputTwo - End
            File.WriteAllLines(Log(), inputTwo);

        }
        static void Output() //translate string - int array, file's output x2
        {
            Console.Clear();
            string[] outputOne = new string[available.Length];
            outputOne = File.ReadAllLines(filePathOne);
            int i = 0;
            // (string[]) available -> (int[]) inputOne - Start
            foreach (string part in outputOne)
            {
                available[i] = int.Parse(part);
                i++;
            }
            // (string[]) borrowed -> (int[]) inputOne - End
            string[] outputTwo = new string[borrowed.Length];
            outputTwo = File.ReadAllLines(Log());
            i = 0;
            // (string[]) available -> (int[]) inputOne - Start
            foreach (string part in outputTwo)
            {
                borrowed[i] = int.Parse(part);
                i++;
            }
            // (string[]) available -> (int[]) inputOne - End

        }



        static bool WelcomeSignIn() //Gives both a welcome message and a sign in.
        {
            //Input();
            int tries = 3;

            //index 0 is username and 1 is password
            string[] u1 = ["u1", "1"];//Users start
            string[] u2 = ["u2", "2"];
            string[] u3 = ["u3", "3"];
            string[] u4 = ["u4", "4"];
            string[] u5 = ["u5", "5"];
            string[][] users = [u1, u2, u3, u4, u5];
            //users end
            //string[,] users2 = new string[5, 2];
            //users2[0, 0] = "u1";
            //users2[0, 1] = "1";
            //users2[1, 0] = "u2";
            //users2[1, 1] = "2";
            //users2[2, 0] = "u3";
            //users2[2, 1] = "3";
            //users2[3, 0] = "u4";
            //users2[3, 1] = "4";
            //users2[4, 0] = "u5";
            //users2[4, 1] = "5";




            Console.WriteLine("Välkommen till biblioteket!");
            Console.WriteLine("Var vänlig och logga in.");

            bool success = false;
            while (tries != 0) //Continue to show sign in page while theres tries left.
            {
                Console.Write("Användare: ");
                string userTry = Console.ReadLine();

                Console.Write("Lösenord: ");
                string pasTry = Console.ReadLine();


                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i][0] == userTry && users[i][1] == pasTry) //return true if the both indexes match the users above ex "u1" & "1"
                    {
                        success = true;
                        user = i + 1;
                        Log();
                        break;
                    }
                }
                if (success == true)
                {
                    Console.WriteLine($"Välkommen {userTry}!");
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ogiltigt val");
                    tries--;
                    if (tries != 0)
                    {
                        Console.WriteLine($"Försök igen. Du har {tries} försök kvar");
                    }
                    else if (tries == 0) //Too many tries
                    {
                        Console.WriteLine("För många försök, hejdå!");
                        break;
                    }
                }
            }
            return false;
        }
        static void Choice() //Prints the librarymenu
        {
            int choice = 0;
            while (choice != 5) //5 is sign out
            {
                Console.Clear();
                Console.WriteLine("1. Visa böcker");
                Console.WriteLine("2. Låna bok");
                Console.WriteLine("3. Lämna tillbaka bok");
                Console.WriteLine("4. Mina lån");
                Console.WriteLine("5. Logga ut");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            LibraryView();
                            Back();
                            break;
                        case 2:
                            LibraryBorrow();
                            Back();
                            break;
                        case 3:
                            LibraryReturn();
                            Back();
                            break;
                        case 4:
                            LibraryBorrowed();
                            Back();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Ha det så bra!");
                            Console.WriteLine("Du loggas nu ut.");
                            Console.WriteLine("");
                            break;
                        default:
                            Console.WriteLine("Välj en siffra mellan 1-5");
                            break;
                    }
                }
                else //wrong input
                {
                    Console.WriteLine("ogiltigt val");
                }
            }

        }
        static string[] LibraryView() //Prints library stock
        {
            string[] stock = File.ReadAllLines(filePathOne);
            int i = 0;
            foreach (string book in stock)
            {
                if (available[i] != 0)
                {
                    Console.WriteLine($"{i}. {books[i]}, {available[i]} tillgängliga.");
                }

                i++;
            }

            return stock;
        }
        static void LibraryBorrow() //borrow a book here
        {

            LibraryView();
            int[] item = new int[6];
            Console.WriteLine("Vilken bok vill du låna?");
            if (int.TryParse(Console.ReadLine(), out int choice)
                && choice <= 6 && choice >= 0 && available[choice] != 0)
            {
                Console.WriteLine($"Du har nu lånat {books[choice]}.");
                Console.WriteLine("Tänk på att lämna tillbaks den i tid.");
                available[choice]--;
                borrowed[choice]++;
            }
            else if (available[choice] == 0)
            {
                Console.WriteLine("Tyvärr har vi inte den här boken inne just nu.");
            }
            else
            {
                Console.WriteLine("ogiltigt val");
            }
        }
        static void LibraryReturn()  //Return your books here
        {
            LibraryBorrowed();
            int[] item = new int[6];
            Console.WriteLine("Vilken bok vill du lämna tillbaka?");
            if (int.TryParse(Console.ReadLine(), out int choice)
                && choice <= 6 && choice >= 0 && borrowed[choice] != 0)
            {
                Console.WriteLine($"Tack för att du lämnade tillbaks {books[choice]}");
                available[choice]++;
                borrowed[choice]--;
            }
            else if (item[choice] == 7)
            {
            }
            else if (borrowed[choice] == 0)
            {
                Console.WriteLine("Du har inte lånat den här boken.");
            }
            else
            {
                Console.WriteLine("ogiltigt val");
            }
        }

        static void LibraryBorrowed() //Look up borrowed books here.
        {
            string[] stock = File.ReadAllLines(Log());
            int total = borrowed.Sum();
            int i = 0;
            foreach (string book in stock)  //Prints borrowed books.
            {
                if (borrowed[i] != 0)
                {
                    Console.WriteLine($"{i}. {books[i]} {borrowed[i]} lånade");
                }
                i++;
            }
            if (total == 0)
            {
                Console.WriteLine("Du har inga lånade böcker.");
                Console.WriteLine();
            }
            else if (total == 1)
            {
                Console.WriteLine($"Du har 1 lånad bok.");
            }
            else
            {
                Console.WriteLine($"Du har {total} lånade böcker.");
            }
        }
        static void Back()
        {
            Input(); //Updates files with current values.
            Console.WriteLine("Tryck Enter för att återgå till huvudmenyn");
            Console.ReadKey();


        }
        static string Log()
        {

            string log;
            switch (user)
            {
                case 1:
                    log = filePathU1;
                    return log;
                case 2:
                    log = filePathU2;
                    return log;
                case 3:
                    log = filePathU3;
                    return log;
                case 4:
                    log = filePathU4;
                    return log;
                case 5:
                    log = filePathU5;
                    return log;
                default:
                    {
                        log = "filePathOne";
                        return log;
                    }
            }
        }

    }
}
