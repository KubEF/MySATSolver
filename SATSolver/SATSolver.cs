// <copyright file="SATSolver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SATSolver
{
    public static class SATSolver
    {
        public static string Solve(string pathToDimacsFile)
        {
            using (var stream = new StreamReader(pathToDimacsFile))
            {
                var dimacsFile = stream.ReadToEnd();
                var formula = ParseDimacs(dimacsFile);
                var isSat = DPLL(formula);
                if (isSat) return "SAT";
                return "UNSAT";
            }
        }

        private static bool DPLL(FormulaInfo formula)
        {
            if (GoodChek(formula)) return true;

            if (BadChek(formula)) return false;

            // unit propagate
            var literal = formula.ListOfclauses.Find(value => value.Count == 1);
            while (literal != null)
            {
                formula = UnitPropagate(literal[0], formula);
                if (GoodChek(formula)) return true;
                if (BadChek(formula)) return false;
                literal = formula.ListOfclauses.Find(value => value.Count == 1);
            }

            // pure literal assign
            var variablesSet = new HashSet<int>();
            foreach (var clause in formula.ListOfclauses)
            {
                variablesSet.UnionWith(clause);
            }

            foreach (var tempLiteral in variablesSet)
            {
                if (variablesSet.Contains(tempLiteral) && variablesSet.Contains(-tempLiteral))
                {
                    variablesSet.Remove(tempLiteral);
                    variablesSet.Remove(-tempLiteral);
                }
            }

            foreach (var tempLiteral in variablesSet)
            {
                formula = PureLiteralAssign(tempLiteral, formula);
                if (GoodChek(formula)) return true;

                if (BadChek(formula)) return false;
            }

            // chose a literal and split
            var chosenLiteral = formula.ListOfclauses[0][0];
            var formulaLeft = formula.Copy();
            formulaLeft.ListOfclauses.Add(new List<int> { chosenLiteral });
            var formulaRight = formula.Copy();
            formulaRight.ListOfclauses.Add(new List<int> { -chosenLiteral });
            return DPLL(formulaLeft) || DPLL(formulaRight);
        }

        private static FormulaInfo ParseDimacs(string dimacsFile)
        {
            string comments = string.Empty;
            int numberOfVariables = 0;
            int numberOfClauses = 0;
            List<List<int>> listOfClauses = new List<List<int>>();
            var dimacsArray = dimacsFile.Split('\n');
            foreach (var line in dimacsArray)
            {
                if (line[0] == 'c') comments += line;
                else if (line[0] == 'p')
                {
                    var infoAboutClauses = line.Split(' ').Where(x => x != string.Empty && x != " ").Select(x => x).ToArray();
                    numberOfVariables = int.Parse(infoAboutClauses[2]);
                    numberOfClauses = int.Parse(infoAboutClauses[3]);
                }
                else
                {
                    List<int> clause = line.Split(' ').Where(v => v != string.Empty && v != "0").Select(int.Parse).ToList();
                    listOfClauses.Add(clause);
                }
            }

            return new FormulaInfo(numberOfVariables, numberOfClauses, listOfClauses);
        }

        private static FormulaInfo UnitPropagate(int literal, FormulaInfo formula)
        {
            var resultFormula = formula.Copy();
            if (Math.Abs(literal) > formula.NumberOfVariables) throw new Exception("Такого литерала не существует");

            foreach (var clause in formula.ListOfclauses)
            {
                if (clause.Contains(literal))
                {
                    resultFormula.ListOfclauses.Remove(clause);
                }
                else if (clause.Contains(-literal))
                {
                    resultFormula.ListOfclauses.Find(c => c.Equals(clause)).Remove(-literal);
                }
            }

            return resultFormula;
        }

        private static FormulaInfo PureLiteralAssign(int literal, FormulaInfo formula)
        {
            var resultFormula = formula.Copy();
            foreach (var clause in formula.ListOfclauses)
            {
                if (clause.Contains(literal)) resultFormula.ListOfclauses.Remove(clause);
            }

            return resultFormula;
        }

        private static bool GoodChek(FormulaInfo formula)
        {
            return formula.ListOfclauses.Count == 0;
        }

        private static bool BadChek(FormulaInfo formula)
        {
            return formula.ListOfclauses.Any(value => value.Count == 0);
        }
    }
}