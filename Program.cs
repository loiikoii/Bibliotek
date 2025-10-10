namespace Bibliotek
{
    internal class Program
    {
        static string filePath1 = "..\\..\\..\\log.txt";
        static string filePath2 = "..\\..\\..\\borrow.txt";

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
                        File.Delete(filePath1);
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
            if (!File.Exists(filePath1))
            {
                //File.Create(filePath);
                //Console.Write("Vänta, vi bygger ett bibliotek");
                //for (int i = 0; i < 5; i++)
                //{
                //    Thread.Sleep(1000);
                //    Console.Write(".");
                //}
                //Console.WriteLine("\nDone!");
                string[] books = ["The thorns of Aurelion", "Silverfire and shadowglass", "The ranger of broken pines"];
                File.WriteAllLines(filePath1, books);
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
                            //LibraryReturn();
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
        static string[] LibraryView()
        {
            string[] stock = File.ReadAllLines(filePath1);
            int i = 0;
            foreach (string book in stock)
            {
                Console.WriteLine($"{i}. {book}");
                i++;
            }

            return stock;
        }
        static void LibraryBorrow()
        {

            LibraryView();
            Console.WriteLine("Vilken bok vill du låna?");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                
            }
        }
        static void LibraryReturn()
        {

        }

        static void LibraryBorrowed()
        {
            string[] stock = File.ReadAllLines(filePath2);
            int i = 0;
            foreach (string book in stock)
            {
                Console.WriteLine($"{i}. {book}");
                i++;
            }
        }
        static void Back()
        {
            Console.WriteLine("Tryck på valfri knapp för att gå till menyn");
            Console.ReadKey();
        }
    }
}
