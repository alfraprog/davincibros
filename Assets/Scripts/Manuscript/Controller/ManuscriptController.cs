
using UnityEngine;       
using UnityEngine.UI;

public class ManuscriptController : MonoBehaviour
{
    public void FillWith(AbstractManuscript manuscript)
    {
        GameObject title = transform.Find ("Title").gameObject;
        GameObject description = transform.Find ("Description").gameObject;
        GameObject image = transform.Find ("Image").gameObject;
        GameObject background = transform.Find ("Background").gameObject;

        title.GetComponent<UnityEngine.UI.Text>().text = manuscript.title;
        description.GetComponent<UnityEngine.UI.Text>().text = manuscript.description;

		Texture2D imageTexture = Resources.Load<Texture2D>(manuscript.imagePath);
        if(imageTexture)
        {
            Sprite imageSprite = Sprite.Create(imageTexture, new Rect(0.0f, 0.0f, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
		    image.GetComponent<UnityEngine.UI.Image>().sprite  = imageSprite;
        }

		Texture2D backgroundImageTexture = Resources.Load<Texture2D>(manuscript.backgroundPath);
        if(backgroundImageTexture)
        {
            Sprite backgroundImageSprite = Sprite.Create(backgroundImageTexture, new Rect(0.0f, 0.0f, backgroundImageTexture.width, backgroundImageTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
            background.GetComponent<UnityEngine.UI.Image>().sprite  = backgroundImageSprite;
        }
    }
}
