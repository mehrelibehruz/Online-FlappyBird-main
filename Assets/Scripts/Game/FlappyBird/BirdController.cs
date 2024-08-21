using LootLocker.Requests;
using System.Collections;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private FlappyUI flappyUI;

    [Range(1, 20)][SerializeField] float jumpAmount;
    [SerializeField] FlappyBirdStatement flappyBirdStatement;
    
    // Collionlari Interact classina kocurt: Umumi olacaq interact.
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DoJump();
        }
    }
    private void DoJump()
    {
        rb.velocity = new Vector2(0, 1 * jumpAmount);
        // rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.GameOver.ToString()))
        {           
            SoundManager.instance.GameOver_MP3();
            rb.velocity = Vector2.zero;

            flappyBirdStatement.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Score.ToString()))
        {
            flappyBirdStatement.UpdateScore();
        }
    }

}