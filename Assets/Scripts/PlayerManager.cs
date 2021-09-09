using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Spawner spawner;
    public ParticleSystem enemyPFX;
    public ParticleSystem playerPFX;
    public Text scoreText;

    private void Start()
    {
        scoreText.text = GetScore().ToString();
    }

    public PlayerState playerState;
    public enum PlayerState
    {
        OnBase,
        NotOnBase,
    }

    public EnemyState enemyState;
    public enum EnemyState
    {
        Dead,
        Lives
    }

    public RotateDirectionState rotateDirection;
    public enum RotateDirectionState
    {
        ClockWise,
        CounterClockWise,
    }

    public void CallSpawnEnemy()
    {
        spawner.Invoke("SpawnEnemy", spawner.newEnemyCallTime);
    }

    public void PlayEnemyPFX(Vector3 position,Quaternion rotation)
    {
        enemyPFX.transform.position = position;
        enemyPFX.transform.rotation = rotation;
        enemyPFX.Play();
    }

    public void PlayPlayerPFX(Vector3 position,Quaternion rotation)
    {
        playerPFX.transform.position = position;
        playerPFX.transform.rotation = rotation;
        playerPFX.Play();
    }

    public void CallIncreaseMetodFromDifficulty()
    {
        Difficulty.IncreaseCurrentScore();
    }

    public int GetScore()
    {
        return Difficulty.GetCurrentScore();
    }

    public void UpdateScore()
    {
        scoreText.text = GetScore().ToString();
    }

}
