namespace BetterDomino
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Domino.Chain(new[]
            {
                (2, 2), (1, 3), (3, 2), (3, 1), (2, 1), (1, 3),
            }));
        }
    }
    public class Domino
    {
        public static bool Chain(IEnumerable<(int, int)> dominoes) => TryChain(dominoes.ToList(), (0, 0));

        public static bool TryChain(List<(int, int)> dominoes, (int first, int last) ends)
        {
            if (dominoes.Count == 0 && ends.last == ends.first) return true;

            var copyEnd = ends;

            for (int i = 0; i < dominoes.Count; i++)
            {
                var (a, b) = dominoes[i];

                if (ends.last == 0)
                {
                    ends = (a, b);
                }
                else if (ends.last == a)
                {
                    ends.last = b;
                }
                else if (ends.last == b)
                {
                    ends.last = a;
                }
                else
                {
                    continue;
                }

                var dominoesCopy = new List<(int, int)>(dominoes);

                dominoesCopy.RemoveAt(i);

                if (TryChain(dominoesCopy, ends)) return true;
                {
                    ends = copyEnd;
                }
            }
            return false;
        }
    }
}