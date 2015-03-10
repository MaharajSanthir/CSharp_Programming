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
            // Setting the default color as Gray Background and Black text
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
            // List to hold the players. Each player has player number, player name and player score
            public List<Player> PlayersList = new List<Player>();
            // Unbox of deck of cards from a box of playing cards. There will be 52 cards in list
            public BoxOfPlayingCards DeckOfCards = new BoxOfPlayingCards();
            // Prepare the game table for this memory game. It will be used to place cards and let players select cards. 
            public GameTable MemoryGameTable = new GameTable();
            // Constructor: Call Welcome methods and the PrepareGame Methods
            public Game()
            {   // Prompt for player information to begin game
                WelcomeScreen();
                // Call prepare game method to prepare cards and table
                PrepareGame();
            }
            // Public Method
            // Coordinate the game play: each player get a turn to select a card and winner gets one point.
            public void GamePlay()
            {
                // End the game when the the sum of all players score is 26
                // where the all cards are matched
                // Programmer note: Sum function for List require System.Linq (Make sure you remember this for future coding)
                while (PlayersList.Sum(item => item.PlayerScore) != 26)
                {
                    foreach (Player CurrentPlayer in PlayersList)
                    {
                        bool FlipAllCards_FaceDown = true;
                        int CurrentPlayerNum = CurrentPlayer.PlayerNum + 1;

                        // Display the player turn screen with player name
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

                        // Player Turn Screen
                        // Generate screen to ask for First Selection
                        Display_PlayerTurnHeader(CurrentPlayerNum);
                        // Display the game table where the grid of card is shown
                        // At the his point the player hasn't selected the first card yet
                        // therefore all cards are displayed faced down
                        MemoryGameTable.Display_CardGrid(FlipAllCards_FaceDown, null, null);
                        // Ask the player to select the first card from the grid passed
                        CurrentPlayer.SelectCard(ref MemoryGameTable.CardGrid);
                        Console.Clear();

                        // Player Turn Screen
                        // Generate screen to ask for Second Selection
                        Display_PlayerTurnHeader(CurrentPlayerNum);
                        // Display the game table where the grid of card is shown
                        // At the his point the player has already selected the first card,
                        // therefore display the first card face up, and the rest as faced down
                        MemoryGameTable.Display_CardGrid(FlipAllCards_FaceDown, CurrentPlayer.FirstSelection, null);
                        // Ask the player to select the second card from the grid passed
                        CurrentPlayer.SelectCard(ref MemoryGameTable.CardGrid);
                        Console.Clear();

                        // Player Turn Screen
                        // Generate screen to display result as match or not and points earned
                        Display_PlayerTurnHeader(CurrentPlayerNum);
                        // Display the game table where the grid of card is shown
                        // At the his point the player has already selected the first and second card,
                        // therefore display the first card and second card face up, and the rest as faced down
                        MemoryGameTable.Display_CardGrid(FlipAllCards_FaceDown, CurrentPlayer.FirstSelection, CurrentPlayer.SecondSelection);

                        // if the first and second card color and number matches, the player gets one point 
                        if (
                            (MemoryGameTable.CardGrid[CurrentPlayer.FirstSelection.x, CurrentPlayer.FirstSelection.y].CardNum ==
                            MemoryGameTable.CardGrid[CurrentPlayer.SecondSelection.x, CurrentPlayer.SecondSelection.y].CardNum)
                            &&
                            (MemoryGameTable.CardGrid[CurrentPlayer.FirstSelection.x, CurrentPlayer.FirstSelection.y].CardRed ==
                            MemoryGameTable.CardGrid[CurrentPlayer.SecondSelection.x, CurrentPlayer.SecondSelection.y].CardRed)
                        )
                        {
                            // Cards matches
                            // Displaty MATCH
                            Console.Write("\n    ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("    ");
                            Console.Write("*************  MATCH ************* + 1");
                            Console.Write("    \n");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            // Player get one point
                            CurrentPlayer.PlayerScore++;
                            // Make the first and second card null in the grid to indicate they are removed
                            MemoryGameTable.CardGrid[CurrentPlayer.FirstSelection.x, CurrentPlayer.FirstSelection.y] = null;
                            MemoryGameTable.CardGrid[CurrentPlayer.SecondSelection.x, CurrentPlayer.SecondSelection.y] = null;

                        }
                        else
                        {
                            // Cards did not match
                            // Display NOT A MATCH
                            Console.Write("\n  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("    ");
                            Console.Write("*************  NOT A MATCH *************");
                            Console.Write("    \n");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            // 
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
            // Prompt users to input number of players and enter name for each players
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
                // Regex for player name validation. 
                Regex PlayerNameEx = new Regex(@"^[a-zA-Z]{2,8}$");
                Console.Write("\nWhen prompted, enter name for each players. \nName must be any letters, minimum 2 and maximum 8.\n\n");
                string turn="";
                string UserInputName="";
                // Add player name to the playerlist list of the game
                for (int i = 0; i < InputNumPlayers; i++)
                {
                    // To help user enter names  
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
                    // Validate user enter for min 4 max 8 letters
                    while(!PlayerNameEx.IsMatch(UserInputName))
                    {
                        Console.Write("Wrong. Name must be any letters, minimum 4 and maximum 8.\n");
                        Console.Write("Enter {0} player name: ", turn);
                        UserInputName = Console.ReadLine();
                    }
                    // Add the valide player name to the player list
                    PlayersList[i].PlayerName = UserInputName;
                }
                // Shuffle the player name and maintain the order for the whole game
                ShufflePlayers();
                Console.Clear();
            }
            // Prepare game by shuffling the cards and preparing the memory game table
            private void PrepareGame()
            {   // Shuffle the deck of cards
                DeckOfCards.Shuffle();
                // Arrange the shuffled cards into a grid
                MemoryGameTable.ArrangeCards_Into_CardGrid(ref DeckOfCards);
            }
            // Shuffle the players in the playerlist
            private void ShufflePlayers()
            {
                Random r = new Random();
                // Randomly choose a number within the list range and switch 
                // the value of it with the current index of the for loop.
                // Therefore, this loop shuffle the player names within the same player list.
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
                // Display the player score 
                Console.WriteLine("Memory Game - Deck of Cards");
                for (int i = 0; i < 5; i++)
                    Console.WriteLine(" ");
                Console.Write("     Final Score\n");
                Console.Write("     -----------\n\n");

                // Sort the player list by the highest score first
                // Then display the top number as the winner. 
                // If any other player has the same score as the top number,
                // Then it must be a tie, therefore display them as winner as well.
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
                // Display the information for the game at the top 
                // of each screen. This method draws the score board and the 
                // Game rules information at top of every screen
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
                // Each player score is printed
                // To maintain a justified look for the score board,
                // Player name is filtered for 8 charactors and any name
                // with less than 8 charactor is added some extra space to
                // make it 8 and then when printed the result is justified.
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
                // Display a screen before the player turn begins
                // Allow user to press enter to indicate that he or she is ready
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
            // Arrange the deck of cards to a two dimensional grid. 
            // Therefore, it allows the player to select a card by giving
            // Grid coordination. It also allow the matching card to be removed 
            // and set to null for the users to identify the location of the removed cards.
            public void ArrangeCards_Into_CardGrid(ref BoxOfPlayingCards DeckOfCardsPassed)
            {
                int x = 0, y = 0;
                // Coping the list of cards into the two dimensional array of card data type
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
            // Once the grid is initiated this method is called to display the cards on the table
            // When the boolean AllCardsFaceDown is passed as true, the the table display all cards
            // face down and when it is passed false, then all cards will be flip to the front side where 
            // we can see their number, color and suit. The coordinate values ShowCard_One and ShowCard_Two
            // are passed as null before the selection. When a player select a card, then this coordinate value is 
            // passed. At this time, the selected coordinate will display the card infromation.
            public void Display_CardGrid(bool AllCardsFaceDown, Coordinate ShowCard_One, Coordinate ShowCard_Two)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Blue;
                // Horizontal grid coordinate identification letters
                Console.Write("     A    B    C    D    E    F    G    H    I    J    K    L    M   \n");
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.Black;

                // Draw the vertical grid coordinate 
                for (int x = 0; x < 4; x++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" {0} ", x + 1);
                    Console.ForegroundColor = ConsoleColor.Black;
                    // Draw the horizontal grid coordinate
                    for (int y = 0; y < 13; y++)
                        if (AllCardsFaceDown == true)
                        {
                            // if the card at this grid location is not empty (removed)
                            if (CardGrid[x, y] != null)
                            {   // Then set the card to facedown 
                                CardGrid[x, y].FaceDown = true;
                                // Show the detail of the card such as card num, color and suit
                                if (ShowCard_One != null && x == ShowCard_One.x && y == ShowCard_One.y)
                                    CardGrid[ShowCard_One.x, ShowCard_One.y].FaceDown = false;
                                // Show the detail of the card such as card num, color and suit
                                if (ShowCard_Two != null && x == ShowCard_Two.x && y == ShowCard_Two.y)
                                    CardGrid[ShowCard_Two.x, ShowCard_Two.y].FaceDown = false;
                            }
                            // Draw the card to the console according the condition set
                            DrawCard_ToConsole(ref CardGrid[x, y]);
                        }
                        else
                        {
                            // if the card at this grid location is not empty (removed), 
                            // then set it to display the front.
                            if (CardGrid[x, y] != null)
                                CardGrid[x, y].FaceDown = false;
                            // Draw the card to the console according the condition set
                            DrawCard_ToConsole(ref CardGrid[x, y]);
                        }
                    Console.Write("\n");
                    Console.Write("\n");
                }
            }
            // Private Method
            private void DrawCard_ToConsole(ref Card card)
            {
                // Setting the background to white 
                // to indicate that it is playing a card
                Console.BackgroundColor = ConsoleColor.White;
                // If the card at null then the card must be removed during the previous plays
                // therefore it should display XX to indicate that the card is removed.
                if (card == null)
                    Console.Write(" XX ");
                else
                {
                    // Setting the color of the card according their values: red or blacj
                    if (card.CardRed)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Black;
                    // The empty values indicate that the card is faced down
                    if (card.FaceDown)
                        Console.Write("    ");
                    else
                    {   // Card num is stored as Char value, therefore number 10 can not be stored in it
                        // Number 10 is stored as 1, therefore, this if statement convert 1 into 10
                        // Else, just display the number
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
            // Player must be initiated with the player number
            public Player(int PNum)
            {
                PlayerNum = PNum;
                PlayerScore = 0;
            }
            //Public Method
            // This method allows the player to choose a location of a card
            // from the grid passed to it. The grid contains the cards from memory game table
            // with all the available after the matched cards are removed (null).
            public void SelectCard(ref Card[,] CardGrid)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                bool loop = true;
                string turn = "";
                Regex CoordLetterNumEx = new Regex(@"^[a-mA-M][1234]$");
                Coordinate CurrentSelection = new Coordinate();
                int x, y;
                // Indicate that the selection is the first or second based
                // on whether the first selection is available
                if (FirstSelection == null)
                    turn = "FIRST";
                else
                    turn = "SECOND";

                Console.Write("Enter coordinate of your {0} selection as Letter-Number: ", turn);
                string CoordinateEntry = Console.ReadLine();
                // Loop will keep running until the correct coordinate is entered
                // This loop validates multiple conditions of a valid coordinate
                while (loop)
                {
                    // If user entry is other than a signle letter followed by a single digit
                    // Ask to reenter
                    if (!CoordLetterNumEx.IsMatch(CoordinateEntry))
                    {
                        Console.Write("Wrong. Enter correct coordinate location [ex. A-M 1-4]: ");
                        CoordinateEntry = Console.ReadLine();
                        loop = true;
                    }
                    else
                    {   // Store the valid user entry into x, y where the letter is 
                        // converted into a digit form of the coordinate 
                        x = int.Parse(CoordinateEntry.Substring(1, 1)) - 1;
                        y = (int)Encoding.ASCII.GetBytes(CoordinateEntry.Substring(0, 1).ToString())[0] - 97;

                        // if the user entered coordinate is for the already removed (null)card 
                        // ask to reenter
                        if (CardGrid[x, y] == null)
                        {
                            loop = true;
                            CoordinateEntry = "";
                            Console.Write("Card Eliminated. ");
                        }
                        else
                        {
                            if (FirstSelection == null)
                            {   // Save the coordinate as the first selection
                                FirstSelection = new Coordinate();
                                FirstSelection.x = x;
                                FirstSelection.y = y;
                                loop = false;
                            }
                            else
                            {   // if the user is entered Second coordinate and it is same as the
                                // First coordinate, ask to reenter
                                if (FirstSelection.x == x && FirstSelection.y == y)
                                {
                                    loop = true;
                                    CoordinateEntry = "";
                                    Console.Write("SECOND coordinate should not be same as FIRST. \n");
                                }
                                else
                                {   // Save the coordinate as the second selection
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
            // Fields
            private char Num;
            private bool Red;
            private char Suit;
            public bool FaceDown = false;
            // Properties
            public bool CardRed { get {return Red ;} }
            public char CardNum { get { return Num;} }
            public char CardSuit { get { return Suit;} }
            // Overloaded Constructor
            // Card must be initiated with color, suit and number 
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
            // Box of cards are initiated by adding playing cards to it
            // There will be 13 cards of each suit and this constructor adds
            // All the needed cards to it.
            public BoxOfPlayingCards()
            {   // Calling the methods that add cards to the list of data type card
                // first parameter is the unicode value for the suit
                // and the second parameter indicate that it is color red or not
                AddCardsBySuit('\u2660', false); // Spade
                AddCardsBySuit('\u2665', true); // Heart
                AddCardsBySuit('\u2663', false); // Club
                AddCardsBySuit('\u2666', true); // Diamond
            }
            public void Shuffle()
            {
                // Randomly choose a number within the list range and switch 
                // the value of it with the current index of the for loop.
                // Therefore, this loop shuffle the card of the card datatype value of the list.
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
            {   // The loop add cards as color red or not, the unicode value of the suit 
                // and the card number between the range 1-9   
                for (int i = 49; i < 58; i++)
                    AllOfPlayingCards.Add(new Card(SuitRed, SuitUnicode, i));
                // The individual method calls add cards as color red or not, the unicode value 
                // of the suit and the card number as A, J, Q and K  
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
            // Integer values to hold the coordinate values for 
            // the card grid in the memory game table
            public int x, y;
        }
    }
}