// <copyright file="FormulaInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SATSolver
{
    public class FormulaInfo
    {
        private int numberOfVariables;
        private int numberOfClauses;
        private List<List<int>> listOfClauses;

        public FormulaInfo(int numberOfVariables, int numberOfClauses, List<List<int>> listOfclauses)
        {
            this.numberOfVariables = numberOfVariables;
            this.numberOfClauses = numberOfClauses;
            this.listOfClauses = listOfclauses;
        }

        public List<List<int>> ListOfclauses { get => this.listOfClauses; set => this.SetList(value); }

        public int NumberOfClauses { get => this.numberOfClauses; set => this.numberOfClauses = value; }

        public int NumberOfVariables { get => this.numberOfVariables; set => this.numberOfVariables = value; }

        public FormulaInfo Copy()
        {
            return new FormulaInfo(this.numberOfVariables, this.numberOfClauses, this.listOfClauses.ToList());
        }

        private void SetList(List<List<int>> value)
        {
            this.listOfClauses = value;
            this.numberOfClauses = value.Count;
        }
    }
}
