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
            // Get Javelin Values
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
            // Get Quarterstaff 1h Values
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
            // Get Quarterstaff 2h Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.quarterstaff2h();
                Assert.IsTrue(output < 9, "Quarterstaff 2h  dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Quarterstaff 2h  dealing less than the damage threshold");
            }
        }

        [TestMethod]
        public void CheckBattleAxe1hDmgGeneration()
        {
            // Get Battle Axe 1h Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.battleaxe1h();
                Assert.IsTrue(output < 9, "Battle Axe 1h  dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Battle Axe 1h  dealing less than the damage threshold");
            }
        }

        [TestMethod]
        public void CheckBattleAxe2hDmgGeneration()
        {
            // Get Battle Axe 2h Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.battleaxe2h();
                Assert.IsTrue(output < 11, "Battle Axe 2h  dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Battle Axe 2h  dealing less than the damage threshold");
            }
        }

        [TestMethod]
        public void CheckGlaiveDmgGeneration()
        {
            // Get Glaive Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.glaive();
                Assert.IsTrue(output < 11, "Glaive dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Glaive dealing less than the damage threshold");
            }
        }

        [TestMethod]
        public void halberd()
        {
            // Get Halberd Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.halberd();
                Assert.IsTrue(output < 11, "Halberd dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Halberd dealing less than the damage threshold");
            }
        }

        [TestMethod]
        public void lance()
        {
            // Get Halberd Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.lance();
                Assert.IsTrue(output < 13, "Halberd dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Halberd dealing less than the damage threshold");
            }
        }

        [TestMethod]
        public void morningstar()
        {
            // Get Halberd Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.morningstar();
                Assert.IsTrue(output < 9, "Morning Star dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Morning Star dealing less than the damage threshold");
            }
        }

        [TestMethod]
        public void maul()
        {
            // Get Halberd Values
            for (int i = 0; i < 50; i++)
            {
                int output = testArmory.maul();
                Assert.IsTrue(output < 13, "Maul dealing greater than the damage threshold");
                Assert.IsTrue(output > 0, "Maul dealing less than the damage threshold");
            }
        }
    }
}
