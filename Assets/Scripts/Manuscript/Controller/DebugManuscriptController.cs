using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;           

public class DebugManuscriptController : MonoBehaviour
{
    public GameObject manuscript;

    // Start is called before the first frame update
    void Start()
    {
        Library library = new Library();

        var m = Instantiate(manuscript);
        var o = m.GetComponent<ManuscriptController>();
        //o.FillWith(library.book.manuscrits[0]);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
