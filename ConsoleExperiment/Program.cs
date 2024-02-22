﻿namespace ConsoleExperiment;

internal static class Program
{
	private static readonly Random Random = new((int)DateTime.Now.Ticks);
	private static int DrawCard() => Random.Next(1, 11);

	private static void PrintDivider() => Console.WriteLine("-------------------------");

	public static void Main(string[] args)
	{
		Console.WriteLine("Welcome to TERMINAL-JACK! - Press any key to continue");
		Console.ReadLine(); // Starts the game
		PrintDivider();
		int milliseconds = 3000;
		int[] hand = new int[5]; // Stores generated numbers
		hand[0] = DrawCard(); // First card
		hand[1] = DrawCard(); // Second card
		Console.WriteLine($"Your cards are {hand[0]} and {hand[1]}"); // Displays cards
		PrintDivider(); // First round
		Console.WriteLine("HIT or CALL?"); // Asks for player input
		string choice = Console.ReadLine(); // Stores the player's choice
		if (choice == "hit")
		{
			hand[2] = DrawCard(); // Third card
			Console.WriteLine(hand[2]); // Displays third card
			if (hand[0] + hand[1] + hand[2] > 21) // If card sum > 21 player loses
			{
				PrintDivider();
				Console.WriteLine("GAME OVER;");
				choice = "finish";
			}
			else if (hand[0] + hand[1] + hand[2] == 21) // If card sum == 21 player wins automatically
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
					hand[3] = DrawCard(); // Fourth card
					Console.WriteLine(hand[3]); // Displays fourth card
					if (hand[0] + hand[1] + hand[2] + hand[3] > 21) // If card sum > 21 player loses
					{
						PrintDivider();
						Console.WriteLine("GAME OVER;");
						choice = "finish";
					}
					else if (hand[0] + hand[1] + hand[2] + hand[3] == 21) // If card sum == 21 player wins automatically
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
							hand[4] = DrawCard(); // Fifth card
							Console.WriteLine(hand[4]); // Displays fifth card
							if (hand[0] + hand[1] + hand[2] + hand[3] + hand[4] == 21) // If player has drawn five cards without busting, they win automatically
							{
								PrintDivider();
								Console.WriteLine("YOU WIN! You managed to draw five cards without busting!");
								choice = "finish"; // Prevents looping
							}
							else if (hand[0] + hand[1] + hand[2] + hand[3] + hand[4] > 21) // If card sum > 21 player loses
							{
								PrintDivider();
								Console.WriteLine("GAME OVER;");
								choice = "finish"; // Prevents looping
							}
						}
						else if (choice == "call") // Round three call
						{
							int total = hand[0] + hand[1] + hand[2] + hand[3]; // Calculates card total
							Console.WriteLine($"Your total is {total}"); // Displays card total
							PrintDivider();
							Console.WriteLine("The dealer will now draw cards.");
							int dealer = DrawCard();
							int dealer1 = DrawCard();
							int dealerTotal = dealer + dealer1; // Calculates dealer's current total
							int dealerBonus = 0; // Used to measure how many bonus cards the dealer draws
							for (; dealerTotal <= total;)
							{
								dealerBonus++;
								for (; dealerBonus > 0; dealerBonus--)
								{
									dealerTotal = dealerTotal + DrawCard();
								}
							}

							Thread.Sleep(milliseconds);
							Console.WriteLine($"The Dealer's total is {dealerTotal}");
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
					int total = hand[0] + hand[1] + hand[2]; // Calculates card total
					Console.WriteLine($"Your total is {total}"); // Displays card total
					PrintDivider();
					Console.WriteLine("The dealer will now draw cards.");
					int dealer = DrawCard();
					int dealer1 = DrawCard();
					int dealerTotal = dealer + dealer1; // Calculates dealer's current total
					int dealerBonus = 0; // Used to measure how many bonus cards the dealer draws
					for (; dealerTotal <= total;)
					{
						dealerBonus++;
						for (; dealerBonus > 0; dealerBonus--)
						{
							dealerTotal = dealerTotal + DrawCard();
						}
					}

					Thread.Sleep(milliseconds);
					Console.WriteLine($"The Dealer's total is {dealerTotal}");
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
			int total = hand[0] + hand[1]; // Calculates card total
			Console.WriteLine($"Your total is {total}"); // Displays card total
			PrintDivider();
			Console.WriteLine("The dealer will now draw cards.");
			int dealer0 = DrawCard();
			int dealer1 = DrawCard();
			int dealerTotal = dealer0 + dealer1; // Calculates dealer's current total
			int dealerBonus = 0; // Used to measure how many bonus cards the dealer draws
			for (; dealerTotal <= total;)
			{
				dealerBonus++;
				for (; dealerBonus > 0; dealerBonus--)
				{
					dealerTotal += DrawCard();
				}
			}

			Thread.Sleep(milliseconds);
			Console.WriteLine($"The Dealer's total is {dealerTotal}");
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