namespace ConsoleExperiment;

internal static class Program
{
	private const string Hit = "hit";
	private const string Call = "call";
	private const string Finish = "finish";
	private const int LastRound = 4;
	private const int Blackjack = 21;
	private static readonly Random Random = new((int)DateTime.Now.Ticks);
	private static int DrawCard() => Random.Next(1, 11);
	private static int Total(int[] hand) => hand.Sum();
	private static bool IsBust(int[] hand) => Total(hand) > Blackjack;
	private static bool IsBlackjack(int[] hand) => Total(hand) == Blackjack;

	private static void PrintDivider() => Console.WriteLine("-------------------------");
	private const int WaitTime = 3000;
	private static void Wait() => Thread.Sleep(WaitTime);

	private static string? Choose()
	{
		Console.WriteLine("HIT or CALL?"); // Asks for player input
		return Console.ReadLine(); // Stores the player's choice
	}

	private static string DetermineWinOrLoose(int[] hand, bool isLastRound)
	{
		if (IsBlackjack(hand)) // If player has drawn five cards without busting, they win automatically
		{
			PrintDivider();
			Console.WriteLine(isLastRound ? "YOU WIN! You managed to draw five cards without busting!" : "YOU WIN!");

			return Finish; // Prevents looping
		}
		else if (IsBust(hand)) // If card sum > 21 player loses
		{
			PrintDivider();
			Console.WriteLine("GAME OVER;");
			return Finish; // Prevents looping
		}

		return string.Empty;
	}

	public static void Main(string[] args)
	{
		Console.WriteLine("Welcome to TERMINAL-JACK! - Press any key to continue");
		Console.ReadLine(); // Starts the game
		PrintDivider();
		int[] hand = new int[5]; // Stores generated numbers
		hand[0] = DrawCard(); // First card
		hand[1] = DrawCard(); // Second card
		Console.WriteLine($"Your cards are {hand[0]} and {hand[1]}"); // Displays cards
		PrintDivider(); // First round
		string? choice = Choose();
		int round = 1; // Card counter
		while (choice == Hit && round <= LastRound)
		{
			round++;
			hand[round] = DrawCard();
			Console.WriteLine(hand[round]);
			choice = DetermineWinOrLoose(hand, round == LastRound);
			if (choice != Finish)
			{
				choice = Choose();
			}
		}

		if (choice == Call)
		{
			choice = PlayDealer(hand);
		}

		if (choice != Finish)
		{
			Console.WriteLine("You absolute donkey.");
			Wait();
			Console.WriteLine("Do you feel good about yourself? Breaking code crafted with blood sweat and tears?");
			Wait();
			Console.WriteLine("Enjoy the afterlife. *BANG*");
			Wait();
			Console.WriteLine("Press any key to close the window.");
			Console.ReadLine(); // Requires key press before window closes
		}

		Console.WriteLine("Press any key to close the winddow.");
		Console.ReadLine(); //Requires key press before window closes
	}

	private static string PlayDealer(int[] hand)
	{
		int total = Total(hand); // Calculates card total
		Console.WriteLine($"Your total is {total}"); // Displays card total
		PrintDivider();
		Console.WriteLine("The dealer will now draw cards.");
		int dealerTotal = DrawCard() + DrawCard(); // Calculates dealer's current total
		while (dealerTotal <= total)
		{
			dealerTotal += DrawCard();
		}

		Wait();
		Console.WriteLine($"The Dealer's total is {dealerTotal}");
		PrintDivider();
		Wait();
		if (dealerTotal > Blackjack)
		{
			Console.WriteLine("YOU WIN! Dealer busts!");
			return "finish"; // Prevents looping
		}
		else if (dealerTotal > total)
		{
			Console.WriteLine("GAME OVER. Dealer is closer.");
			return "finish"; // Prevents looping
		}

		return string.Empty;
	}
}