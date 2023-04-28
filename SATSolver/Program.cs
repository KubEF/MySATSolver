using System.Diagnostics;

namespace SATSolver
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var st = new Stopwatch();
            st.Start();
            var res = SATSolver.Solve(args[0]);
            st.Stop();
            Console.WriteLine("Время выполнения в миллисекундах: ", st.ElapsedMilliseconds);
            if (res.SatOrNot)
            {
                Console.WriteLine(String.Join(" ", res.Solution));
            }
            else
            {
                Console.Write("UNSAT");
            }
        }
    }
}
