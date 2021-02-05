using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
using UnityEditor;

public class IOTest : MonoBehaviour
{
	[System.Serializable]
	public class MyDataType
	{
		public string name = "Jaydee";
		public long ageInMilliseconds;
	}

	public MyDataType myDataType;

	private void Start()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyDataType));

		string fileName = "file.txt";
		string filePath = Application.streamingAssetsPath;
		string url = Path.Combine(filePath, fileName);

		FileStream fStream;
		try
		{


			fStream = new FileStream(url, FileMode.Create);

			// Write data
			xmlSerializer.Serialize(fStream, myDataType);

			fStream.Flush();
			fStream.Close();
		}
		catch(System.Exception e)
		{
			Debug.Log(e.Message);
		}

		//fStream = new FileStream(url, FileMode.Open);
		StreamReader sReader;
		try
		{
			sReader = new StreamReader(url);

			while(!sReader.EndOfStream)
			{
				string s = sReader.ReadLine();
				Debug.Log(s);
			}

			sReader.Close();
		}
		catch(System.Exception e)
		{
			Debug.Log(e.Message);
		}

	}
}
