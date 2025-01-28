using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField] private FloatSO speed;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.z -= speed.value * Time.deltaTime;
        transform.position = pos;
    }
}
