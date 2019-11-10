
using UnityEngine;       
using UnityEngine.UI;

public class ManuscriptController : MonoBehaviour
{
    private float initialScale;
    private float initialX;
    private float targetScale;
    private float targetX;
    private long startAt;
    private long duration;

    private bool animated = false;

    private void Update() {
        if(animated)
        {
            long now = System.DateTime.Now.Ticks;
            long diff = (now - startAt) / 10000;
            float x = 0;
            float s = 0;
            float percentage = (diff*1.0f) /(duration*1.0f);
            if(diff < duration)
            {
                x = initialX + (targetX-initialX) * percentage;
                s = initialScale + (targetScale-initialScale) * percentage;
            }
            else
            {
                percentage = 1.0f;
                x = targetX;
                s = targetScale;
                animated = false;
            }
            var position = transform.position;
            var scale = transform.localScale;
            position.x = x;
            scale.x = s;
            scale.y = s;
            transform.position = position;
            transform.localScale = scale;
        }
    }
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
    public void UseButton(string path)
    {

		Texture2D imageTexture = Resources.Load<Texture2D>(path);
        if(imageTexture)
        {
            GameObject button = transform.Find ("Button").gameObject;
            Sprite imageSprite = Sprite.Create(imageTexture, new Rect(0.0f, 0.0f, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
            button.GetComponent<UnityEngine.UI.Image>().sprite  = imageSprite;
        }
    }

    public void AnimateTo(float x, float scale, long duration)
    {
        targetX = x;
        targetScale = scale;
        this.duration = duration;
        startAt = System.DateTime.Now.Ticks;
        initialX = transform.position.x;
        initialScale = transform.localScale.x;
        animated = true;
    }
}
