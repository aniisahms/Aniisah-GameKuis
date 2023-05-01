using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(
    fileName = "New Player Progress",
    menuName = "Player Progress"
)]

public class PlayerProgress : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int poin;
        public Dictionary<string, int> levelProgress;
    }

    [SerializeField] string fileName = "example.txt";
    public MainData progressData = new MainData();

    [SerializeField] string startingLevelPackName = string.Empty;

    public void SaveProgress() 
    {
        // // sample data
        // progressData.poin = 200;
        
        // if (progressData.levelProgress == null){
        //     progressData.levelProgress = new();
        // }
        // progressData.levelProgress.Add("Level pack 1", 3);
        // progressData.levelProgress.Add("Level pack 3", 5);

        if (progressData.levelProgress == null)
        {
            progressData.levelProgress = new();
            progressData.poin = 0;
            progressData.levelProgress.Add(startingLevelPackName, 1);
        }

        // data storage information
#if UNITY_EDITOR
        string directory = Application.dataPath + "/Temporary/";
#elif (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        string directory = Application.persistentDataPath + "/LocalProgress/";
#endif
        var path = directory + "/" + fileName;

        // create temporary directory
        if (!Directory.Exists(directory)) {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been created: " + directory);
        }

        // create new file
        // if (!File.Exists(path))
        // {
        //     File.Create(path).Dispose();
        //     Debug.Log("File created: " + path);
        // }
        if (File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File created: " + path);
        }

        // var content = $"{progressData.poin}\n";

        // foreach (var i in progressData.levelProgress) {
        //     content += $"{i.Key}    {i.Value}\n";
        // }

        // File.WriteAllText(path, content);

        var fileStream = File.Open(path, FileMode.Open);
        fileStream.Flush(); // delete all content

        // // save the data with binary writer
        // var binaryWriter = new BinaryWriter(fileStream);

        // binaryWriter.Write(progressData.poin);
        // foreach (var i in progressData.levelProgress) {
        //     binaryWriter.Write(i.Key);
        //     binaryWriter.Write(i.Value);
        // }

        // save the data with binary formatter
        var formatter = new BinaryFormatter();

        formatter.Serialize(fileStream, progressData);

        // cut memory flow with file
        // binaryWriter.Dispose();
        fileStream.Dispose();
        Debug.Log($"{fileName} has been saved.");
    }

    public bool LoadProgress() 
    {
        // data storage information
        string directory = Application.dataPath + "/Temporary/";
        string path = directory + "/" + fileName;
        var fileStream = File.Open(path, FileMode.OpenOrCreate);

        try 
        {
            // var binaryReader = new BinaryReader(fileStream);

            // try
            // {
            //     progressData.poin = binaryReader.ReadInt32();

            //     if (progressData.levelProgress == null)
            //     {
            //         progressData.levelProgress = new();
            //     }

            //     while (binaryReader.PeekChar() != -1)
            //     {
            //         var levelPackName = binaryReader.ReadString();
            //         var whichLevel = binaryReader.ReadInt32();
            //         progressData.levelProgress.Add(levelPackName, whichLevel);

            //         Debug.Log($"{levelPackName} : {whichLevel}");
            //     }

            //     binaryReader.Dispose();
            // }
            // catch (System.Exception e)
            // {
            //     binaryReader.Dispose();
            //     fileStream.Dispose();
            //     Debug.Log($"ERROR: something went wrong when try to load binary progress\n {e.Message}");

            //     return false;
            // }

            // save the data with binary formatter
            var formatter = new BinaryFormatter();

            // deserialize the data
            progressData = (MainData)formatter.Deserialize(fileStream);
            
            fileStream.Dispose();
            Debug.Log($"{progressData.poin}; {progressData.levelProgress.Count}");
            
            return true;
        }
        catch (System.Exception e)
        {
            fileStream.Dispose();
            Debug.Log($"ERROR: something went wrong when try to load progress\n {e.Message}");
            
            return false;
        }
    }
}
