using System.Diagnostics;

namespace Day02
{
    public class RPSResolver
    {
        private const int LossValue = 0;
        private const int TieValue = 3;
        private const int WinValue = 6;

        private const char RockOpponent = 'A';
        private const char PaperOpponent = 'B';
        private const char ScissorsOpponent = 'C';

        private const char RockPlayer = 'X';
        private const char PaperPlayer = 'Y';
        private const char ScissorsPlayer = 'Z';

        private const char LossOutcome = 'X';
        private const char TieOutcome = 'Y';
        private const char WinOutcome = 'Z';

        private static readonly Dictionary<char, int> shapeValues = new()
        {
            { RockPlayer, 1 },
            { PaperPlayer, 2 },
            { ScissorsPlayer, 3 },
        };

        public static int ResolveRound(char opponentMove, char playerMove)
        {
            if (MovesAreEquivalent(playerMove, opponentMove)) return GetPointValue(TieValue, playerMove);

            switch (playerMove)
            {
                case RockPlayer:
                    if (opponentMove == ScissorsOpponent) return GetPointValue(WinValue, playerMove);
                    break;
                case PaperPlayer:
                    if (opponentMove == RockOpponent) return GetPointValue(WinValue, playerMove);
                    break;
                case ScissorsPlayer:
                    if (opponentMove == PaperOpponent) return GetPointValue(WinValue, playerMove);
                    break;
            }

            return GetPointValue(LossValue, playerMove);
        }

        public static int ResolveWithCheating(char opponentMove, char neededOutcome)
        {
            char playerMove;
            if (neededOutcome == TieOutcome)
            {
                playerMove = GetPlayerEquivalent(opponentMove);
            }
            else if (neededOutcome == LossOutcome)
            {
                switch (opponentMove)
                {
                    case RockOpponent:
                        playerMove = ScissorsPlayer;
                        break;
                    case PaperOpponent:
                        playerMove = RockPlayer;
                        break;
                    case ScissorsOpponent:
                        playerMove = PaperPlayer;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            else if (neededOutcome == WinOutcome)
            {
                switch (opponentMove)
                {
                    case RockOpponent:
                        playerMove = PaperPlayer;
                        break;
                    case PaperOpponent:
                        playerMove = ScissorsPlayer;
                        break;
                    case ScissorsOpponent:
                        playerMove = RockPlayer;
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            else throw new ArgumentException();

            return ResolveRound(opponentMove, playerMove);
        }

        private static bool MovesAreEquivalent(char moveA, char moveB)
        {
            return GetPlayerEquivalent(moveB) == moveA;
        }

        private static char GetPlayerEquivalent(char moveA)
        {
            if (moveA == RockOpponent) return RockPlayer;
            if (moveA == PaperOpponent) return PaperPlayer;
            if (moveA == ScissorsOpponent) return ScissorsPlayer;
            throw new ArgumentException();
        }

        private static int GetPointValue(int pointsFromOutcome, char shape)
        {
            return pointsFromOutcome + shapeValues[shape];
        }
    }
}
