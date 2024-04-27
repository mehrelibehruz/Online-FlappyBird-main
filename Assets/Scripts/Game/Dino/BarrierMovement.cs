using UnityEngine;

public class BarrierMovement : MonoBehaviour {
    [SerializeField] float moveSpeed;
    [SerializeField] float destroyTime;
    private void Update() {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        Destroy(gameObject, destroyTime);
    }
}