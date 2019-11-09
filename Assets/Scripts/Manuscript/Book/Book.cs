
using System.Collections.Generic;

public class Book
{
	public List<AbstractManuscript> manuscrits = new List<AbstractManuscript>();

	public void AddManuscript(AbstractManuscript manuscrit)
	{
		manuscrits.Add(manuscrit);
	}
}
