using System;
/*
	This class represents weapons used by a character with specific affixes 
*/

public class Weapon
{
	string name;
	string weaponType;
	string damageType;
	string magicDamage;
	string magicType;

	

	public Weapon(string _name, string _weaponType, string _damageType, string _magicDamge, string _magicType)
	{
		name = _name;
		weaponType = _weaponType;
		damageType = _damageType;
		magicDamage = _magicDamge;
		magicType = _magicType;
	}
	/*
	 
		TODO: calculate damage when it hits
		 
	*/
	public int calcDamage()
	{
		return 0;
	}
}
