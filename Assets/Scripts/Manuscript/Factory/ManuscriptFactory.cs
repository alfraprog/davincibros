
using System;

public class ManuscriptFactory
{
	public AbstractManuscript FromJSON(string path)
	{
		throw new Exception("Not implemented yet");
	}

	public AbstractManuscript FromSerializable(ManuscriptSerializable serializable)
	{
		switch(serializable.type)
		{
			case "chassis" : return ChassisFromSerializable(serializable);
			case "flying" : return FlyingFromSerializable(serializable);
			case "propulsion" : return PropulsionFromSerializable(serializable);
			case "weapon" : return WeaponFromSerializable(serializable);
		}
		throw new Exception("Unknow manuscript type [" + serializable.type + "]");
	}
	public ChassisManuscript ChassisFromSerializable(ManuscriptSerializable serializable)
	{
		return new ChassisManuscript();
	}
	public FlyingManuscript FlyingFromSerializable(ManuscriptSerializable serializable)
	{
		return new FlyingManuscript();
	}
	public PropulsionManuscript PropulsionFromSerializable(ManuscriptSerializable serializable)
	{
		return new PropulsionManuscript();
	}
	public WeaponManuscript WeaponFromSerializable(ManuscriptSerializable serializable)
	{
		return new WeaponManuscript();
	}
}