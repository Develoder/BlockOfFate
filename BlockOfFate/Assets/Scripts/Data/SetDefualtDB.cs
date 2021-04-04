using System.IO;
using UnityEngine;


public class SetDefualtDB : MonoBehaviour
{
    private const string copyFileName = "DefGameData/DefGameData.bytes";
    private const string pasteFileName =  "GameData.bytes";

    
    public void DefualtBD()
    {
        FileInfo fileInf = new FileInfo(FileName(copyFileName));
        if (fileInf.Exists)
        {
            fileInf.CopyTo(FileName(pasteFileName), true);
        }
        print("База сброшенна к базавым настройкам");
    }

    private static string FileName(string fileName)
    {
        return Path.Combine(Application.streamingAssetsPath, fileName);
    }
}
