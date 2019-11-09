
using System.Collections.Generic;

public class Book
{
	private List<AbstractManuscript> manuscrits = new List<AbstractManuscript>();

	public void addManuscript(AbstractManuscript manuscrit)
	{
		manuscrits.Add(manuscrit);
	}
}
