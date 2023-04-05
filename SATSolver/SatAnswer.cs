namespace SATSolver
{
    public class SatAnswer
    {
        public List<int> Solution;
        public bool SatOrNot;

        public SatAnswer(bool sat, List<int> solution)
        {
            this.Solution = solution;
            this.SatOrNot = sat;
        }
    }
}
