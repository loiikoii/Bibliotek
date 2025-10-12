namespace Bibliotek
{
    internal class Program
    {
        static string filePathOne = "..\\..\\..\\log.txt";
        static string filePathTwo = "..\\..\\..\\borrow.txt";
        static string[] books =
            ["The thorns of Aurelion", "Silverfire and shadowglass", "The ranger of broken pines", "Beneath the willow's shadow", "Paradox engines", "Orbitfall"];
        static int[] available; //= [2, 1, 4, 5, 1, 3];
        static int[] borrowed; //= [0, 0, 0, 0, 0, 0];

        static void Main(string[] args)
        {
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
                        File.Delete(filePathOne);
                        Create(); //Only does something the first time
                        bool signedIn = WelcomeSignIn(); //Welcome & sign in page
                        if (signedIn)
                        {
                            Console.WriteLine("Log in Success");
                            Choice(); //Coice menu
                        }
                    }
                }
                else if (choice == 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Fel input");
                }
            }
        }



        static void Create()
        {
            if (!File.Exists(filePathOne))
            {
                //File.Create(filePath);
                //Console.Write("Vänta, vi bygger ett bibliotek");
                //for (int i = 0; i < 5; i++)
                //{
                //    Thread.Sleep(1000);
                //    Console.Write(".");
                //}
                //Console.WriteLine("\nDone!");
                //string[] books = ["The thorns of Aurelion", "Silverfire and shadowglass", "The ranger of broken pines"];
                File.Create(filePathTwo);
                available = [2, 1, 4, 5, 1, 3];
                borrowed = [0, 0, 0, 0, 0, 0];

                File.WriteAllLines(filePathOne, books);
                //File.WriteAllLines(filePath2, borrowed);
            }
        }



        static bool WelcomeSignIn()
        {
            int tries = 3;
            string[] u1 = ["u1", "1"];//Users start
            string[] u2 = ["u2", "2"];
            string[] u3 = ["u3", "3"];
            string[] u4 = ["u4", "4"];
            string[] u5 = ["u5", "5"];
            string[][] users = [u1, u2, u3, u4, u5];//users end
            Console.WriteLine("Välkommen till biblioteket!");
            Console.WriteLine("Var vänlig och logga in.");
            bool success = false;
            while (tries != 0 || success == true)
            {
                Console.Write("Användare: ");
                string userTry = Console.ReadLine();

                Console.Write("Lösenord: ");
                string pasTry = Console.ReadLine();


                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i][0] == userTry && users[i][1] == pasTry)
                    {
                        success = true;
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
                    Console.WriteLine("Fel input.");
                    tries--;
                    if (tries != 0)
                    {
                        Console.WriteLine($"Försök igen. Du har {tries} försök kvar");
                    }
                    else if (tries == 0)
                    {
                        Console.WriteLine("För många försök, hejdå!");
                        break;
                    }
                }
            }
            return false;
        }
        static void Choice()
        {
            int choice = 0;
            while (choice != 5)
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
                            Console.WriteLine("Case1");
                            LibraryView();
                            Back();
                            break;
                        case 2:
                            Console.WriteLine("Case2");
                            LibraryBorrow();
                            Back();
                            break;
                        case 3:
                            Console.WriteLine("Case3");
                            LibraryReturn();
                            Back();
                            break;
                        case 4:
                            Console.WriteLine("Case4");
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
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }

        }
        static void LibraryView()
        {
            string[] stock = File.ReadAllLines(filePathOne);
            int i = 0;
            foreach (string book in stock)
            {
                Console.WriteLine($"{i}. {book}, {available[i]} tillgängliga.");
                i++;
            }


        }
        static void LibraryBorrow()
        {

            LibraryView();
            Console.WriteLine("Vilken bok vill du låna?");
            if (int.TryParse(Console.ReadLine(), out int choice) 
                && choice != 0 && choice !< 5 && available[choice] != 0)
            {

                available[choice]--;
                borrowed[choice]++;
            }
            else if (available[choice] == 0)
            {
                Console.WriteLine("Tyvärr har vi inte den här boken inne just nu.");
            }
            else
            {
                Console.WriteLine("Fel input");
            }
        }
        static void LibraryReturn()
        {
            LibraryView();
            Console.WriteLine("Vilken bok vill du lämna tillbaka?");
            if (int.TryParse(Console.ReadLine(), out int choice)
               && choice != 0 && choice! < 5 && borrowed[choice] != 0)
            {

                available[choice]++;
                borrowed[choice]--;
            }
            else if (borrowed[choice] == 0)
            {
                Console.WriteLine("Du har inte lånat den här boken.");
            }
            else
            {
                Console.WriteLine("Fel input");
            }
        }

        static void LibraryBorrowed()
        {
            string[] stock = books;
            int i = 0;
            foreach (string book in stock)
            {
                Console.WriteLine($"{i}. {book} {borrowed[i]} lånade");
                i++;
            }
        }
        static void Back()
        {
            foreach (int i in available)
            {
            }




            //File.WriteAllLines(filePathTwo, borrowed);
            Console.WriteLine("Tryck på valfri knapp för att gå till menyn");
            Console.ReadKey();

        }
    }
}
