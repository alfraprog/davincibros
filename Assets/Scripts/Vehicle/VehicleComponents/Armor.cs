﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    public class Armor : MonoBehaviour
    {
        public float mass;


        public void InitFromManuscript(ArmorManuscript manuscript)
        {
            mass = manuscript.mass;
        }
    }
}

