using System;
using NUnit.Framework;
using SpacerLibary;

namespace Spacer.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        private Parametrs _parameters;

        [SetUp]
        public void Test()
        {
            _parameters = new Parametrs(20, 50, 150, 4, 100);
        }

        [Test(Description = "Позитивный тест конструктора класса ")]
        public void TestParametrs_CorrectValue()
        {
            var expectedParameters = new Parametrs(20, 50, 150, 4, 100);
            var actual = _parameters;

            Assert.AreEqual
                (expectedParameters.CountHoles, actual.CountHoles,
                "Некорректное значение CountHoles");
            Assert.AreEqual
                (expectedParameters.Distance, actual.Distance,
                "Некорректное значение Distance");
            Assert.AreEqual
                (expectedParameters.InnerDiametr, actual.InnerDiametr,
                "Некорректное значение InnerDiametr");
            Assert.AreEqual
                (expectedParameters.OuterDiametr, actual.OuterDiametr,
                "Некорректное значение OuterDiametr");
            Assert.AreEqual
                (expectedParameters.Width, actual.Width,
                "Некорректное значение Width");
        }


        [TestCase(float.NegativeInfinity, 50, 150, 4, 100, "Width",
            TestName = "Негативный тест на infinity поля Width")]
        [TestCase(20, float.NegativeInfinity, 150, 4, 100, "InnerDiametr",
            TestName = "Негативный тест на infinity поля InnerDiametr")]
        [TestCase(20, 50, float.NegativeInfinity, 4, 100, "OuterDiametr",
            TestName = "Негативный тест на infinity поля OuterDiametr")]
        [TestCase(20, 50, 150, 4, float.NegativeInfinity, "Distance",
            TestName = "Негативный тест на infinity поля Distance")]
        [TestCase(float.NaN, 50, 150, 4, 100, "Width",
            TestName = "Негативный тест на NaN поля Width")]
        [TestCase(20, float.NaN, 150, 4, 100, "InnerDiametr",
            TestName = "Негативный тест на NaN поля InnerDiametr")]
        [TestCase(20, 50, float.NaN, 4, 100, "OuterDiametr",
            TestName = "Негативный тест на NaN поля OuterDiametr")]
        [TestCase(20, 50, 150, 4, float.NaN, "Distance",
            TestName = "Негативный тест на NaN поля Distance")]
        [TestCase(20000, 50, 140, 4, 100, "Width",
            TestName = "Негативный тест поля Width если > 100")]
        [TestCase(20, 10000, 140, 4, 100, "InnerDiametr",
            TestName = "Негативный тест поля InnerDiametr если > OuterDiametr")]
        [TestCase(20, 80, 140, 4, 100, "InnerDiametr",
            TestName = "Негативный тест поля InnerDiametr если OuterDiametr - InnerDiametr < 80")]
        [TestCase(20, -50, 140, 4, 100, "InnerDiametr",
            TestName = "Негативный тест поля InnerDiametr если < 0")]
        [TestCase(20, 50, 140, 8, 100, "CountHoles",
            TestName = "Негативный тест поля CountHoles если > 6")]
        [TestCase(20, 50, 140, 2, 100, "CountHoles",
            TestName = "Негативный тест поля CountHoles если < 4")]
        [TestCase(20, 50, 140, 5, 140, "Distance",
            TestName = "Негативный тест поля Distance если > OuterDiametr-30")]
        [TestCase(20, 50, 140, 5, 30, "Distance",
            TestName = "Негативный тест поля Distance если < InnerDiametr+30")]
        [TestCase(5, 50, 140, 4, 100, "Width",
            TestName = "Негативный тест поля Width если < 10")]

        public void TestParametrs_ArgumentValue
        (float width, float innerDiametr, float outerDiametr,
            int countHoles, float distance, string attr)
        {
            Assert.Throws<ArgumentException>(
                () => {
                    var parameters = new Parametrs
                        (width, innerDiametr, outerDiametr, countHoles, distance);
                },
                "Должно возникнуть исключение если значение поля "
                + attr + "выходит за диапозон доп-х значений");
        }
    }
}
