using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private FloatSO speed;
    [SerializeField] private GameObject mapBlock;

    // Start is called before the first frame update
    void Start()
    {
        speed.value = 1f;

        Instantiate(mapBlock);
        Instantiate(mapBlock, new Vector3(0, 0, 11), Quaternion.Euler(0, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        float diff = 11 + other.transform.position.z;
        Instantiate(mapBlock, new Vector3(0, 0, 11 + diff), Quaternion.Euler(0, 180, 0));
        Destroy(other.gameObject);
    }
}
