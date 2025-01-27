using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private FloatSO speed;
    [SerializeField] private GameObject mapBlock;
    [SerializeField] private List<GameObject> mapBlocks = new List<GameObject>(6);

    // Start is called before the first frame update
    void Start()
    {
        speed.value = 1f;
        int blockType = Random.Range(0, 6);

        Instantiate(mapBlock, new Vector3(0, 0, 0), Quaternion.Euler(0, 180, 0));
        Instantiate(mapBlocks[blockType], new Vector3(0, 0, 11), Quaternion.Euler(0, 180, 0));
    }

    private void OnTriggerEnter(Collider other)
    { 
        int blockType = Random.Range(0, 6);
        float diff = 11 + other.transform.position.z;

        Instantiate(mapBlocks[blockType], new Vector3(0, 0, 11 + diff), Quaternion.Euler(0, 180, 0));
        Destroy(other.gameObject);
    }
}
