using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    protected class PlayableGridCell
    {
        public Bounds cellBounds;
        public bool isOccupied;
    };
    public static EnemySpawner Instance { get; private set; }

    public uint EnemyCount = 5;
    public GameObject EnemyPrefab;
    public float PlayableGridCellSize = 2.2f;
    public int PlayerSafeCells = 1;
    public bool ShowDebugDraw = false;
    public int secondsUntilStart;

    GameObject PlayerShip = null;
    PlayableGridCell[,] PlayableAreaGrid = null;
    private bool IsSpawningFinished = false;
    private float time;
    public float timeBetweenSpawns;

    public void RegisterPlayer(GameObject playerObject)
    {
        PlayerShip = playerObject;
    }

    public void UnregisterPlayer(GameObject gameObject)
    {
        PlayerShip = null;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        time = Time.time;

    }

    private IEnumerator init()
    {
        yield return new WaitForSeconds(secondsUntilStart);
        if (!IsSpawningFinished)
        {
            Debug.Log("okay");
            SpawnNewAsteroids();
            IsSpawningFinished = true;
        }
        if (Time.time >= time + timeBetweenSpawns)
        {
            IsSpawningFinished = false;
            time = Time.time;
        }
    }

    void Update()
    {

        StartCoroutine(init());
        Debug.Log(PlayerShip);

    }

    private void SpawnNewAsteroids()
    {
        List<Vector3> enemyPositions = GameObject.Find("AsteroidSpawner").GetComponent<AsteroidSpawner>().FindFreePositions(EnemyCount);
        Debug.Log(enemyPositions);
        for (int i = 0; i < enemyPositions.Count; ++i)
        {
            Instantiate(EnemyPrefab, enemyPositions[i], Random.rotation);
        }
        
    }

    
}
