using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;           

public class DebugManuscriptController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = Path.Combine(Application.dataPath, "Data/Manuscript/Json/libraryDebug.json");
    	LibraryFactory factory = new LibraryFactory();
    	Library library = factory.FromJSON(path);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
