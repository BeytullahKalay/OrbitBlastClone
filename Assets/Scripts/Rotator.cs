using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private float rotateSpeed;
    private void FixedUpdate()
    {
        if (playerManager.playerState == PlayerManager.PlayerState.OnBase)
        {
            int rotateDirHolder;
            if (playerManager.rotateDirection == PlayerManager.RotateDirectionState.ClockWise)
            {
                rotateDirHolder = 1;
            }
            else
            {
                rotateDirHolder = -1;
            }
            transform.Rotate(Vector3.forward, rotateSpeed * rotateDirHolder * Time.fixedDeltaTime);
        }
    }
}
