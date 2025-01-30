using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    Animator animator;
    [SerializeField] private FloatSO speed;

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

           
            Invoke("ReloadScene", 2f);  
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    void Update()
    {
        
    }
}

