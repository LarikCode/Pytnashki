using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace pytnashki.Tests
{
    [TestClass]
    public class PoleTest
    {
        private Pole Pole;
        [TestInitialize]
        public void TestInitialize()
        {
            Pole = Pole.getInstance();
            Pole.NewState(4);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Pole.NewState(4);
        }

        [TestMethod]
        public void Up_3to0_expected0()
        {
            Pole.Up();
            Pole.Up();
            Pole.Up();
            Assert.AreEqual(0, Pole.NullPositionX);
        }

        [TestMethod]
        public void Up_outside_false()
        {
            Pole.Up();
            Pole.Up();
            Pole.Up();
            Assert.IsFalse(Pole.Up());
        }

        [TestMethod]
        public void Down_expected_false()
        {
            Assert.IsFalse(Pole.Down());
        }

        [TestMethod]
        public void Left_expected_false()
        {
            Pole.Left();
            Pole.Left();
            Pole.Left();
            Assert.IsFalse(Pole.Left());
        }

        [TestMethod]
        public void NewState_newSize_expected9()
        {
            Pole.NewState(9);
            Assert.AreEqual(9, Pole.Size);
        }

        [TestMethod]
        public void NewState_CellTitle1x3_expected9()
        {
            Pole.NewState(5);
            Assert.AreEqual(9, Pole.cellWhisTitles[1, 3].Title);
        }
    }
}
