using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
           
            Game Game1 = new Game();
            Game1.Gameplay();
        }

        class Game
        {
            private int GameNumPlayers;
            public List<Player> PlayersList = new List<Player>();
            public Deck GameDeck = new Deck();
            public int numPlayers { get { return GameNumPlayers; } }

            public Game()
            {
                GameNumPlayers = WelcomeScreen();
                // Add players to the list
                for (int i = 0; i < GameNumPlayers; i++)
                    PlayersList.Add(new Player(i));
            }
            private int WelcomeScreen()
            {
                int InputNumPlayers = 0;
                bool isNumber = false;

                Console.WriteLine("Welcome to Memory Game");

                // Game should only begin after the number of player is entered.
                // Decide how many players there will be: 2 to 4. 
                #region Prompt for Number of Players. Validate user entry for numbers 2, 3 or 4
                //***********************************************

                Console.Write("Enter number of players (Min 2 Max 4):");
                while (!isNumber)
                {
                    string InputStr = Console.ReadLine();
                    if ((Int32.TryParse(InputStr, out InputNumPlayers)) && (InputNumPlayers == 2 || InputNumPlayers == 3 || InputNumPlayers == 4))
                        isNumber = true;
                    else
                        Console.Write("Wrong, Enter only numbers between 2-4:");
                }
                #endregion
                Console.Clear();
                return InputNumPlayers;
            }

            public void Gameplay()
            {
                foreach (Player currentPlayer in PlayersList)
                {
                    Display_PlayerTurnScreen(currentPlayer.PlayerNum + 1);
                    Display_GameTable();
                }

                /*
screens

playerturn Screen
empty cards screen
    prompt for selection
    1st selected card display screen
    prompt for selection
    2nd selected card display screen
 * Timer
 * Display result update score
 * player turn screen
 * 
                
        check selection
        display result
                    
    update score
*/

            }

            private void Display_PlayerTurnScreen(int PlayerNumPassed)
            {
                Display_GameHeader();
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < 5; i++)
                    Console.WriteLine(" ");
                Console.WriteLine("                                  Player {0}!",PlayerNumPassed);
                for (int i = 0; i < 5; i++)
                    Console.WriteLine(" ");
                Console.WriteLine("It's your turn!\n");
                Console.WriteLine("Press ENTER when you are ready!");
                Console.ReadLine();
                Console.Clear();
            }

            private void Display_GameHeader()
            {
                Console.WriteLine("Memory Game - Deck of Cards");
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Score Board");
                Console.WriteLine("-----------");
                foreach (Player i in PlayersList)
                    Console.WriteLine("Player {0}:{1} ", i.PlayerNum + 1, i.PlayerScore);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.WriteLine();

            }

            private void Display_GameTable()
            {
                Display_GameHeader();
                int count = 0;

                foreach (Card card in GameDeck.DeckOfCards)
                {
                    if (card.CardRed)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (card.CardNum == 49)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" {0}{1}0", card.CardSuit, card.CardNum);
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" {0}{1} ", card.CardSuit, card.CardNum);
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(" ");
                        }

                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Black;
                        if (card.CardNum == 49)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" {0}{1}0", card.CardSuit, card.CardNum);
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" {0}{1} ", card.CardSuit, card.CardNum);
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write(" ");
                        }
                    }

                    if (count < 12)
                        count++;
                    else
                    {
                        Console.Write("\n");
                        Console.Write("\n");
                        count = 0;
                    }
                }

                Console.ReadLine();
                Console.Clear();

            }
        }
        class Player
        {
            public int PlayerNum { get; set; }
            public int PlayerScore { get; set; }

            public Player(int PNum)
            {
                PlayerNum = PNum;
                PlayerScore = 0;
            }

        }
        class Card
        {
            private char Num;
            private bool Red;
            private char Suit;

            public bool CardRed { get {return Red ;} }
            public char CardNum { get { return Num;} }
            public char CardSuit { get { return Suit;} }

            public Card(bool CardRedPassed, char SuitPassed, int NumPassed)
            {
                Num = Convert.ToChar(NumPassed);
                Red = CardRedPassed;
                Suit = SuitPassed;
            }

        }
        class Deck
        {
            public List<Card> DeckOfCards = new List<Card>();
            
            public Deck()
            {
                AddCardsBySuit('\u2660'); // Spade
                AddCardsBySuit('\u2665'); // Heart
                AddCardsBySuit('\u2663'); // Club
                AddCardsBySuit('\u2666'); // Diamond

            }

            private void AddCardsBySuit(char SuitUnicode)
            {               
                int count = 0;
                bool RedSpade = true;

                // Loop twice only: first for Red and second for Black
                while (count < 2)
                {
                    for (int i = 49; i < 58; i++)
                        DeckOfCards.Add(new Card(RedSpade, SuitUnicode, i));
                    DeckOfCards.Add(new Card(RedSpade, SuitUnicode, Convert.ToChar('A')));
                    DeckOfCards.Add(new Card(RedSpade, SuitUnicode, Convert.ToChar('J')));
                    DeckOfCards.Add(new Card(RedSpade, SuitUnicode, Convert.ToChar('Q')));
                    DeckOfCards.Add(new Card(RedSpade, SuitUnicode, Convert.ToChar('K')));
                    RedSpade = false;
                    count++;
                }

            }

            public void Suffle()
            {
                Random r = new Random();
                for (int currentIndex = 0; currentIndex < DeckOfCards.Count; currentIndex++)
                {
                    int randomIndex = r.Next(DeckOfCards.Count);
                    Card SavedValue = DeckOfCards[randomIndex];
                    DeckOfCards[randomIndex] = DeckOfCards[currentIndex];
                    DeckOfCards[currentIndex] = SavedValue;
                }
            }

        }
    }
}
