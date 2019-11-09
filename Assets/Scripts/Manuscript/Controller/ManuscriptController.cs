
using UnityEngine;       

public class ManuscriptController : MonoBehaviour
{
    public void FillWith(AbstractManuscript manuscript)
    {
        GameObject title = GameObject.Find ("Title");
        GameObject description = GameObject.Find ("Title");
        GameObject image = GameObject.Find ("Image");
        GameObject background = GameObject.Find ("Background");

        title.GetComponent<UnityEngine.UI.Text>().text = manuscript.title;
        description.GetComponent<UnityEngine.UI.Text>().text = manuscript.description;
    }
}
