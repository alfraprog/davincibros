
using UnityEngine;       
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerPickedController : MonoBehaviour
{
    public bool alignRight = false;

    public GameObject checkboxGameObject;

    private List<GameObject> checkboxes;

    public void Checkable(int size) {
        checkboxes = new List<GameObject>();
        float x= alignRight ? 60.0f : -60.0f; 

        for(int i=0;i<size; ++i)
        {
            GameObject gameObject = Instantiate(checkboxGameObject, transform);
            gameObject.transform.localPosition = new Vector3(x,-30.0f,0.0f);
            x += alignRight ? -20.0f : 20.0f; 
            checkboxes.Add(gameObject);
        }
        CheckedUntil(0);
    }
    public void CheckedUntil(int until)
    {
        for(int i=0;i<checkboxes.Count; ++i)
        {
            GameObject checkbox = checkboxes[i];
            GameObject imageObject = checkbox.transform.Find ("Checked").gameObject;
            Image image = imageObject.GetComponent<Image>();
            var color = image.color;
            if(i<until)
            {
                color.a = 1f;
            }
            else
            {
                color.a = 0f;
            }
            image.color = color;
        }
    }
}
