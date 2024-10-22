using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float range = 5f;

    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = transform.position;
        ResetTarget();
    }

    public void ResetTarget()
    {
        float x = Random.Range(_initialPosition.x - range, _initialPosition.x + range);
        float z = Random.Range(_initialPosition.z - range, _initialPosition.z + range);
        transform.position = new Vector3(x, _initialPosition.y, z);
    }
}