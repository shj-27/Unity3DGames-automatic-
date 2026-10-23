using System.IO;
using UnityEngine;

public class NameJsonReader : MonoBehaviour
{
    private const string FolderPath = "Assets/Jsons/";

    private const string GivenNamesFile = "given_names.json";
    private const string LineageNamesFile = "lineage_names.json";

    private string givenNamesJson;
    private string lineageNamesJson;

    public string GivenNamesJson => givenNamesJson;
    public string LineageNamesJson => lineageNamesJson;

    private void Awake()
    {
        givenNamesJson = File.ReadAllText(
            Path.Combine(FolderPath, GivenNamesFile)
        );

        lineageNamesJson = File.ReadAllText(
            Path.Combine(FolderPath, LineageNamesFile)
        );
    }
}