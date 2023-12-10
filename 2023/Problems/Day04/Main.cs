using Common;
using Common.Helpers;

namespace Problems.Day04;

public class Main : IAdventOfCodeProblem
{
    public string ProblemNumber => "04";

    public async Task<string> RunPart1(bool useSample)
    {
        List<string> lines = (await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample)).ToList();

        int cumulativeScore = 0;

        foreach (string line in lines)
        {
            string numbersSection = line.Split(':').ElementAt(1);
            string[] halves = numbersSection.Split('|');
            var winners = halves.ElementAt(0).Trim().Split(' ').Where(s => !string.IsNullOrEmpty(s));
            var ourNumbers = halves.ElementAt(1).Trim().Split(' ').Where(s => !string.IsNullOrEmpty(s));

            int overlappingNumbers = ourNumbers.Intersect(winners).Count();

            int score;
            if (overlappingNumbers == 1)
            {
                score = 1;
            }
            else if (overlappingNumbers > 0)
            {
                score = (int)Math.Pow(2, overlappingNumbers - 1);
            }
            else
            {
                score = 0;
            }

            cumulativeScore += score;
        }

        return cumulativeScore.ToString();
    }

    public async Task<string> RunPart2(bool useSample)
    {
        List<string> lines = (await PuzzleInputReader.GetPuzzleInputs(ProblemNumber, 1, useSample)).ToList();
        
        Queue<int> cardsQueue = new();

        foreach (int i in Enumerable.Range(0, lines.Count))
        {
            cardsQueue.Enqueue(i);
        }
        int totalCards = lines.Count;

        while (cardsQueue.Count != 0)
        {
            int currentCard = cardsQueue.Dequeue();

            string line = lines.ElementAt(currentCard);

            string numbersSection = line.Split(':').ElementAt(1);
            string[] halves = numbersSection.Split('|');
            var winners = halves.ElementAt(0).Trim().Split(' ').Where(s => !string.IsNullOrEmpty(s));
            var ourNumbers = halves.ElementAt(1).Trim().Split(' ').Where(s => !string.IsNullOrEmpty(s));

            int overlappingNumbers = ourNumbers.Intersect(winners).Count();

            IEnumerable<int> cardsToAdd = Enumerable.Range(currentCard + 1, overlappingNumbers).Where(n => n < lines.Count);
            foreach (int card in cardsToAdd)
            {
                cardsQueue.Enqueue(card);
                totalCards++;
            }
        }

        return totalCards.ToString();
    }
}
