using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    Animator animator;
    [SerializeField] private FloatSO speed;
    
    private float timer = 0f;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(isDead)
        {
            timer += Time.deltaTime;

            if (timer > 2f)
                SceneManager.LoadScene("GameOver");
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            animator.SetTrigger("Dead");
            speed.value = 0f;

            isDead = true;
        }
    }
}

