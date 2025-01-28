
using UnityEngine;

public class Death : MonoBehaviour
{
    Animator animator;
    [SerializeField] private FloatSO speed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            animator.SetTrigger("Dead");
            speed.value = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
