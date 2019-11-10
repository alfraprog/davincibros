
using UnityEngine;       
using UnityEngine.UI;
using PlayerInput;
using System;
using System.Collections.Generic;

public class ManuscriptPickerController : MonoBehaviour
{
    public GameObject manuscriptGameObject;
    public GameObject libraryGameObject;

    public LocalInputReader player1Inputs;
    public LocalInputReader player2Inputs;

    public GameObject timerObject;

    public Book book;
    private List<int> p1;
    private List<int> p2;
    
    private long started;
    public int manuscriptsPerPlayer = 1;


    void Update() {
        if(book == null)
        {
            Library library = libraryGameObject.GetComponent<Library>();
            if(library.loaded)
            {
                book = library.RandomBook(2);
                PickInBook(book);
            }
        }

        if(timerObject != null)
        {
            long diff = 60-(System.DateTime.Now.Ticks - started) / 10000000;
            timerObject.GetComponent<UnityEngine.UI.Text>().text = diff.ToString();
        }
    }

    public void PickInBook(Book book)
    {
        float x = -360.0f;

        foreach(AbstractManuscript manuscript in book.manuscripts)
        {
            GameObject gameObject = Instantiate(manuscriptGameObject);
            ManuscriptController controller = gameObject.GetComponent<ManuscriptController>();

            gameObject.transform.position = new Vector3(x,0.0f,700.0f);
            gameObject.transform.localScale = new Vector3(0.5f,0.5f,1.0f);
            controller.FillWith(manuscript);
            x += 180.0f; 
        }

        p1 = new List<int>();
        p2 = new List<int>();
        started = System.DateTime.Now.Ticks;

    }

    void FixedUpdate()
    {
        if(p1 != null && SelectFor( player1Inputs.ReadInput(), p1))
        {
            Debug.Log("P1 DONE");
            Debug.Log(p1);
        }
        /*
        if(SelectFor( SelectFor( player2Inputs.ReadInput(), p2)))
        {
            Debug.Log("P2 DONE");
            Debug.Log(p2);
        }*/
    }

    bool SelectFor(Inputs inputs, List<int> selected)
    {
        int selection = -1;
        if(inputs.manuscript1)       {selection=0;}
        else if(inputs.manuscript2)  {selection=1;}
        else if(inputs.manuscript3)  {selection=2;}
        else if(inputs.manuscript4)  {selection=3;}
        else if(inputs.manuscript5)  {selection=4;}
        else if(inputs.manuscript6)  {selection=5;}
        
        if(selection != -1)
        {
            if(!selected.Contains(selection) && selected.Count < manuscriptsPerPlayer)
            {
                selected.Add(selection);
            }
        }

        return selected.Count == manuscriptsPerPlayer;
    }
}
