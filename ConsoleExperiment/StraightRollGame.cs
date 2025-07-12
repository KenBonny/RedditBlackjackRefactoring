namespace ConsoleExperiment;

public static class StraightRollGame
{
    public static void Play()
    {
        var rng = Random.Shared;
        List<int> diceStraight = [1, 2, 3, 4, 5, 6];

        do
        {
            // While R key is true, loop through 6 iterations of a random number gen. Each RNG
            // loop, another 6 loop runs (36 potential loops total) to check if each value added to
            // our list "diceRoll" == the predefined values of our list "diceStraight". If so,
            // boolean "rolledStraight" is true, and our integer tally "straightCheck" gets added to,
            // else straightCheck is nullified for that loop. If the tally reaches or exceeds 6,
            // the user has a straight.
            Console.WriteLine("Press R to roll...\n");
            if (Console.ReadKey().Key != ConsoleKey.R)
                continue;

            int straightCheck = 0;

            Console.WriteLine("\n");
            var diceRoll = Enumerable.Range(1, 6).Select(_ => rng.Next(1, 7)).ToList();

            for (int n = 0; n < 6; n++)
            {
                bool rolledStraight = diceRoll.Contains(diceStraight[n]);
                if (rolledStraight)
                {
                    straightCheck++;
                    //Console.WriteLine($"i={i} n={n} Straight Check={straightCheck}");
                }
                else
                {
                    straightCheck = 0;
                    Console.WriteLine("________RE-SET________");
                }
            }

            if (straightCheck >= 6)
            {
                Console.WriteLine(">_>_>_STRAIGHT_<_<_<");
            }

            foreach (int number in diceRoll)
            {
                Console.WriteLine($" dice: {number}");
            }
        } while (true);
    }
}