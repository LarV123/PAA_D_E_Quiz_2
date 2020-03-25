using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem {
	private static SaveSystem instance;

	public static SaveSystem Instance {

		get {
			if (Equals(instance, null)) instance = new SaveSystem();
			return instance;
		}

	}

	private SaveFile saveFile;

	public SaveFile FileSave {
		get {
			return saveFile;
		}
	}

	private string savePath;

	public SaveSystem() {
		savePath = Application.persistentDataPath + "/Game.data";
		if (File.Exists(savePath)) {
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(savePath, FileMode.Open);

			saveFile = formatter.Deserialize(stream) as SaveFile;
			stream.Close();

		} else {
			saveFile = new SaveFile();

			BinaryFormatter formatter = new BinaryFormatter();

			FileStream stream = new FileStream(savePath, FileMode.Create);

			formatter.Serialize(stream, saveFile);
			stream.Close();
		}
	}

	public void SaveFile() {
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/Game.data";

		FileStream stream = new FileStream(path, FileMode.Create);

		formatter.Serialize(stream, instance.saveFile);
		stream.Close();
	}

	public void LoadFile() {
		string path = Application.persistentDataPath + "/Game.data";
		if (File.Exists(path)) {
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			instance.saveFile = formatter.Deserialize(stream) as SaveFile;
			stream.Close();

		} else {

			instance.saveFile = new SaveFile();

			SaveFile();
		}
	}

}
