
using System;
using System.IO;
 using UnityEngine;

public class LibraryFactory
{
	public Library FromJSON(string path)
	{
		string content = File.ReadAllText(path); 
        LibrarySerializable serializable = JsonUtility.FromJson<LibrarySerializable>(content);
		return FromSerializable(serializable);
	}

	public Library FromSerializable(LibrarySerializable librarySerializable)
	{
		ManuscriptFactory factory = new ManuscriptFactory();		
		Book book = new Book();

		foreach(ManuscriptSerializable manuscriptSerializable in librarySerializable.manuscripts)
		{
			book.AddManuscript(factory.FromSerializable(manuscriptSerializable));
		}

		return new Library(book); 
	}
}