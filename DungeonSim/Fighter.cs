using System;
/*
    
    Represents the Dungeons and Dragons 5th Edition fighter class
 
     */
public class Fighter
{
    bool action = true;
    bool bonusAction = true;
    bool reaction = true;

    int[] stats = { 0, 0, 0, 0, 0, 0 }; // Character Stats in index order, Strength, Dexterity, Constitution, Intelligence, Wisdom, and Charisma

    public Fighter(int STR, int DEX, int CON, int INT, int WIS, int CHA) 
    {
        /*
            Note: an average civilian has a value of 10, (an intelligence value of 8 implies stupidity 12 implies cleverness)
         */
        stats[0] = STR;
        stats[0] = DEX;
        stats[0] = CON;
        stats[0] = INT;
        stats[0] = WIS;
        stats[0] = CHA;
    }
}
