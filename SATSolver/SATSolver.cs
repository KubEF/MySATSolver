// <copyright file="SATSolver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SATSolver
{
    public static class SATSolver
    {
        public static SatAnswer Solve(string pathToDimacsFile)
        {
            using (var stream = new StreamReader(pathToDimacsFile))
            {
                var dimacsFile = stream.ReadToEnd();
                var formula = ParseDimacs(dimacsFile);
                var satAnswer = DPLL(formula, null);
                return satAnswer;
            }
        }

        private static SatAnswer DPLL(List<List<int>> clauses, List<int>? solution)
        {
            solution ??= new List<int>();

            // Check
            if (clauses.Any(clause => clause.Count == 0)) return new SatAnswer(false, new List<int>());

            if (clauses.Count == 0) return new SatAnswer(true, solution);

            // Unit propagation
            List<int> unitLiterals = clauses.Where(clause => clause.Count == 1).Select(c => c[0]).ToList();
            unitLiterals.ForEach(literal =>
            {
                clauses.RemoveAll(clause => clause.Contains(literal));
                clauses.ForEach(clause => clause.Remove(-literal));
            });

            solution.AddRange(unitLiterals);

            // Check
            if (clauses.Any(clause => clause.Count == 0)) return new SatAnswer(false, new List<int>());

            if (clauses.Count == 0) return new SatAnswer(true, solution);

            // Pure literal assign
            var pureLiterals = clauses.SelectMany(c => c).Distinct().GroupBy(l => Math.Abs(l)).Where(g => g.Count() == 1).SelectMany(g => g).ToList();
            pureLiterals.ForEach(literal => clauses.RemoveAll(clause => clause.Contains(literal)));
            solution.AddRange(pureLiterals);

            // Check
            if (clauses.Any(clause => clause.Count == 0)) return new SatAnswer(false, new List<int>());

            if (clauses.Count == 0) return new SatAnswer(true, solution);

            // Choose iteral and split
            var chosenLiteral = clauses.FirstOrDefault().FirstOrDefault();
            var clausesAddLeft = new List<List<int>>();
            clauses.ForEach(clause => clausesAddLeft.Add(clause.ToList()));
            clausesAddLeft.Add(new List<int> { chosenLiteral });
            var solutionLeft = solution.ToList();
            if (DPLL(clausesAddLeft, solutionLeft).SatOrNot)
            {
                return new SatAnswer(true, solution);
            }

            var clausesAddRight = new List<List<int>>();
            clauses.ForEach(clause => clausesAddRight.Add(clause.ToList()));
            clausesAddRight.Add(new List<int> { -chosenLiteral });
            var solutionRight = solution.ToList();
            if (DPLL(clausesAddRight, solutionRight).SatOrNot)
            {
                return new SatAnswer(true, solution);
            }

            return new SatAnswer(false, new List<int>());
        }

        private static List<List<int>> ParseDimacs(string dimacsFile)
        {
            List<List<int>> clauses = new List<List<int>>();
            var dimacsArray = dimacsFile.Split('\n');
            clauses = new List<List<int>>();
            foreach (var line in dimacsArray)
            {
                if (line[0] != 'c' && line[0] != 'p') clauses.Add(line.Split(' ').Where(c => c != string.Empty && c != "0").Select(int.Parse).ToList());
            }

            return clauses;
        }
    }
}