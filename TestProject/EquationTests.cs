using Xunit;
using TPZ_PR4;

namespace TestProject
{
    public class LinearEquationTests
    {
        [Fact]
        public void Test_LinearEquation_Calculate_Positive()
        {
            var linear = new LinearEquation(2.0, 3.0);
            double result = linear.Calculate(4.0);
            Assert.Equal(11.0, result, precision: 4);
        }

        [Theory]
        [InlineData(2.0, -4.0, 2.0)]
        [InlineData(5.0, 10.0, -2.0)]
        [InlineData(-3.0, 9.0, 3.0)]
        public void Test_LinearEquation_FindRoot_Valid(double k, double b, double expectedRoot)
        {
            var linear = new LinearEquation(k, b);
            bool success = linear.FindRoot(out double root, out string error);
            Assert.True(success);
            Assert.Empty(error);
            Assert.Equal(expectedRoot, root, precision: 4);
        }

        [Fact]
        public void Test_LinearEquation_FindRoot_Parallel()
        {
            var linear = new LinearEquation(0.0, 5.0);
            bool success = linear.FindRoot(out double root, out string error);
            Assert.False(success);
            Assert.True(double.IsNaN(root));
            Assert.Contains("не має розв'язків", error);
        }
    }

    public class QuadraticEquationTests
    {
        [Fact]
        public void Test_QuadraticEquation_Discriminant()
        {
            var quad = new QuadraticEquation(1.0, -4.0, 3.0);
            double d = quad.Discriminant();
            Assert.Equal(4.0, d, precision: 4);
        }

        [Theory]
        [InlineData(1.0, -5.0, 6.0, 3.0, 2.0, 2)]
        [InlineData(1.0, -2.0, 1.0, 1.0, 1.0, 1)]
        [InlineData(2.0, 1.0, 5.0, double.NaN, double.NaN, 0)]
        public void Test_QuadraticEquation_FindRoots_Scenarios(double a, double b, double c, double expR1, double expR2, int expCount)
        {
            var quad = new QuadraticEquation(a, b, c);
            int count = quad.FindRoots(out double r1, out double r2, out string error);
            Assert.Equal(expCount, count);
            if (expCount == 2)
            {
                Assert.Equal(expR1, r1, precision: 4);
                Assert.Equal(expR2, r2, precision: 4);
            }
            else if (expCount == 1)
            {
                Assert.Equal(expR1, r1, precision: 4);
            }
            else
            {
                Assert.NotEmpty(error);
            }
        }

        [Fact]
        public void Test_QuadraticEquation_DegenerateCase_AIsZero()
        {
            var quad = new QuadraticEquation(0.0, 3.0, 5.0);
            int count = quad.FindRoots(out _, out _, out string error);
            Assert.Equal(0, count);
            Assert.Contains("вироджується", error);
        }
    }
}
