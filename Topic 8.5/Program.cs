using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace Topic_8._5
{
    internal class Program
    {   
        static void DrawHangman(int stage)
        {
            switch (stage)
            {
                case 0:
                    Console.WriteLine("_____");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|_____");
                    break;
                case 1:
                    Console.WriteLine("_____");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|   (_)");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|_____");
                    break;
                case 2:
                    Console.WriteLine("_____");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|   (_)");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|_____");
                    break;
                case 3:
                    Console.WriteLine("_____");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|   (_)");
                    Console.WriteLine("|   \\|");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|_____");
                    break;
                case 4:
                    Console.WriteLine("_____");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|   (_)");
                    Console.WriteLine("|   \\|/");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|_____");
                    break;
                case 5:
                    Console.WriteLine("_____");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|   (_)");
                    Console.WriteLine("|   \\|/");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|   /");
                    Console.WriteLine("|");
                    Console.WriteLine("|_____");
                    break;
                case 6:
                    Console.WriteLine("_____");
                    Console.WriteLine("|/   |");
                    Console.WriteLine("|   (_)");
                    Console.WriteLine("|   \\|/");
                    Console.WriteLine("|    |");
                    Console.WriteLine("|   / \\");
                    Console.WriteLine("|");
                    Console.WriteLine("|_____");
                    Console.WriteLine(" Last Guess...");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Hang Man";

            Random generator = new Random();
            List<string> listWords = new List<string>();
            List<string> displayWord = new List<string>();
            List<string> individualWord = new List<string>();
            List<string> wrongAnswers = new List<string>();

            Console.WriteLine();
            Console.WriteLine("  Click 'Enter' to Proceed in the Instructions.");
            Console.ReadLine(); Console.Clear(); Console.WriteLine();
            Console.WriteLine("  You are Given a Mystery Word, You have 6 Guesses of Letters to Find the Word.");
            Console.ReadLine(); Console.Clear(); Console.WriteLine();
            Console.WriteLine("  If you Can't Find the Word Before the Man is Hung, You LOSE!!");
            Console.ReadLine(); Console.Clear();

            listWords.Add("STINKY");
            listWords.Add("ANIMALS");
            listWords.Add("ARCHITECTURE");
            listWords.Add("PRINCIPAL");
            listWords.Add("REQUEST");
            listWords.Add("BASKETBALL");
            listWords.Add("FOUNDATION");
            //ADD MORE LATER!!!!!!!!!!!!!!!!!!!!!!!!!
            bool playing = true;
            while (playing == true)
            {
                int incorrect = 0;
                bool done = false;
                string guess = "";
                int randomWord;
                string word;
                bool won = false;

                individualWord.Clear();
                displayWord.Clear();
                wrongAnswers.Clear();

                randomWord = generator.Next(0, listWords.Count());

                //display _ _ _ _ 

                for (int i = 0; i != listWords[randomWord].Count();)
                {
                    i++;
                    displayWord.Add("_");
                }

                //makes big word into individual letter

                for (int i = 0; i != listWords[randomWord].Count();)
                {
                    individualWord.Add(listWords[randomWord].Substring(i, 1));
                    i++;
                }
                while (!done)
                {
                    bool guessed = false;

                    // check guess

                    if (listWords[randomWord].Contains(guess))
                    {
                        for (int i = 0; i != listWords[randomWord].Count(); i++)
                        {
                            if (individualWord[i] == guess)
                            {
                                displayWord[i] = individualWord[i];
                            }
                        }
                    }
                    else if ((listWords[randomWord].Contains(guess)) & (incorrect == 6)) { }
                    else if ((listWords[randomWord].Contains(guess) == false) & (incorrect == 6)) { guessed = true; done = true; }
                    else { incorrect++; wrongAnswers.Add(guess); }
                    Console.WriteLine();
                    if (displayWord.Contains("_") == false)
                    {
                        done = true;
                        guessed = true;
                        won = true;
                    }
                    for (int i = 0; i != wrongAnswers.Count(); i++)
                    {
                        Console.Write(" " + wrongAnswers[i]); ;
                    }
                    Console.WriteLine();

                    //print hangman art

                    DrawHangman(incorrect);
                    Console.WriteLine(); Console.WriteLine();

                    // prints the word

                    for (int i = 0; i != listWords[randomWord].Count(); i++)
                    {
                        Console.Write(" " + displayWord[i]);
                    }

                    Console.WriteLine(); Console.WriteLine();

                    //input guess

                    while (guessed == false)
                    {
                        Console.Write("Guess a Letter: ");
                        guess = Console.ReadLine().ToUpper();
                        if (wrongAnswers.Contains(guess))
                        {
                            Console.Clear(); Console.WriteLine();
                            for (int i = 0; i != wrongAnswers.Count(); i++)
                            {
                                Console.Write(" " + wrongAnswers[i]); ;
                            }
                            Console.WriteLine();
                            DrawHangman(incorrect);
                            Console.WriteLine(); Console.WriteLine();
                            for (int i = 0; i != listWords[randomWord].Count(); i++)
                            {
                                Console.Write(" " + displayWord[i]);
                            }
                            Console.WriteLine();
                            Console.WriteLine(); Console.WriteLine("You Already Guesses this Letter.");
                        }
                        else if ((guess == "A") || (guess == "B") || (guess == "C") || (guess == "D") || (guess == "E") || (guess == "F") || (guess == "G") || (guess == "H") || (guess == "I") || (guess == "J") || (guess == "K") || (guess == "L") || (guess == "M") || (guess == "N") || (guess == "O") || (guess == "P") || (guess == "Q") || (guess == "R") || (guess == "S") || (guess == "T") || (guess == "U") || (guess == "V") || (guess == "W") || (guess == "X") || (guess == "Y") || (guess == "Z"))
                        {
                            guessed = true;
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear(); Console.WriteLine();
                            for (int i = 0; i != wrongAnswers.Count(); i++)
                            {
                                Console.Write(" " + wrongAnswers[i]); ;
                            }
                            Console.WriteLine();
                            DrawHangman(incorrect);
                            Console.WriteLine(); Console.WriteLine();
                            for (int i = 0; i != listWords[randomWord].Count(); i++)
                            {
                                Console.Write(" " + displayWord[i]);
                            }
                            Console.WriteLine();
                            Console.WriteLine(); Console.WriteLine("Invalid Input. Must be a Single Letter.");
                        }
                    }
                }
                Console.Clear(); Console.WriteLine();
                if (won == true) { Console.WriteLine(" Good Job you won. the word was " + listWords[randomWord] + "."); }
                else { Console.WriteLine("  Nice Try. the word was " + listWords[randomWord] + "."); }
                Console.WriteLine();
                Console.WriteLine(" Press 'Enter' to Continue.");
                Console.ReadLine(); Console.Clear();
            }
        }
    }
}