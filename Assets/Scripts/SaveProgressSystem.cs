using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveProgressSystem : MonoBehaviour
{
    public static void SaveGame(GamePanels PanelsData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PlayerScore.sv";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerScore data = new PlayerScore(PanelsData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerScore LoadGame()
    {
        string path = Application.persistentDataPath + "/PlayerScore.sv";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerScore data = formatter.Deserialize(stream) as PlayerScore;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Сохранение не найдено");
            return null;
        }
    }
}
