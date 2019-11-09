using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;           

public class DebugManuscriptController : MonoBehaviour
{
    public GameObject manuscriptPicker;

    // Start is called before the first frame update
    void Start()
    {
        Library library = new Library();

        /*
        var m = Instantiate(manuscript);
        var o = m.GetComponent<ManuscriptController>();
        o.FillWith(library.book.manuscrits[0]);

        var m = Instantiate(manuscriptPicker);
        var o = m.GetComponent<ManuscriptPickerController>();
        o.PickInBook(library.book, 5);
        */

    }

    // Update is called once per frame
    void Update()
    {
    }
}
