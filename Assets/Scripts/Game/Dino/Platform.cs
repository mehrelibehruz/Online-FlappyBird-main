using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    // float time = 0f;
    float withSize;
    [SerializeField] float platformSpeed;
    private void Start()
    {
        withSize = spriteRenderer.size.x;
    }
    
    private void Update()
    {
        // time += Time.deltaTime;

        // Debug.LogError(time);

        spriteRenderer.size = new Vector2(withSize += platformSpeed * Time.deltaTime, spriteRenderer.size.y);
    }
}