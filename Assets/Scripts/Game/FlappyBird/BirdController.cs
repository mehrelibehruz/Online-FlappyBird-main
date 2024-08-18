using LootLocker.Requests;
using System.Collections;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] FlappyBirdStatement flappyBirdStatement;
    [SerializeField] FlappyUI flappyUI;
    [Range(1, 20)][SerializeField] float jumpAmount;
    [SerializeField] private Rigidbody2D rb;
    //bool jumpInput = false;

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
            //StartCoroutine(OverDelay());
            SoundManager.instance.GameOver_MP3();
            rb.velocity = Vector2.zero;

            // levelManager.GameOver();
            // _leaderboard = levelManager.leaderboard;
            
            flappyBirdStatement.GameOver();           
        }
    }

    //IEnumerator OverDelay()
    //{
    //    yield return new WaitForSeconds(5f);
    //    yield return StartCoroutine(_leaderboard.SubmitScoreRoutine(_score));
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Score.ToString()))
        {
            flappyBirdStatement.UpdateScore();
            // flappyUI.
        }
    }
}
