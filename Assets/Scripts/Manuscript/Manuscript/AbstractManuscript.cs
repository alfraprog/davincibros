public abstract class AbstractManuscript
{
   public string title = "";
   public string description = "";
   public string imagePath = "";
   public string backgroundPath = "";

    protected AbstractManuscript()
    {

    }

    protected AbstractManuscript(ManuscriptSerializable manuscriptSerializable) 
    {
        title = manuscriptSerializable.title;
        description = manuscriptSerializable.description;
        imagePath = manuscriptSerializable.image;
        backgroundPath = manuscriptSerializable.background;
    }
}
