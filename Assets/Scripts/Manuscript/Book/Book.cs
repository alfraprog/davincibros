
using System.Collections.Generic;

public class Book
{
	public List<AbstractManuscript> manuscripts = new List<AbstractManuscript>();

	public void AddManuscript(AbstractManuscript manuscript)
	{
		manuscripts.Add(manuscript);
	}
}
