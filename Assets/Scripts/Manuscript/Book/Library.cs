using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    public bool loaded = false;

    public List<AbstractManuscript> manuscripts;
    public WeaponManuscript[] weaponManuscripts;
    public FlyingManuscript[] flyingManuscripts;
    public PropulsionManuscript[] propulsionManuscripts;
    public ArmorManuscript[] armorManuscripts;

    void Start()
    {
        weaponManuscripts = Resources.LoadAll<WeaponManuscript>("Manuscripts/Weapons");
        flyingManuscripts = Resources.LoadAll<FlyingManuscript>("Manuscripts/Flying");
        propulsionManuscripts = Resources.LoadAll<PropulsionManuscript>("Manuscripts/Propulsion");
        armorManuscripts = Resources.LoadAll<ArmorManuscript>("Manuscripts/Armor");
        
        manuscripts = new List<AbstractManuscript>();
        manuscripts.AddRange(weaponManuscripts);
        manuscripts.AddRange(flyingManuscripts);
        manuscripts.AddRange(propulsionManuscripts);
        manuscripts.AddRange(armorManuscripts);

        loaded=true;
    }

    public Book RandomBook(int size)
    {
        if(size > manuscripts.Count)
        {
            throw new Exception("Not enough manuscript to build a book");
        }

        int[] indexes = new int[size];
        int i=0;
        System.Random random = new System.Random();

        while(i<size)
        {
            indexes[i] = random.Next(0, manuscripts.Count);
            bool picked = false;
            for(int j=0; j<i; j++)
            {
                picked = picked || indexes[j]==indexes[i];
            }
            if(!picked)
            {
                i++;
            }
        }

        Book book = new Book();
        foreach(int index in indexes )
        {
            book.AddManuscript(manuscripts[index]);
        }
        return book;
    }
}
