using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float lineLenght = 20f;
    [SerializeField] private float rotateSmoothnes = 10f;
    public int newEnemyCallTime = 1;

    [SerializeField] Vector2 rotateDegreeMinMax = new Vector2(10, 360);
    [SerializeField] Vector2 rotateWhileGameplayDegreeMinMax = new Vector2(10, 350);

    public GameObject EnemyShape;
    public PlayerManager playerManager;

    private float sLerpDegree;
    private float lerpStartTime;

    private float currentDifficultyPercent;

    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        RotateSpawner();
    }

    public void SpawnEnemy()
    {
        float xPos = transform.position.x + lineLenght;
        Vector3 spawnPos = new Vector3(xPos, transform.position.y, transform.position.z);

        if (playerManager.enemyState == PlayerManager.EnemyState.Dead)
        {
            GameObject enemyObj = Instantiate(EnemyShape, spawnPos, Quaternion.identity);
            playerManager.enemyState = PlayerManager.EnemyState.Lives;
            enemyObj.transform.parent = transform;
            transform.Rotate(0, 0, Random.Range(rotateDegreeMinMax.x, rotateDegreeMinMax.y));


            float randomNum = Random.Range(0, 101);
            currentDifficultyPercent = (float)randomNum / 100;


            sLerpDegree = Random.Range(rotateWhileGameplayDegreeMinMax.x, rotateWhileGameplayDegreeMinMax.y);
            lerpStartTime = Time.time;
        }
    }

    private void RotateSpawner()
    {

        if (currentDifficultyPercent < Difficulty.GetDifficultyPercent())
        {

            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, sLerpDegree);

            float fracComplete = (Time.time - lerpStartTime) / rotateSmoothnes;
            transform.rotation = Quaternion.Slerp(currentRotation, wantedRotation, fracComplete);
        }

    }


    private void OnDrawGizmos()
    {
        float xPos = transform.position.x + lineLenght;
        Vector3 disPos = new Vector3(xPos, transform.position.y, transform.position.z);
        Gizmos.DrawLine(transform.position, disPos);
    }
}
