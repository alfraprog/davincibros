
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

    public PlayerPickedController player1Picked;
    public PlayerPickedController player2Picked;

    public GameObject timerObject;

    public Book book;
    private List<int> p1;
    private List<int> p2;

    private long started;
    public int manuscriptsPerPlayer = 1;

    public int duration = 10;


    private void Start() {
        player1Picked.Checkable(manuscriptsPerPlayer);
        player2Picked.Checkable(manuscriptsPerPlayer);
    }
    void Update() {
        if(book == null)
        {
            Library library = libraryGameObject.GetComponent<Library>();
            if(library.loaded)
            {
                book = library.RandomBook(6);
                PickInBook(book);
            }
        }

        if(timerObject != null)
        {
            long diff = duration-(System.DateTime.Now.Ticks - started) / 10000000;
            timerObject.GetComponent<UnityEngine.UI.Text>().text = diff.ToString();
            if(diff < 0)
            {
                End();
            }
        }
    }

    public void PickInBook(Book book)
    {
        float x = -360.0f;
        string[] buttons = {
            "Manuscripts/Backgrounds/button_a",
            "Manuscripts/Backgrounds/button_b",
            "Manuscripts/Backgrounds/button_y",
            "Manuscripts/Backgrounds/button_x",
            "Manuscripts/Backgrounds/button_lb",
            "Manuscripts/Backgrounds/button_rb"
        };
        
        int i=0;
        foreach(AbstractManuscript manuscript in book.manuscripts)
        {
            GameObject gameObject = Instantiate(manuscriptGameObject);
            ManuscriptController controller = gameObject.GetComponent<ManuscriptController>();

            gameObject.transform.position = new Vector3(0.0f,0.0f,700.0f);
            gameObject.transform.localScale = new Vector3(0.0f,0.0f,1.0f);
            controller.FillWith(manuscript);
            controller.UseButton(buttons[i++]);
            controller.AnimateTo(x, 0.5f, 400);
            x += 180.0f; 
        }

        p1 = new List<int>();
        p2 = new List<int>();
        started = System.DateTime.Now.Ticks;

    }

    void FixedUpdate()
    {
        int done = 0;
        if(p1 != null && SelectFor( player1Inputs.ReadInput(), p1))
        {
            done++;
        }
        if(p2 != null && SelectFor( player2Inputs.ReadInput(), p2))
        {
            done++;
        }

        player1Picked.CheckedUntil(p1.Count);
        player2Picked.CheckedUntil(p2.Count);

        if(done > 1)
        {
            End();
        }
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

    private void End()
    {
        if(p1.Count < manuscriptsPerPlayer)
        {
            SelectRandom(p1);
        }
        if(p2.Count < manuscriptsPerPlayer)
        {
            SelectRandom(p2);
        }

        Book p1Book = GameManager.Instance.selectedManuscripts.Count > 1
            ?  GameManager.Instance.selectedManuscripts[0]
            : new Book();

        Book p2Book = GameManager.Instance.selectedManuscripts.Count > 1
            ?  GameManager.Instance.selectedManuscripts[1]
            : new Book();

        AppendToBook(p1Book, p1);
        AppendToBook(p2Book, p2);
        GameManager.Instance.EndManuscriptSelectPhase(p1Book, p2Book);
    }

    private void SelectRandom(List<int> selected)
    {
        System.Random random = new System.Random();
        while(selected.Count < manuscriptsPerPlayer)
        {
            int selection = random.Next(0, book.manuscripts.Count);
            if(!selected.Contains(selection))
            {
                selected.Add(selection);
            }
        }
    }

    private void AppendToBook(Book book, List<int> selected)
    {
        foreach(int i in selected)
        {
            book.AddManuscript(this.book.manuscripts[i]);
        }
    }
}
