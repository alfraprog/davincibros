
using UnityEngine;       
using UnityEngine.UI;
using PlayerInput;
using System;

public class ManuscriptPickerController : MonoBehaviour
{
    public GameObject manuscriptGameObject;
    public GameObject libraryGameObject;

    public LocalInputReader player1Inputs;
    public LocalInputReader player2Inputs;

    public GameObject timerObject;

    public Book book;
    private AbstractManuscript p1Selection;
    private AbstractManuscript p2Selection;
    
    private long started;

    private void Start() {
        started = System.DateTime.Now.Ticks;
    }

    void Update() {
        if(book == null)
        {
            Library library = libraryGameObject.GetComponent<Library>();
            if(library.loaded)
            {
                book = library.RandomBook(2);
                PickInBook(book, 1);
            }
        }

        if(timerObject != null)
        {
            long diff = 60-(System.DateTime.Now.Ticks - started) / 10000000;
            timerObject.GetComponent<UnityEngine.UI.Text>().text = diff.ToString();
        }
    }

    public void PickInBook(Book book, int manuscriptPerPlayer)
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
    }

    void FixedUpdate()
    {
        p1Selection = SelectFor( player1Inputs.ReadInput(), p1Selection);
        p2Selection = SelectFor( player2Inputs.ReadInput(), p2Selection);
        if(p1Selection)
        {
            Debug.Log("P1 CARD SELECTED");
            Debug.Log(p1Selection);
        }
    }

    AbstractManuscript SelectFor(Inputs inputs, AbstractManuscript manuscript)
    {
        if(inputs.manuscript1)  manuscript = book.manuscripts[0];
        if(inputs.manuscript2)  manuscript = book.manuscripts[1];
        /*if(inputs.manuscript3)  manuscript = book.manuscripts[2];
        if(inputs.manuscript4)  manuscript = book.manuscripts[3];
        if(inputs.manuscript5)  manuscript = book.manuscripts[4];
        if(inputs.manuscript6)  manuscript = book.manuscripts[5];
        */
        return manuscript;
    }
}
