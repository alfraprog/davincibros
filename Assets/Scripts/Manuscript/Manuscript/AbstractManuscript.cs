using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractManuscript : ScriptableObject
{
    [SerializeField]
    public string title;
    [SerializeField]
    public string description;
    [SerializeField]
    public string imagePath;
    [SerializeField]
    public string backgroundPath;

}
