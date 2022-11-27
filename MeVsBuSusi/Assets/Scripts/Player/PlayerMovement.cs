using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 100f;

    [Header("Fx")]
    [SerializeField] private ParticleSystem forwardFx;
    [SerializeField] private ParticleSystem backwardFx;

    [SerializeField] private Rigidbody2D playerRigidbody;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        PlayerVerticalMove(verticalInput);
        PlayerTurn(verticalInput, horizontalInput);
    }

    private void PlayerVerticalMove(float _verticalInput)
    {
        Vector2 movePosition = playerRigidbody.position + (Vector2)playerRigidbody.transform.up * _verticalInput * moveSpeed * Time.fixedDeltaTime;
        playerRigidbody.MovePosition(movePosition);

        HandleParticle(_verticalInput);
    }

    private void PlayerTurn(float _verticalInput, float _horizontalInput)
    {
        if (_verticalInput == 0) return;

        if (_verticalInput < 0)
        {
            playerRigidbody.MoveRotation(playerRigidbody.rotation + _horizontalInput * rotateSpeed * Time.fixedDeltaTime);
        }
        else
        {
            playerRigidbody.MoveRotation(playerRigidbody.rotation - _horizontalInput * rotateSpeed * Time.fixedDeltaTime);
        }
    }

    private void HandleParticle(float _verticalInput)
    {
        if (_verticalInput > 0)
        {
            if (!forwardFx.isPlaying)
            {
                forwardFx.Play();
            }
        }
        else
        {
            if (forwardFx.isPlaying)
            {
                forwardFx.Stop();
            }
        }

        if (_verticalInput < 0)
        {
            if (!backwardFx.isPlaying)
            {
                backwardFx.Play();
            }
        }
        else
        {
            if (backwardFx.isPlaying)
            {
                backwardFx.Stop();
            }
        }
    }
}

