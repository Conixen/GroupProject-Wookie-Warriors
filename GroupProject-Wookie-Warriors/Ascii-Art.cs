using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace GroupProject_Wookie_Warriors
{
    internal class Ascii_Art
    {
        public static void Ascii()
        {
            PlaySound("C:\\Users\\Leon\\Desktop\\GroupProject-Wookie-Warriors\\GroupProject-Wookie-Warriors\\Chewbacca Sound Effect.wav");
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
        }

            static void PrintAsciArtInBrown(string asciiArt)
            {               
                 Console.ForegroundColor = ConsoleColor.DarkYellow;
                int consoleWidth = Console.WindowWidth;

                 // Split the ASCII art into lines
                string[] lines = asciiArt.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                // Find the length of the longest line
                int maxLineLength = 0;
                foreach (string line in lines)
                {
                    if (line.Length > maxLineLength)
                    {
                        maxLineLength = line.Length;
                    }
                }

                // Calculate the starting position for each line to center it
                foreach (string line in lines)
                {
                    int position = (consoleWidth / 2) - (line.Length / 2);
                    Console.SetCursorPosition(position, Console.CursorTop);
                    Console.WriteLine(line);
                }               
                  Console.ResetColor();
            }

        public static void PlaySound(string filepath)
        {           
            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = filepath;
            musicPlayer.Play();

        }


    }
}
