namespace SatTests
{
    using SATSolver;

    public class SatTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SatTest1()
        {
            var path = @"TestFiles/uf75-01.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(true));
        }

        [Test]
        public void SatTest2()
        {
            var path = @"TestFiles/uf75-02.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(true));
        }

        [Test]
        public void SatTest3()
        {
            var path = @"TestFiles/uf75-03.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(true));
        }

        [Test]
        public void SatTest4()
        {
            var path = @"TestFiles/uf75-04.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(true));
        }

        [Test]
        public void SatTest5()
        {
            var path = @"TestFiles/uf75-05.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(true));
        }

        [Test]
        public void SatTest6()
        {
            var path = @"TestFiles/uf75-06.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(true));
        }

        [Test]
        public void SatTest7()
        {
            var path = @"TestFiles/uf75-07.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(true));
        }

        [Test]
        public void SatTest8()
        {
            var path = @"TestFiles/uf75-08.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(true));
        }

        [Test]
        public void SatTest9()
        {
            var path = @"TestFiles/uf75-09.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(true));
        }

        [Test]
        public void SatTest10()
        {
            var path = @"TestFiles/uf75-010.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(true));
        }

        [Test]
        public void UnsatTest1()
        {
            var path = @"TestFiles/aim-50-1_6-no-1.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(false));
        }

        [Test]
        public void UnsatTest2()
        {
            var path = @"TestFiles/aim-50-1_6-no-2.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(false));
        }

        [Test]
        public void UnsatTest3()
        {
            var path = @"TestFiles/aim-50-1_6-no-3.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(false));
        }

        [Test]
        public void UnsatTest4()
        {
            var path = @"TestFiles/aim-50-1_6-no-4.cnf";
            var actual = SATSolver.Solve(path);

            Assert.That(actual.SatOrNot, Is.EqualTo(false));
        }

    }
}