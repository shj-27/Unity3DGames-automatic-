using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private Autos autos;

    [SerializeField]
    private CharacterInventory inventory;

    void Start()
    {
        StartCoroutine(
            autos.AutoSpawn(
                7f,
                inventory.MaxSlot,
                inventory.GetCurrentCount,
                SpawnCharacter
            )
        );
    }

    void SpawnCharacter()
    {
        inventory.AddCharacter();

        Debug.Log(
            "현재 개수 : " +
            inventory.GetCurrentCount()
        );
    }
}
