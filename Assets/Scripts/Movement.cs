using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float fireSpeed;

    [SerializeField] private PlayerManager playerManager;

    private int moveInput = 0;

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        if (playerManager.playerState == PlayerManager.PlayerState.OnBase)
        {
            if (Input.GetMouseButtonDown(0))
            {
                moveInput = 1;
                playerManager.playerState = PlayerManager.PlayerState.NotOnBase;

                if (playerManager.rotateDirection == PlayerManager.RotateDirectionState.ClockWise)
                {
                    playerManager.rotateDirection = PlayerManager.RotateDirectionState.CounterClockWise;
                }
                else
                {
                    playerManager.rotateDirection = PlayerManager.RotateDirectionState.ClockWise;
                }
            }
        }
    }

    private void Move()
    {
        transform.Translate(Vector2.right * moveInput * fireSpeed * Time.fixedDeltaTime, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            moveInput = -1;
            playerManager.enemyState = PlayerManager.EnemyState.Dead;
            playerManager.PlayEnemyPFX(collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            playerManager.CallSpawnEnemy();
            playerManager.CallIncreaseMetodFromDifficulty();
            playerManager.UpdateScore();
        }

        else if (collision.gameObject.tag == "Base")
        {
            moveInput = 0;
            playerManager.playerState = PlayerManager.PlayerState.OnBase;
        }
        else if (collision.gameObject.tag == "Ring")
        {
            playerManager.PlayPlayerPFX(transform.position,transform.rotation);
            print("Game Over");
            Destroy(gameObject);
        }
    }
}
