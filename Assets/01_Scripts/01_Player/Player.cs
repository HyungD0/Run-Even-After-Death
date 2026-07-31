using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerDieSelfActions
{
    #region 변수
    [SerializeField] private GameObject DeadPrefab;
    [SerializeField] private Transform resetPoint;

    private InputSystem_Actions inputActions;
    #endregion

    private void Awake()
    {
        
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.PlayerDieSelf.SetCallbacks(this);
        inputActions.PlayerDieSelf.Enable();
    }

    private void OnDisable()
    {
        inputActions.PlayerDieSelf.Disable();
    }

    public void OnDie(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Die();
        }
    }

    [ContextMenu("죽음 테스트")]
    private void Die()
    {
        Instantiate(DeadPrefab, transform.position, Quaternion.identity);
        Respawn();
    }

    private void Respawn()
    {
        transform.position = resetPoint.position;
    }
}