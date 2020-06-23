using Microsoft.VisualStudio.TestTools.UnitTesting;
using DungeonSim;
using System;
/*
    Testing for DungeonSim
     */
namespace DungeonTests
{
    
    [TestClass]
    public class UnitTests
    {
        Armory testArmory = new Armory();

        /*
            Testing outputs for weapons
             */
        [TestMethod]
        public void CheckDaggerDmgGeneration()
        {
            // Get Dagger Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.dagger();
                Assert.IsTrue(output < 5,"Dagger dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Dagger dealing less than the damage threshold");
            }
        }

        [TestMethod]
        public void CheckJavelinDmgGeneration()
        {
            // Get Dagger Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.javelin();
                Assert.IsTrue(output < 7, "Javelin dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Javelin dealing less than the damage threshold");
            }
        }

        [TestMethod]
        public void CheckQuarterStaff1hDmgGeneration()
        {
            // Get Dagger Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.quarterstaff1h();
                Assert.IsTrue(output < 7, "Quarterstaff 1h dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Quarterstaff 1h  dealing less than the damage threshold");
            }
        }

        [TestMethod]
        public void CheckQuarterStaff2hDmgGeneration()
        {
            // Get Dagger Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.quarterstaff2h();
                Assert.IsTrue(output < 9, "Quarterstaff 2h  dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Quarterstaff 2h  dealing less than the damage threshold");
            }
        }
    }
}
