using UnityEngine;

public class SpawnBarrier : MonoBehaviour
{
    [SerializeField] GameObject barrier;
    [SerializeField] Transform spawnPos;
    [SerializeField] float time;
    [SerializeField] float repeatRate;

    private void Start()
    {
        InvokeRepeating("Spawn", time, repeatRate);
    }

    void Spawn()
    {
        Instantiate(barrier, spawnPos.position, Quaternion.identity);
    }
}