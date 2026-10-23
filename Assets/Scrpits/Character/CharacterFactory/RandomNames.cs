
using System;
using UnityEngine;

public class RandomNames : MonoBehaviour
{
    [Serializable]
    public class NameEntry
    {
        public string id;
        public string ko;
        public string en;
    }

    [Serializable]
    public class NameData
    {
        public NameEntry[] items;
    }

    // NameJsonReader에서 JSON 정보를 가져온다.
    [SerializeField] private NameJsonReader nameJsonReader;

    // JSON에서 변환한 이름 데이터
    private NameEntry[] givenNames;
    private NameEntry[] lineageNames;

    private bool isInitialized;

    public NameEntry[] GivenNames => givenNames;
    public NameEntry[] LineageNames => lineageNames;

    private void Start()
    {
        Initialize();
    }

    // NameJsonReader의 JSON 정보를 이름 배열로 변환한다.
    private void Initialize()
    {
        if (nameJsonReader == null)
            return;

        string givenNamesJson = nameJsonReader.GivenNamesJson;
        string lineageNamesJson = nameJsonReader.LineageNamesJson;

        if (string.IsNullOrEmpty(givenNamesJson) ||
            string.IsNullOrEmpty(lineageNamesJson))
            return;

        NameData givenNameData =
            JsonUtility.FromJson<NameData>(givenNamesJson);

        NameData lineageNameData =
            JsonUtility.FromJson<NameData>(lineageNamesJson);

        if (givenNameData == null ||
            lineageNameData == null ||
            givenNameData.items == null ||
            lineageNameData.items == null ||
            givenNameData.items.Length == 0 ||
            lineageNameData.items.Length == 0)
            return;

        givenNames = givenNameData.items;
        lineageNames = lineageNameData.items;

        isInitialized = true;
    }

  
}
