
using System;
using System.IO;
 using UnityEngine;

public class LibraryFactory
{
	public Library fromJSON(string path)
	{
		string content = File.ReadAllText(path); 
        LibrarySerializable serializable = JsonUtility.FromJson<LibrarySerializable>(content);
		return fromSerializable(serializable);
	}

	public Library fromSerializable(LibrarySerializable librarySerializable)
	{
		ManuscriptFactory factory = new ManuscriptFactory();		
		Book book = new Book();

		foreach(ManuscriptSerializable manuscriptSerializable in librarySerializable.manuscripts)
		{
			book.addManuscript(factory.fromSerializable(manuscriptSerializable));
		}

		return new Library(book); 
	}
}