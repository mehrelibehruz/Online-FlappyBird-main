using UnityEngine;

public class DinoMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpPower = 8f;

    [SerializeField] DinoStatement dinoStatement;
    [SerializeField] Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.position.y < 0)
        {
            rb.velocity = Vector2.up * jumpPower;
        }        
    }
    string barrier = "DinoBarrier";
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(barrier))
        {
            dinoStatement.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreArea"))
        {
            dinoStatement.UpdateScore();
        }
    }

}