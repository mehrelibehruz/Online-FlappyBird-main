using UnityEngine;

public class SpawnBarrierManager : MonoBehaviour
{
    [SerializeField] GameObject barrier;
    [SerializeField] Transform spawnPos;
    [SerializeField] float time;
    [SerializeField] float repeatRate;

    [SerializeField] DinoStatement dinoStatement;

    private void Start()
    {
        InvokeRepeating("Spawn", time, repeatRate);
    }

    void Spawn()
    {
        if (dinoStatement.GetScore() % 10 == 0)
            repeatRate += 2;
            Instantiate(barrier, spawnPos.position, Quaternion.identity);
    }

}