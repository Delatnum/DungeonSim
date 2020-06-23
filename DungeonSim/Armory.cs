using System;
/*
 * This class carries weapon types as enumerated values.
 */
public class Armory
{
    Random rnd = new Random();
    /*
        The following methods return the damage value of a weapon corresponding with the name of the method. 
    */

    // Daggers do 1d4 damage 
    public int dagger(){return rnd.Next(1, 5);}

    // Javelins do 1d6 damage (Note: they are thrown at a range of 20/60, shots above 20 feet are at disadvantage (roll d20 twice and take the lower roll for your attempt to hit))  
    public int javelin(){return rnd.Next(1, 7);}

    // making a hit using a quarterstaff with one hand does 1d6 damage  
    public int quarterstaff1h(){return rnd.Next(1, 7);}

    // making a hit using a quarterstaff with both hands does 1d8 damage
    public int quarterstaff2h(){return rnd.Next(1, 9);}

    // making a hit using a battleaxe with one hand does 1d8 damage
    public int battleaxe1h() { return rnd.Next(1, 9); }

    // making a hit using a battleaxe with both hands does 1d10 damage
    public int battleaxe2h() { return rnd.Next(1, 11); }

    // making a hit using a glaive does 1d10 damage
    public int glaive() { return rnd.Next(1, 11); }

    // making a hit using a halberd with both hands does 1d10 damage
    public int halberd() { return rnd.Next(1, 11); }

    // making a hit using a lance with both hands does 1d12 damage
    public int lance() { return rnd.Next(1, 13); }

    // making a hit using a morningstar does 1d8 damage
    public int morningstar() { return rnd.Next(1, 9); }

    // making a hit using a maul does 2d6 damage
    public int maul() { return (rnd.Next(1, 7) + rnd.Next(1, 7)); }

}
