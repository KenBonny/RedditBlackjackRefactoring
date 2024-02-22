namespace ConsoleExperiment;

internal static class Program
{
	private static readonly Random Random = new();

	private static void PrintDivider() => Console.WriteLine("-------------------------");

	public static void Main(string[] args)
	{
		Console.WriteLine("Welcome to TERMINAL-JACK! - Press any key to continue");
		Console.ReadLine(); // Starts the game
		PrintDivider();
		int milliseconds = 3000;
		int[] card = new int[5]; // Stores generated numbers
		card[0] = Random.Next(1, 11); // First card
		card[1] = Random.Next(1, 11); // Second card
		Console.WriteLine("Your cards are " + card[0] + " and " + card[1]); // Displays cards
		PrintDivider(); // First round
		Console.WriteLine("HIT or CALL?"); // Asks for player input
		string choice = Console.ReadLine(); // Stores the player's choice
		if (choice == "hit")
		{
			card[2] = Random.Next(1, 11); // Third card
			Console.WriteLine(card[2]); // Displays third card
			if (card[0] + card[1] + card[2] > 21) // If card sum > 21 player loses
			{
				PrintDivider();
				Console.WriteLine("GAME OVER;");
				choice = "finish";
			}
			else if (card[0] + card[1] + card[2] == 21) // If card sum == 21 player wins automatically
			{
				PrintDivider();
				Console.WriteLine("YOU WIN!");
				choice = "finish";
			}
			else
			{
				Console.WriteLine("HIT or CALL?"); // Asks for player input
				choice = Console.ReadLine(); // Stores/alters player's choice
				if (choice == "hit")
				{
					card[3] = Random.Next(1, 11); // Fourth card
					Console.WriteLine(card[3]); // Displays fourth card
					if (card[0] + card[1] + card[2] + card[3] > 21) // If card sum > 21 player loses
					{
						PrintDivider();
						Console.WriteLine("GAME OVER;");
						choice = "finish";
					}
					else if (card[0] + card[1] + card[2] + card[3] == 21) // If card sum == 21 player wins automatically
					{
						PrintDivider();
						Console.WriteLine("YOU WIN!");
						choice = "finish";
					}
					else
					{
						Console.WriteLine("HIT or CALL?"); // Asks for player input
						choice = Console.ReadLine(); // Stores/alters player's choice
						if (choice == "hit")
						{
							card[4] = Random.Next(1, 11); // Fifth card
							Console.WriteLine(card[4]); // Displays fifth card
							if (card[0] + card[1] + card[2] + card[3] + card[4] == 21) // If player has drawn five cards without busting, they win automatically
							{
								PrintDivider();
								Console.WriteLine("YOU WIN! You managed to draw five cards without busting!");
								choice = "finish"; // Prevents looping
							}
							else if (card[0] + card[1] + card[2] + card[3] + card[4] > 21) // If card sum > 21 player loses
							{
								PrintDivider();
								Console.WriteLine("GAME OVER;");
								choice = "finish"; // Prevents looping
							}
						}
						else if (choice == "call") // Round three call
						{
							int total = card[0] + card[1] + card[2] + card[3]; // Calculates card total
							Console.WriteLine("Your total is " + total); // Displays card total
							PrintDivider();
							Console.WriteLine("The dealer will now draw cards.");
							int dealer = Random.Next(1, 11);
							int dealer1 = Random.Next(1, 11);
							int dealerTotal = dealer + dealer1; // Calculates dealer's current total
							int dealerBonus = 0; // Used to measure how many bonus cards the dealer draws
							for (; dealerTotal <= total;)
							{
								dealerBonus++;
								for (; dealerBonus > 0; dealerBonus--)
								{
									dealerTotal = dealerTotal + Random.Next(1, 11);
								}
							}

							Thread.Sleep(milliseconds);
							Console.WriteLine("The Dealer's total is " + dealerTotal);
							PrintDivider();
							Thread.Sleep(milliseconds);
							if (dealerTotal > 21)
							{
								Console.WriteLine("YOU WIN! Dealer busts!");
								choice = "finish"; // Prevents looping
							}
							else if (dealerTotal > total && dealerTotal < 22)
							{
								Console.WriteLine("GAME OVER. Dealer is closer.");
								choice = "finish"; // Prevents looping
							}
						}
					}
				}
				else if (choice == "call") // Round two call
				{
					int total = card[0] + card[1] + card[2]; // Calculates card total
					Console.WriteLine("Your total is " + total); // Displays card total
					PrintDivider();
					Console.WriteLine("The dealer will now draw cards.");
					int dealer = Random.Next(1, 11);
					int dealer1 = Random.Next(1, 11);
					int dealerTotal = dealer + dealer1; // Calculates dealer's current total
					int dealerBonus = 0; // Used to measure how many bonus cards the dealer draws
					for (; dealerTotal <= total;)
					{
						dealerBonus++;
						for (; dealerBonus > 0; dealerBonus--)
						{
							dealerTotal = dealerTotal + Random.Next(1, 11);
						}
					}

					Thread.Sleep(milliseconds);
					Console.WriteLine("The Dealer's total is " + dealerTotal);
					PrintDivider();
					Thread.Sleep(milliseconds);
					if (dealerTotal > 21)
					{
						Console.WriteLine("YOU WIN! Dealer busts!");
						choice = "finish"; // Prevents looping
					}
					else if (dealerTotal > total && dealerTotal < 22)
					{
						Console.WriteLine("GAME OVER. Dealer is closer.");
						choice = "finish"; // Prevents looping
					}
				}
			}
		}

		if (choice == "call")
		{
			int total = card[0] + card[1]; // Calculates card total
			Console.WriteLine("Your total is " + total); // Displays card total
			PrintDivider();
			Console.WriteLine("The dealer will now draw cards.");
			int dealer0 = Random.Next(1, 11);
			int dealer1 = Random.Next(1, 11);
			int dealerTotal = dealer0 + dealer1; // Calculates dealer's current total
			int dealerBonus = 0; // Used to measure how many bonus cards the dealer draws
			for (; dealerTotal <= total;)
			{
				dealerBonus++;
				for (; dealerBonus > 0; dealerBonus--)
				{
					dealerTotal += Random.Next(1, 11);
				}
			}

			Thread.Sleep(milliseconds);
			Console.WriteLine("The Dealer's total is " + dealerTotal);
			PrintDivider();
			Thread.Sleep(milliseconds);
			if (dealerTotal > 21)
			{
				Console.WriteLine("YOU WIN! Dealer busts!");
				choice = "finish"; // Prevents looping
			}
			else if (dealerTotal > total && dealerTotal < 22)
			{
				Console.WriteLine("GAME OVER. Dealer is closer.");
				choice = "finish"; // Prevents looping
			}
		}

		if (choice != "finish")
		{
			Console.WriteLine("You absolute donkey.");
			Thread.Sleep(milliseconds - 1500);
			Console.WriteLine("Do you feel good about yourself? Breaking code crafted with blood sweat and tears?");
			Thread.Sleep(milliseconds);
			Console.WriteLine("Enjoy the afterlife. *BANG*");
			Thread.Sleep(milliseconds);
			Console.WriteLine("Press any key to close the window.");
			Console.ReadLine(); // Requires key press before window closes
		}

		Console.WriteLine("Press any key to close the winddow.");
		Console.ReadLine(); //Requires key press before window closes
	}
}