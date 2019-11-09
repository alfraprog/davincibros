
using UnityEngine;       
using UnityEngine.UI;

public class ManuscriptPickerController : MonoBehaviour
{
    public GameObject manuscriptGameObject;

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
}
