using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;           

public class DebugManuscriptController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    	Debug.Break();
        string filePath = Path.Combine(Application.streamingAssetsPath, "Data/Manuscript/Json/libraryDebug.json");
    	LibraryFactory factory = new LibraryFactory();
    	Library library = factory.fromJSON("");
    	Debug.Break();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
