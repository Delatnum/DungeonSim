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
    public int dagger() 
    {

        return rnd.Next(1, 7);
    
    }
}
