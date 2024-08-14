using UnityEngine;
public class CrystallSpawner : MonoBehaviour
{
    private const float MIN_RANGE_X = -27;
    private const float MAX_RANGE_X = 18;
    private const float RANGE_Y = 4;
    private const float MIN_RANGE_Z = -15;
    private const int MAX_RANGE_Z = 25;
    [SerializeField] private GameObject _crystalPrefab;
    [SerializeField] private Transform _spawnArea;
    [SerializeField] private int _numberOfCrystals = 5;  

    void Start()
    {
        SpawnCrystals();
    }

    void SpawnCrystals()
    {
        for (int i = 0; i < _numberOfCrystals; i++)
        {
            Vector3 randomPosition = new(Random.Range(MIN_RANGE_X, MAX_RANGE_X), Random.Range(RANGE_Y, RANGE_Y), Random.Range(MIN_RANGE_Z, MAX_RANGE_Z));

            Instantiate(_crystalPrefab, randomPosition, Quaternion.identity);
        }
    }
}
