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
    }
}
