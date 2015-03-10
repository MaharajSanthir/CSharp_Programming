using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

/*      Developer Name: Maharaj Santhir
 *      Course Code:    PRO670                
 *      School:         Seneca College, Toronto, Ontario
 *      Prof Name:      John Kane
 *      Assignment:     Memory Game with Deck of Playing Cards - C# Console Application
 */

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            // Begin a game by initating a Game class
            Game Game1 = new Game();
            // Begin the Game play.
            Game1.GamePlay();
           
         }
        // Game class that runs the game after getting player information and preparing cards into game table.
        class Game
        {
            // Fields
            public List<Player> PlayersList = new List<Player>();
            public BoxOfPlayingCards DeckOfCards = new BoxOfPlayingCards();
            public GameTable MemoryGameTable = new GameTable();
            // Constructor
            public Game()
            {
                WelcomeScreen();
                PrepareGame();
            }
            // Public Method
            public void GamePlay()
            {
                while (PlayersList.Sum(item => item.PlayerScore) != 26)
                {
                    foreach (Player CurrentPlayer in PlayersList)
                    {
                        bool FlipAllCards_FaceDown = true;
                        int CurrentPlayerNum = CurrentPlayer.PlayerNum + 1;

                        Display_PlayerTurnScreen(CurrentPlayerNum);

                        // Uncomment the below commented code - To see all cards - Use it for testing purpose.
                        //****************************************************************************************
                        // Uncommenting this will display all cards in the grid just after the 
                        // display of "player turn" screen and before the player enter the first coordination.
                        // It will display the grid for all players.

                        /*
                        Display_PlayerTurnHeader(CurrentPlayerNum);
                        MemoryGameTable.Display_CardGrid(false, null, null);
                        Console.Write("Press ENTER to Begin:");
                        Console.ReadLine();
                        Console.Clear();
                        */

                        Display_PlayerTurnHeader(CurrentPlayerNum);
                        MemoryGameTable.Display_CardGrid(FlipAllCards_FaceDown, null, null);
                        CurrentPlayer.SelectCard(ref MemoryGameTable.CardGrid);
                        Console.Clear();

                        Display_PlayerTurnHeader(CurrentPlayerNum);
                        MemoryGameTable.Display_CardGrid(FlipAllCards_FaceDown, CurrentPlayer.FirstSelection, null);
                        CurrentPlayer.SelectCard(ref MemoryGameTable.CardGrid);
                        Console.Clear();

                        Display_PlayerTurnHeader(CurrentPlayerNum);
                        MemoryGameTable.Display_CardGrid(FlipAllCards_FaceDown, CurrentPlayer.FirstSelection, CurrentPlayer.SecondSelection);

                        if (
                            (MemoryGameTable.CardGrid[CurrentPlayer.FirstSelection.x, CurrentPlayer.FirstSelection.y].CardNum ==
                            MemoryGameTable.CardGrid[CurrentPlayer.SecondSelection.x, CurrentPlayer.SecondSelection.y].CardNum)
                            &&
                            (MemoryGameTable.CardGrid[CurrentPlayer.FirstSelection.x, CurrentPlayer.FirstSelection.y].CardRed ==
                            MemoryGameTable.CardGrid[CurrentPlayer.SecondSelection.x, CurrentPlayer.SecondSelection.y].CardRed)
                        )
                        {
                            Console.Write("\n    ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("    ");
                            Console.Write("*************  MATCH ************* + 1");
                            Console.Write("    \n");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            CurrentPlayer.PlayerScore++;
                            MemoryGameTable.CardGrid[CurrentPlayer.FirstSelection.x, CurrentPlayer.FirstSelection.y] = null;
                            MemoryGameTable.CardGrid[CurrentPlayer.SecondSelection.x, CurrentPlayer.SecondSelection.y] = null;

                        }
                        else
                        {
                            Console.Write("\n  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("    ");
                            Console.Write("*************  NOT A MATCH *************");
                            Console.Write("    \n");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Gray;

                        }

                        // Clear player selections so next time it stores the new selections.
                        CurrentPlayer.FirstSelection = null;
                        CurrentPlayer.SecondSelection = null;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\n  Press ENTER to continue...");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }

                Display_Winners();
            }
            // Private Methods
            private void WelcomeScreen()
            {
                int InputNumPlayers = 0;
                bool isNumber = false;

                Console.WriteLine("Welcome to Memory Game");

                // Prompt for Number of Players. Validate user entry for numbers 2, 3 or 4
                Console.Write("Enter number of players (Min 2 Max 4):");
                while (!isNumber)
                {
                    string InputStr = Console.ReadLine();
                    if ((Int32.TryParse(InputStr, out InputNumPlayers)) && (InputNumPlayers == 2 || InputNumPlayers == 3 || InputNumPlayers == 4))
                        isNumber = true;
                    else
                        Console.Write("Wrong, Enter only numbers between 2-4:");
                }

                // Add players to the list
                for (int i = 0; i < InputNumPlayers; i++)
                    PlayersList.Add(new Player(i));

                Regex PlayerNameEx = new Regex(@"^[a-zA-Z]{2,8}$");
                Console.Write("\nWhen prompted, enter name for each players. \nName must be any letters, minimum 2 and maximum 8.\n\n");
                string turn="";
                string UserInputName="";
                for (int i = 0; i < InputNumPlayers; i++)
                {
                    if(i==0)
                        turn = "FIRST";
                    if(i==1)
                        turn = "SECOND";
                    if(i==2)
                        turn = "THIRD";
                    if(i==3)
                        turn = "FOURTH";

                    Console.Write("Enter {0} player name: ", turn);
                    UserInputName = Console.ReadLine();

                    while(!PlayerNameEx.IsMatch(UserInputName))
                    {
                        Console.Write("Wrong. Name must be any letters, minimum 4 and maximum 8.\n");
                        Console.Write("Enter {0} player name: ", turn);
                        UserInputName = Console.ReadLine();
                    }

                    PlayersList[i].PlayerName = UserInputName;
                }

                ShufflePlayers();
                Console.Clear();
            }
            private void PrepareGame()
            {
                DeckOfCards.Shuffle();
                MemoryGameTable.ArrangeCards_Into_CardGrid(ref DeckOfCards);
            }
            private void ShufflePlayers()
            {
                Random r = new Random();
                for (int currentIndex = 0; currentIndex < PlayersList.Count; currentIndex++)
                {
                    int randomIndex = r.Next(PlayersList.Count);
                    string SavedValue = PlayersList[randomIndex].PlayerName;
                    PlayersList[randomIndex].PlayerName = PlayersList[currentIndex].PlayerName;
                    PlayersList[currentIndex].PlayerName = SavedValue;
                }
            }
            private void Display_Winners()
            {
                Console.WriteLine("Memory Game - Deck of Cards");
                for (int i = 0; i < 5; i++)
                    Console.WriteLine(" ");
                Console.Write("     Final Score\n");
                Console.Write("     -----------\n\n");

                PlayersList = PlayersList.OrderByDescending(item => item.PlayerScore).ToList();
                foreach (Player p in PlayersList)
                {
                    Console.Write("     Player {0} - Name: {1} - Score: {2}", p.PlayerNum + 1, p.PlayerName, p.PlayerScore);
                    if (p.PlayerScore == PlayersList[0].PlayerScore)
                        Console.Write(" - Winner\n");
                    else
                        Console.Write(" - Looser\n");
                }
                Console.Write("\n\n     Game Over \n\n\n\n");
            }
            private void Display_PlayerTurnHeader(int PlayerNumPassed)
            {
                Console.Write("                            ");
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Memory Game - Deck of Cards ");
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("       Score Board      ");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" Game Rules: Select two playing cards from the table. \n");
                Console.Write("------------------------");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" if they match, you will get one point.               \n");
                foreach (Player i in PlayersList)
                {
                    int AddSpace = 8 - i.PlayerName.Length;
                    string PlayerNameJustified = i.PlayerName;
                    for (int a = 0; a < AddSpace; a++)
                        PlayerNameJustified += " ";
                    Console.WriteLine("Player {0} - {1} : {2} ", i.PlayerNum + 1, PlayerNameJustified, i.PlayerScore);
                }
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("                                  Player {0} - {1}!\n", PlayerNumPassed, PlayersList[PlayerNumPassed-1].PlayerName);
            }
            private void Display_PlayerTurnScreen(int PlayerNumPassed)
            {
                Display_PlayerTurnHeader(PlayerNumPassed);
                for (int i = 0; i < 3; i++)
                    Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                              {0}, it's your turn!\n", PlayersList[PlayerNumPassed-1].PlayerName);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Press ENTER when you are ready!");
                Console.ReadLine();
                Console.Clear();
            }
        }
        // A game table to arrange cards and display cards for players to select.
        class GameTable
        {
            //Field
            public Card[,] CardGrid = new Card[4, 13];
            //Public Methods
            public void ArrangeCards_Into_CardGrid(ref BoxOfPlayingCards DeckOfCardsPassed)
            {
                int x = 0, y = 0;
                foreach (Card c in DeckOfCardsPassed.AllOfPlayingCards)
                {
                    if (y % 13 == 0 && y != 0)
                    {
                        x++; y = 0;
                    }
                    CardGrid[x, y] = c;
                    y++;
                }
            }
            public void Display_CardGrid(bool AllCardsFaceDown, Coordinate ShowCard_One, Coordinate ShowCard_Two)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("     A    B    C    D    E    F    G    H    I    J    K    L    M   \n");
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.Black;

                for (int x = 0; x < 4; x++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" {0} ", x + 1);
                    Console.ForegroundColor = ConsoleColor.Black;
                    for (int y = 0; y < 13; y++)
                        if (AllCardsFaceDown == true)
                        {
                            if (CardGrid[x, y] != null)
                            {
                                CardGrid[x, y].FaceDown = true;

                                if (ShowCard_One != null && x == ShowCard_One.x && y == ShowCard_One.y)
                                    CardGrid[ShowCard_One.x, ShowCard_One.y].FaceDown = false;

                                if (ShowCard_Two != null && x == ShowCard_Two.x && y == ShowCard_Two.y)
                                    CardGrid[ShowCard_Two.x, ShowCard_Two.y].FaceDown = false;
                            }

                            DrawCard_ToConsole(ref CardGrid[x, y]);
                        }
                        else
                        {
                            if (CardGrid[x, y] != null)
                                CardGrid[x, y].FaceDown = false;
                            DrawCard_ToConsole(ref CardGrid[x, y]);
                        }
                    Console.Write("\n");
                    Console.Write("\n");
                }
            }
            // Private Method
            private void DrawCard_ToConsole(ref Card card)
            {
                Console.BackgroundColor = ConsoleColor.White;

                if (card == null)
                    Console.Write(" XX ");
                else
                {
                    if (card.CardRed)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Black;

                    if (card.FaceDown)
                        Console.Write("    ");
                    else
                    {
                        if (card.CardNum == 49)
                            Console.Write(" {0}{1}0", card.CardSuit, card.CardNum);
                        else
                            Console.Write(" {0}{1} ", card.CardSuit, card.CardNum);
                    }
                }
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ");

            }
        }
        // Stores the player information and allow player to select cards from game table.
        class Player
        {
            //Fields
            public int PlayerNum { get; set; }
            public int PlayerScore { get; set; }
            public string PlayerName { get; set; }
            public Coordinate FirstSelection = null;
            public Coordinate SecondSelection = null;
            //Overloaded Constructor
            public Player(int PNum)
            {
                PlayerNum = PNum;
                PlayerScore = 0;
            }
            //Public Method
            public void SelectCard(ref Card[,] CardGrid)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                bool loop = true;
                string turn = "";
                Regex CoordLetterNumEx = new Regex(@"^[a-mA-M][1234]$");

                Coordinate CurrentSelection = new Coordinate();
                int x, y;

                if (FirstSelection == null)
                    turn = "FIRST";
                else
                    turn = "SECOND";

                Console.Write("Enter coordinate of your {0} selection as Letter-Number: ", turn);
                string CoordinateEntry = Console.ReadLine();

                while (loop)
                {
                    if (!CoordLetterNumEx.IsMatch(CoordinateEntry))
                    {
                        Console.Write("Wrong. Enter correct coordinate location [ex. A-M 1-4]: ");
                        CoordinateEntry = Console.ReadLine();
                        loop = true;
                    }
                    else
                    {
                        x = int.Parse(CoordinateEntry.Substring(1, 1)) - 1;
                        y = (int)Encoding.ASCII.GetBytes(CoordinateEntry.Substring(0, 1).ToString())[0] - 97;

                        if (CardGrid[x, y] == null)
                        {
                            loop = true;
                            CoordinateEntry = "";
                            Console.Write("Card Eliminated. ");
                        }
                        else
                        {
                            if (FirstSelection == null)
                            {
                                FirstSelection = new Coordinate();
                                FirstSelection.x = x;
                                FirstSelection.y = y;
                                loop = false;
                            }
                            else
                            {
                                if (FirstSelection.x == x && FirstSelection.y == y)
                                {
                                    loop = true;
                                    CoordinateEntry = "";
                                    Console.Write("SECOND coordinate should not be same as FIRST. \n");
                                }
                                else
                                {
                                    SecondSelection = new Coordinate();
                                    SecondSelection.x = x;
                                    SecondSelection.y = y;
                                    loop = false;
                                }
                            }
                        }
                    }
                }

            }
        }
        // Generate a playing card with card number, card color and suit. Also includes a boolean to note if the card is placed faced down.
        class Card
        {
            //Fields
            private char Num;
            private bool Red;
            private char Suit;
            public bool FaceDown = false;
            //Properties
            public bool CardRed { get {return Red ;} }
            public char CardNum { get { return Num;} }
            public char CardSuit { get { return Suit;} }
            //Overloaded Constructor
            public Card(bool CardRedPassed, char SuitPassed, int NumPassed)
            {
                Num = Convert.ToChar(NumPassed);
                Red = CardRedPassed;
                Suit = SuitPassed;
            }
        }
        // Represent a box of playing card; therefore it contains 52 sets of cards in a List of Card class format.
        class BoxOfPlayingCards
        {
            //Fields
            public List<Card> AllOfPlayingCards = new List<Card>();
            //Public Methods
            public BoxOfPlayingCards()
            {
                AddCardsBySuit('\u2660', false); // Spade
                AddCardsBySuit('\u2665', true); // Heart
                AddCardsBySuit('\u2663', false); // Club
                AddCardsBySuit('\u2666', true); // Diamond
            }
            public void Shuffle()
            {
                Random r = new Random();
                for (int currentIndex = 0; currentIndex < AllOfPlayingCards.Count; currentIndex++)
                {
                    int randomIndex = r.Next(AllOfPlayingCards.Count);
                    Card SavedValue = AllOfPlayingCards[randomIndex];
                    AllOfPlayingCards[randomIndex] = AllOfPlayingCards[currentIndex];
                    AllOfPlayingCards[currentIndex] = SavedValue;
                }
            }
            //Private Method
            private void AddCardsBySuit(char SuitUnicode, bool SuitRed)
            {
                for (int i = 49; i < 58; i++)
                    AllOfPlayingCards.Add(new Card(SuitRed, SuitUnicode, i));
                AllOfPlayingCards.Add(new Card(SuitRed, SuitUnicode, Convert.ToChar('A')));
                AllOfPlayingCards.Add(new Card(SuitRed, SuitUnicode, Convert.ToChar('J')));
                AllOfPlayingCards.Add(new Card(SuitRed, SuitUnicode, Convert.ToChar('Q')));
                AllOfPlayingCards.Add(new Card(SuitRed, SuitUnicode, Convert.ToChar('K')));
            }
        }
        // A coordinate class to use with the grid by using x and y for position variables.
        class Coordinate
        {
            //Fields
            public int x, y;
        }
    }
}