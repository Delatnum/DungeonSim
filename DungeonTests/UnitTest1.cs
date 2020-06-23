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
        Dice d1 = new Dice();
        /*
        
                DICE TESTING
             
        */
        [TestMethod]
        public void checkDice()
        {
            for (int i = 0; i < 50; i++)
            {
                int res = d1.roll("1d6");

                Assert.IsTrue(res == 1 || res == 2 || res == 3 || res == 4 || res == 5 || res == 6, "Dice value incorrect");
            }

            for (int i = 0; i < 50; i++)
            {
                int res = d1.roll("1d8");

                Assert.IsTrue(res == 1 || res == 2 || res == 3 || res == 4 || res == 5 || res == 6 || res == 7 || res == 8, "Dice value incorrect");
            }
        }

        [TestMethod]
        public void checkWeapon()
        {
            // Types of Damage:  0 acid, 1 bludgeoning, 2 cold, 3 fire, 4 force, 5 lightning, 6 necrotic, 7 piercing, 8 poison, 9 psychic, 10 radiant, 11 slashing, and 12 thunder.

            /*
                Test with valid types
             */
            string[] mgcDamage = { "1d4", "1d4" };
            string[] mgcType = { "cold", "necrotic" };

            Weapon swordOf1000Truths = new Weapon("The Sword of a thousand Truths", "1d8", "slashing", mgcDamage, mgcType);

            for (int i = 0; i < 10; i++)
            {
                int[] results = swordOf1000Truths.calcDamage();
                // Check Slashing
                Assert.IsTrue(results[11] == 1 || results[11] == 2 || results[11] == 3 || results[11] == 4 || results[11] == 5 || results[11] == 6 || results[11] == 7 || results[11] == 8, "Weapon Calculation values incorrect");
                // Check Cold
                Assert.IsTrue(results[2] == 1 || results[2] == 2 || results[2] == 3 || results[2] == 4, "Weapon Magic Damage Calculation values incorrect");
                // Check Necrotic
                Assert.IsTrue(results[6] == 1 || results[6] == 2 || results[6] == 3 || results[6] == 4, "Weapon Magic Damage Calculation values incorrect");
            }

            /*
                Test with invalid types
             */

            string[] mgcFailDamage = { "1d4", "1d4" };
            string[] mgcFailType = { "ice", "death" };

            Weapon swordOf1000Lies = new Weapon("The Sword of a thousand Lies", "1d8", "Cutting", mgcFailDamage, mgcFailType);

            for (int i = 0; i < 10; i++)
            {
                int[] results = swordOf1000Lies.calcDamage();
                // Check Slashing

                int totRes = results[0] + results[1] + results[2] + results[3] + results[4] + results[5] + results[6] + results[7] + results[8] + results[9] + results[10] + results[11] + results[12];
                Assert.IsTrue(totRes == 0, "Weapon Calculation values incorrect");
            }

            /*
                Test with non magic weapon
             */

            Weapon aSword = new Weapon("longsword", "1d8", "slashing");

            for (int i = 0; i < 10; i++)
            {
                int[] results = aSword.calcDamage();
                // Check Slashing
                Assert.IsTrue(results[11] == 1 || results[11] == 2 || results[11] == 3 || results[11] == 4 || results[11] == 5 || results[11] == 6 || results[11] == 7 || results[11] == 8, "Weapon Calculation values incorrect");
            }
        }

        [TestMethod]
        public void checkIfRanged()
        {
            Weapon aBow = new Weapon("longbow", "1d8", "slashing");
            aBow.setRanged(20, 60);

            for (int i = 0; i < 10; i++)
            {
                int[] results = aBow.calcDamage();
                // Check Slashing
                Assert.IsTrue(results[11] == 1 || results[11] == 2 || results[11] == 3 || results[11] == 4 || results[11] == 5 || results[11] == 6 || results[11] == 7 || results[11] == 8, "Weapon Calculation values incorrect");
            }

            Assert.IsTrue(aBow.isRanged());

            aBow.setMelee();

            Assert.IsFalse(aBow.isRanged());
        }
    }
}
