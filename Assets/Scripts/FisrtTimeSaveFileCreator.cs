using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FisrtTimeSaveFileCreator : MonoBehaviour
{
    void Start()
    {
     string path = Application.persistentDataPath + "/PlayerScore.sv";
        if (!File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            stream.Close();
        }
    }

}
