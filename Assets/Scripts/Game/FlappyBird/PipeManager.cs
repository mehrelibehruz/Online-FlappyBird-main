using UnityEngine;
public class PipeManager : MonoBehaviour
{
    [SerializeField] float _topBorder;
    [SerializeField] float _bottomBorder;
    [SerializeField] float _rightBorder;

    [SerializeField] GameObject _pipe;
    //[SerializeField] PipeController _pipes;
    Vector3 _pos;

    //[SerializeField] List<PipeController> _pipes;
    private void Start()
    {
        _pos = transform.position;
        SpawnPipe();
        transform.position = _pos;
    }
    void SpawnPipe()
    {
        _pos = new Vector3(_rightBorder, Random.Range(_bottomBorder, _topBorder), 0);
        Instantiate(_pipe, _pos, Quaternion.identity);
    }

    [SerializeField] float time = 0.4f;
    [SerializeField] float secondTime = 1f;
    private void Update()
    {
        time += Time.deltaTime;

        if (time > secondTime)
        {
            time = 0;
            SpawnPipe();
        }
    }
}