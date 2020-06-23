using System;
/*
	This class represents weapons used by a character with specific affixes 
*/

public class Weapon
{
	public string name;
	public string weaponDice;
	public string damageType;
	public string[] magicDamage = { };
	public string[] magicType = { };

	Dice diceTower = new Dice();

	/*
		Contructor for non-magic weapons 
	*/
	public Weapon(string _name, string _weaponDice, string _damageType)
	{
		name = _name;
		weaponDice = _weaponDice.ToLower(); 
		damageType = _damageType.ToLower();
	}

	/*
		Contructor for magic weapons 
	*/

	public Weapon(string _name, string _weaponDice, string _damageType, string[] _magicDamge, string[] _magicType)
	{
		name = _name;
		weaponDice = _weaponDice.ToLower();
		damageType = _damageType.ToLower();
		magicDamage = _magicDamge;
		magicType = _magicType;

		// Verify types are in lowercase to prevent errors

		for (int i = 0; i < magicType.Length; i++) 
		{
			magicType[i] = magicType[i].ToLower();
		}
		
		/*
			If a weapon is magic and it likely only has one additional magic type. like 1d6 fire. 
			HOWEVER, if the DM makes an item with multiple types this prgram will support it as long as the damage matches the types 
			ie: {"1d6", "1d6"}{"cold", "acid"} 

			Error thrown if the arrays are mismatched
		 */
		if (magicDamage.Length != magicType.Length) 
		{
			throw new Exception("Magic Damage and Magic Type mismatched"); 
		}
	}
	/*
	 
		TODO: calculate damage when it hits, values seperated by damage type
		 
	*/
	public int[] calcDamage()
	{
		// Types of Damage:  0 acid, 1 bludgeoning, 2 cold, 3 fire, 4 force, 5 lightning, 6 necrotic, 7 piercing, 8 poison, 9 psychic, 10 radiant, 11 slashing, and 12 thunder.
		int[] overallDmg = {0, 0, 0, 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0};
		// weapon damage
		switch(damageType)
		{
			case "acid":
				overallDmg[0] += diceTower.roll(weaponDice);
				break;
			case "bludgeoning":
				overallDmg[1] += diceTower.roll(weaponDice);
				break;
			case "cold":
				overallDmg[2] += diceTower.roll(weaponDice);
				break;
			case "fire":
				overallDmg[3] += diceTower.roll(weaponDice);
				break;
			case "force":
				overallDmg[4] += diceTower.roll(weaponDice);
				break;
			case "lightning":
				overallDmg[5] += diceTower.roll(weaponDice);
				break;
			case "necrotic":
				overallDmg[6] += diceTower.roll(weaponDice);
				break;
			case "piercing":
				overallDmg[7] += diceTower.roll(weaponDice);
				break;
			case "poison":
				overallDmg[8] += diceTower.roll(weaponDice);
				break;
			case "psychic":
				overallDmg[9] += diceTower.roll(weaponDice);
				break;
			case "radiant":
				overallDmg[10] += diceTower.roll(weaponDice);
				break;
			case "slashing":
				overallDmg[11] += diceTower.roll(weaponDice);
				break;
			case "thunder":
				overallDmg[12] += diceTower.roll(weaponDice);
				break;

			default:
				break;
		}
		if (magicType.Length != 0) {
			for (int i = 0; i < magicDamage.Length; i++)
			{
				switch (magicType[i])
				{
					case "acid":
						overallDmg[0] += diceTower.roll(magicDamage[i]);
						break;
					case "bludgeoning":
						overallDmg[1] += diceTower.roll(magicDamage[i]);
						break;
					case "cold":
						overallDmg[2] += diceTower.roll(magicDamage[i]);
						break;
					case "fire":
						overallDmg[3] += diceTower.roll(magicDamage[i]);
						break;
					case "force":
						overallDmg[4] += diceTower.roll(magicDamage[i]);
						break;
					case "lightning":
						overallDmg[5] += diceTower.roll(magicDamage[i]);
						break;
					case "necrotic":
						overallDmg[6] += diceTower.roll(magicDamage[i]);
						break;
					case "piercing":
						overallDmg[7] += diceTower.roll(magicDamage[i]);
						break;
					case "poison":
						overallDmg[8] += diceTower.roll(magicDamage[i]);
						break;
					case "psychic":
						overallDmg[9] += diceTower.roll(magicDamage[i]);
						break;
					case "radiant":
						overallDmg[10] += diceTower.roll(magicDamage[i]);
						break;
					case "slashing":
						overallDmg[11] += diceTower.roll(magicDamage[i]);
						break;
					case "thunder":
						overallDmg[12] += diceTower.roll(magicDamage[i]);
						break;

					default:
						break;
				}
			}
		}

		return overallDmg;
	}
}
