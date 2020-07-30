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
            Weapon aBow = new Weapon("longbow", "1d8", "piercing");
            aBow.setRanged(20, 60);

            for (int i = 0; i < 10; i++)
            {
                int[] results = aBow.calcDamage();
                // Check Slashing
                Assert.IsTrue(results[7] == 1 || results[7] == 2 || results[7] == 3 || results[7] == 4 || results[7] == 5 || results[7] == 6 || results[7] == 7 || results[7] == 8, "Weapon Calculation values incorrect");
            }

            Assert.IsTrue(aBow.isRanged());

            aBow.setMelee();

            Assert.IsFalse(aBow.isRanged());
        }

        [TestMethod]
        public void testFighterSaves()
        {
            Weapon aSword = new Weapon("longsword", "1d8", "slashing");
            Weapon aBow = new Weapon("longbow", "1d8", "piercing");
            aBow.setRanged(20, 60);

            Fighter Kenny = new Fighter(16,14,15,11,12,10, 30, aSword, aBow);

            double saves = 0;
            double fails = 0;
            // an impossible save (Only a crit would work 5% chance)
            for (int i = 0; i < 500; i++) 
            {
                if (Kenny.saves("DEX", 1000))
                {
                    saves++;
                }
                else 
                {
                    fails++;
                }
            }
            double saveRate = saves / (fails + saves);
             Assert.IsTrue(saveRate < 0.07);
            Assert.IsTrue(saveRate > 0.03); 

        }

        [TestMethod]
        public void testBasicMonster()
        {
            Weapon aSword = new Weapon("shortsword", "1d6", "slashing");
            Weapon aBow = new Weapon("shortbow", "1d6", "piercing");
            aBow.setRanged(20, 60);

            BasicMonster SkeletonOne = new BasicMonster(16, 14, 15, 11, 12, 10, 30, 13, aSword, aBow);


            Assert.IsFalse(SkeletonOne.immunities[6]);
            SkeletonOne.setImmunities("necrotic", true);
            Assert.IsTrue(SkeletonOne.immunities[6]);
            SkeletonOne.setImmunities("poison", false);
            Assert.IsFalse(SkeletonOne.resistances[6]);

            Assert.IsFalse(SkeletonOne.resistances[8]);
            SkeletonOne.setResistance("poison", true);
            Assert.IsTrue(SkeletonOne.resistances[8]);
            SkeletonOne.setResistance("poison", false);
            Assert.IsFalse(SkeletonOne.resistances[8]);

            Assert.IsFalse(SkeletonOne.vulnerabilites[1]);
            SkeletonOne.setVulnerabilites("bludgeoning", true);
            Assert.IsTrue(SkeletonOne.vulnerabilites[1]);
            SkeletonOne.setVulnerabilites("bludgeoning", false);
            Assert.IsFalse(SkeletonOne.vulnerabilites[1]);

        }

        [TestMethod]
        public void testGetMonsterFromLibrary()
        {
            MonsterLibrary monsters = new MonsterLibrary();

            Combatant c = monsters.getMonster("Skeleton");

            Assert.AreEqual(c.stats[0], 10);
            Assert.AreEqual(c.stats[1], 14);
            Assert.AreEqual(c.stats[2], 15);
            Assert.AreEqual(c.stats[3], 6);
            Assert.AreEqual(c.stats[4], 8);
            Assert.AreEqual(c.stats[5], 5);

            Assert.AreEqual(c.primaryWeapon.name, "shortsword");
            Assert.AreEqual(c.secondaryWeapon.name, "shortbow");

            Assert.AreEqual(c.hpmax, 13);
            Assert.AreEqual(c.curHp, 13);
        }

        [TestMethod]
        public void RoundCalcerAddCombatants()
        {
            MonsterLibrary monsters = new MonsterLibrary();

            RoundCalcer instance = new RoundCalcer();

            // Add hostile
            instance.addCombatant(monsters.getMonster("Skeleton"), false);
            // Add Ally
            instance.addCombatant(monsters.getMonster("Skeleton"), true);

            instance.damageCalculator(0, true);

            Assert.AreEqual(instance.Combatants.Count, 2);
            Assert.AreEqual(instance.listAllies.Count, 1);
            Assert.AreEqual(instance.listEnemies.Count, 1);
        }

        [TestMethod]
        public void RoundCalcerTestDefeat()
        {
            MonsterLibrary monsters = new MonsterLibrary();

            RoundCalcer instance = new RoundCalcer();

            // Add hostile
            instance.addCombatant(monsters.getMonster("Skeleton"), false);
            instance.addCombatant(monsters.getMonster("Skeleton"), false);
            instance.addCombatant(monsters.getMonster("Skeleton"), false);
            // Add Ally
            instance.addCombatant(monsters.getMonster("Skeleton"), true);

            int returnVal = instance.damageCalculator(0, true);

            while (returnVal == 0) 
            {
                returnVal = instance.damageCalculator(0, false);
            }

            
            Assert.IsTrue(returnVal < 0);
        }

        [TestMethod]
        public void RoundCalcerTestVictory()
        {
            MonsterLibrary monsters = new MonsterLibrary();

            RoundCalcer instance = new RoundCalcer();

            // Add hostile
            instance.addCombatant(monsters.getMonster("Skeleton"), true);
            instance.addCombatant(monsters.getMonster("Skeleton"), true);
            instance.addCombatant(monsters.getMonster("Skeleton"), true);
            // Add Ally
            instance.addCombatant(monsters.getMonster("Skeleton"), false);

            int returnVal = instance.damageCalculator(0, true);

            while (returnVal == 0)
            {
                returnVal = instance.damageCalculator(0, false);
            }


            Assert.IsTrue(returnVal > 0);
        }

    }
}
