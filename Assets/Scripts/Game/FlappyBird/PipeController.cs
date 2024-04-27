using UnityEngine;

public class PipeController : MonoBehaviour
{
    [Range(0, 15)][SerializeField] float _pipeSpeed;
    [Range(0, 10)][SerializeField] float _destroyTime;
    private void Start()
    {
        Destroy(gameObject, _destroyTime);
    }
    private void Update()
    {
        // MySelf
        transform.Translate(Vector2.left * _pipeSpeed * Time.deltaTime);

        // Other
        //transform.position += Vector3.left * _pipeSpeed * Time.deltaTime;
    }
}
