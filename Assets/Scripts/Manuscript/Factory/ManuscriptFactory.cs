
using System;

public class ManuscriptFactory
{
	public AbstractManuscript fromJSON(string path)
	{
		throw new Exception("Not implemented yet");
	}

	public AbstractManuscript fromSerializable(ManuscriptSerializable serializable)
	{
		switch(serializable.type)
		{
			case "chassis" : return chassisFromSerializable(serializable);
			case "flying" : return flyingFromSerializable(serializable);
			case "propulsion" : return propulsionFromSerializable(serializable);
			case "weapon" : return weaponFromSerializable(serializable);
		}
		throw new Exception("Unknow manuscript type [" + serializable.type + "]");
	}
	public ChassisManuscript chassisFromSerializable(ManuscriptSerializable serializable)
	{
		return new ChassisManuscript();
	}
	public FlyingManuscript flyingFromSerializable(ManuscriptSerializable serializable)
	{
		return new FlyingManuscript();
	}
	public PropulsionManuscript propulsionFromSerializable(ManuscriptSerializable serializable)
	{
		return new PropulsionManuscript();
	}
	public WeaponManuscript weaponFromSerializable(ManuscriptSerializable serializable)
	{
		return new WeaponManuscript();
	}
}