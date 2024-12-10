using System.Runtime.ConstrainedExecution;
using System.Media;
namespace GroupProject_Wookie_Warriors
{
    internal class Program
    {


        static void Main(string[] args)
        {
            PlaySound("C:\\Users\\jenni\\source\\repos\\GroupProject-Wookie-Warriors\\GroupProject-Wookie-Warriors\\Chewbacca Sound Effect.wav");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
                string asciiArt =
                    "           ⠀⠀⠀⠀ ⣀⣤⣤⣴⣶⣶⣶⣦⣤⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠁⠟⢿⢿⠇⠉⡿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⠀⠀⢠⣴⣿⣿⣿⣿⣿⣿⢻⢸⣿⣿⣿⣿⠁⠀⠀⠀⠈⠀⠀⠀⠘⠿⢿⣿⢿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⡿⠟⢹⠈⠀⣿⣿⢿⡟⠀⢀⠆⢀⠀⠀⠀⡀⠀⢀⡼⠃⠟⢻⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⢰⣿⣿⣿⣿⣿⢿⢷⠀⠈⠀⠀⢸⠏⢸⠁⠀⡾⢠⡇⢀⣠⣾⡿⠀⠞⠁⠀⡴⢋⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⣾⣿⣿⣿⣿⣿⣦⡁⠁⠀⠀⠀⠀⠀⠀⠀⢰⠇⠛⠀⠜⠟⠉⠃⠀⠀⡠⠊⠀⣈⣽⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠠⣿⣿⣿⣿⡿⣿⣿⠛⠢⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⢞⡽⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⣿⣿⣿⡇⠑⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⢊⠕⡵⢟⣿⣿⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⣿⣿⠏⠁⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⣤⣄⣤⣤⣀⣀⣀⢀⠀⠀⠀⠀⠀⠨⠟⠉⠁⠀⠙⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⣿⣿⡄⠀⠀⣶⣶⣾⣿⣿⣿⣿⣷⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣀⣀⡀⠀⠀⠀⠠⣾⣦⠄⢸⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⣿⣿⣿⠀⠼⣿⣿⣿⣿⡿⢿⣿⣷⣶⣌⠛⠿⠿⢛⣟⣙⣹⡿⣿⣯⡉⠁⠀⠀⢀⡀⣲⣿⣿⣷⡀⠉⡙⠻⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⢹⣿⡅⠀⠀⠛⠛⠛⢛⣾⡏⠉⢀⣤⣿⣷⡄⠀⠀⠀⠀⠀⠀⠈⠉⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⢿⣶⣤⣙⣾⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⢸⣿⡄⡀⣀⠄⠀⠀⠘⠛⠓⠘⠋⠉⠉⠉⠉⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣰⣶⣶⣿⣿⣿⠋⠀⢀⣙⠻⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⢸⣿⣿⠞⠡⣶⡿⠋⢤⡔⠀⠀⠤⢶⣶⣤⣤⣤⣄⣀⠀⠒⠛⠒⠀⠀⠙⠻⣿⣿⣿⣿⣿⣿⡆⠀⠀⠙⢷⣮⣿⣿⣿⡀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⢸⣿⣯⠀⠀⢿⡿⢂⣉⣀⠀⠀⠀⣀⣉⣉⣉⡙⠻⣿⣿⣿⣶⣤⣄⣀⡀⣀⣼⣿⣿⣿⣿⣿⡇⠀⠀⢀⢘⣿⣿⣿⣿⣷⣄⣀⣀⡀⠀⠀" +
                    "\r\n⠀⠀⠀⢸⣿⣿⡆⠀⣿⡇⢿⠁⣠⡄⢤⣴⣶⣿⡅⢹⣉⣂⡈⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠁⠀⠀⢈⣿⣿⣿⣿⣿⣿⣧⡄⠈⠛⣳⡀" +
                    "\r\n⠀⠀⠀⢾⣿⣿⣷⠀⣿⡇⠘⣴⣿⣿⡄⠙⠋⠙⡷⢺⡿⠿⠿⠦⠀⠙⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠃⠀⢠⡷⣾⣿⣿⣿⣿⣿⣿⣿⡿⠂⠘⠷⡅" +
                    "\r\n⠀⠀⠀⠈⣿⣿⣿⠀⢸⡇⢀⡙⡁⠁⠀⠀⠠⠤⠄⠀⠐⠒⠒⢂⣡⠔⠁⢰⣆⠙⠛⠟⠉⠉⠂⠀⠀⠀⠘⣿⣜⢿⣿⣿⣿⣿⠇⠀⣠⡴⠚⠉⠉" +
                    "\r\n⠀⠀⢰⡇⢻⣿⣿⠀⠈⢠⣴⣯⠁⡀⠀⢀⣠⣴⣶⣾⣾⠏⠉⡁⠀⣠⣤⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣷⠀⠙⢿⠃⡰⠚⠉⠀⠀⠀⠀" +
                    "\r\n⠀⠀⣾⠀⢸⣿⡏⠀⠀⠸⣿⣿⣤⣿⣴⣿⣿⡿⠿⠛⠋⠀⠀⠙⣿⣿⣿⣿⣿⣿⡄⠀⡆⠀⠀⠀⣄⠀⠀⠀⠀⢻⣿⣄⡄⠀⡁⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⢠⣿⠀⠘⠇⣇⠀⠀⠀⠙⠘⣿⣿⣿⠻⠍⠑⠀⠀⠀⠀⠱⣶⣍⣻⣿⣿⣿⣿⣧⠘⠇⠀⠀⠀⢹⡄⠀⠀⠀⠀⢻⣿⣾⡀⠁⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⢸⣿⡀⠀⠀⢸⣦⣦⡆⠀⠀⠸⢿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠈⠉⢻⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠸⣿⣦⠀⠀⢀⢸⣿⣿⢁⠃⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⢰⣿⠀⠀⠀⠈⣿⣿⣿⣧⡇⠀⠀⠹⣿⣦⠀⠘⢾⣾⣶⣶⣶⠀⣘⣿⣿⣿⠿⡄⠀⠀⠀⠀⠀⠀⠹⣿⠗⠀⠘⠛⣿⠇⢈⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⣾⣿⠄⠀⠀⠀⠉⠻⣿⣿⣧⠀⢾⣷⣿⣿⣷⣀⣀⢹⣿⣿⣧⣴⣿⣿⣿⣿⠀⠈⠀⠠⡀⢳⡄⠈⢄⠙⠀⠀⠀⣤⣿⠈⠈⠄⠀⠀⠀⠀⠀⠀" +
                    "\r\n⢰⢻⡟⡀⣀⠀⠀⠀⣴⠀⠀⠈⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠛⠻⡀⠀⠀⢠⣧⡀⠱⠀⢮⡆⠀⣇⠀⢹⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⢸⣿⣿⠇⢀⡌⡀⢹⠀⠀⠀⠀⠀⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠋⠀⠀⠁⠀⠀⠈⣿⣷⡄⠀⠘⡟⠀⣧⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠘⣿⡏⣴⣿⣼⢁⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⠟⠋⠹⣿⠙⢿⡆⠀⠀⠀⠀⠀⠀⠸⣿⢿⠀⠀⠈⠈⣿⡆⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⡟⣷⣿⣿⣧⡇⠀⠀⠀⠀⣠⠀⠀⠈⠟⠏⡟⠇⠀⠀⠀⠃⠀⡈⠑⠀⠀⢀⠀⠀⠀⠀⢿⠈⠀⠀⢰⠀⢸⡇⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⣷⡏⣿⣿⣿⣵⢼⠃⠀⢸⣷⣤⠀⠀⠀⢀⢁⡀⣄⠀⠀⠀⣾⣿⡄⠀⡄⢈⣆⠀⠀⠀⠈⠀⠀⡄⢸⢧⠸⣹⡌⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⡿⠇⣿⣿⡟⠏⡜⠀⡀⢸⣿⣿⠀⠀⠀⢸⣿⡟⠛⠀⠀⠀⢻⣿⣿⣧⡇⠈⣿⠀⢀⠀⠀⡆⠀⣷⣸⠘⡆⡏⢻⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⠀⣿⣿⠀⠀⣷⢰⡇⢸⣿⣿⠀⡜⢰⡌⢿⢀⠀⠀⠀⢄⠀⠇⢿⣿⡇⠀⢻⠀⣿⣧⢀⣷⡀⢃⠹⡆⣇⡇⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⠀⠙⠹⠀⠀⣿⡸⡇⣿⣿⣿⢀⡇⠈⢣⢸⣦⡆⣇⠀⠈⣆⠀⠈⣿⣧⠀⢸⡀⡿⣿⣸⡿⠟⢞⡄⠀⠸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⠀⠀⠀⠀⠀⢿⢳⢱⡇⢻⡏⣼⢱⢠⠀⢂⡟⣿⣿⣆⡆⢻⢷⡄⠹⣿⣦⠘⣧⠸⡘⠹⡏⠀⠀⢹⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠈⠌⡆⢷⠀⢣⠹⡆⢻⡀⠀⢧⠇⢇⠈⢿⠈⠈⠻⢦⡙⣏⢆⠹⡄⠱⡀⠙⠄⠀⠈⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀" +
                    "\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠈⢧⠀⠀⠑⠀⠁⠀⠸⠀⠈⠀⠀⠃⠀⠀⠀⠈⢮⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";
             
                PrintAsciArtInBrown(asciiArt);
                Console.ReadKey();

            // Group project - Wookie Warriors - SUT24
            // Filip, Leon, Tim, Shokran, Simon

            // Skriv inget i Master, skapa en ny branch
            // Skriv in ditt namn på vilken del man tar??
            // Fråga om hjälp om det behövs Wookie Warriors stronk toghether


            // Backlog
            //Som systemägare vill jag att alla användare ska logga in med ett unikt användarnamn och lösenord
            //Som administratör på banken vill jag kunna skapa nya användare i systemet
            //Som systemägare vill jag att användare som misslyckas med inloggningen tre gånger ska låsas ut från att logga in i systemet
            //Som användare vill jag kunna se en lista med alla mina bankkonton och saldot på dessa
            //Som användare vill jag kunna föra över pengar mellan två av mina konton
            //Som användare vill jag kunna föra över Pengar till andra kunder i banken
            //Som användare vill jag kunna öppna upp nya konton i banken
            //Som användare vill jag kunna ha ett visst konto i en annan valuta
            //Som bankägare vill jag att överföringar mellan konton med olika valutor växlas enligt rätt växelkurs som uppdateras dagligen av administratören på banken
            //Som användare vill jag kunna öppna sparkonto i banken och då få se hur mycket ränta jag kommer kunna få på pengarna jag sätter in när jag sätter in dem
            //Som användare vill jag kunna låna av banken och direkt få se hur mycket ränta jag kommer behöva betala på det lånet
            //Som bankägare vill jag begränsa hur mycket varje kund kan låna av banken så att de maximalt kan låna 5 ggr de pengar de redan har i banken
            //Som användare vill jag kunna se en logg på alla överföringar m.m som skett på mina konton
            //Som bankägare vill jag att appen ser snygg ut med tydliga menyer, färgsättning och en snygg logga i ASCII-art som syns när användaren loggar in
            //Som bankägare vill jag inte att transaktioner sker direkt när användarna lägger in dem utan istället var 15e minut så att vi har kontroll på när de sker
          

           Menus.Menu();
        }
        static void PrintAsciArtInBrown(string asciiArt)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(asciiArt);

            Console.ResetColor();
        }

        public static void PlaySound(string filepath)
        {
            //SoundPlayer player = new SoundPlayer(@"C:\Users\jenni\OneDrive\Skrivbord\Programmering\Chewbacca Sound Effect.waw");
            //player.Load();
            //player.Play();

            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = filepath;
            musicPlayer.Play();


        }


    }
}
