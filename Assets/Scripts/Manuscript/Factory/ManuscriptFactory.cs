
using UnityEngine;
using System.IO;          
using System;

public class ManuscriptFactory
{
	public AbstractManuscript FromJSON(string path)
	{
		throw new Exception("Not implemented yet");
	}

	public AbstractManuscript FromSerializable(ManuscriptSerializable serializable)
	{
		AbstractManuscript instance;

		switch(serializable.type)
		{
			case "chassis" : 
				instance = ChassisFromSerializable(serializable);
				break;
			case "flying" : 
				instance = FlyingFromSerializable(serializable);
				break;
			case "propulsion" : 
				instance = PropulsionFromSerializable(serializable);
				break;
			case "weapon" : 
				instance = WeaponFromSerializable(serializable);
				break;
			default :
				throw new Exception("Unknow manuscript type [" + serializable.type + "]");
		}

		instance.title = serializable.title;
		instance.description = serializable.description;
		instance.imagePath =  "Manuscript/Images/" + serializable.image;
		instance.backgroundPath = "Manuscript/Backgrounds/" + serializable.background;
		return instance;
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
