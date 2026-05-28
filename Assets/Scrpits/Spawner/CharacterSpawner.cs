using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private CharacterPool pool;
    [SerializeField] private Transform spawnPoint;

    public Character Spawn(CharacterData data)
    {
        GameObject obj = pool.Get();

        obj.transform.position = spawnPoint.position;

        Character character = obj.GetComponent<Character>();
        character.SetID(data.id);

        return character;
    }
}

