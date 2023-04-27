namespace SATSolver
{
    using System.Diagnostics;
    using System.Runtime.ConstrainedExecution;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var timer = new Stopwatch();
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.Combine("../../../../SatTests", "TestFiles");
            string fullPath = Path.GetFullPath(Path.Combine(projectDirectory, relativePath));
            var arrayOfFiles = new string[]
            {
                    Path.Combine(fullPath, "aim-50-1_6-no-3.cnf"),
                    Path.Combine(fullPath, "aim-50-1_6-no-2.cnf"),
                    Path.Combine(fullPath, "aim-50-1_6-no-4.cnf"),
                    Path.Combine(fullPath, "uf75-01.cnf"),
                    Path.Combine(fullPath, "uf75-010.cnf"),
                    Path.Combine(fullPath, "uf75-02.cnf"),
                    Path.Combine(fullPath, "uf75-03.cnf"),
                    Path.Combine(fullPath, "uf75-04.cnf"),
            };
            for (int i = 0; i < 100; i++)
            {
                timer.Restart();
                foreach (var file in arrayOfFiles)
                {
                    SATSolver.Solve(file);
                }

                timer.Stop();
                if (i > 59) Console.WriteLine(timer.ElapsedMilliseconds);
            }

            Console.ReadLine();

        }
    }
}