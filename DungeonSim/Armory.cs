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
}
