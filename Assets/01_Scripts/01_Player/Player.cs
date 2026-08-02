using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerDieSelfActions
{
    #region 변수
    [SerializeField] private GameObject DeadPrefab;
    [SerializeField] private Transform resetPoint;

    private InputSystem_Actions inputActions;

    private bool isDiePressed = false;
    [Header("연死 설정")]
    [SerializeField] private float repeatRate = 0.1f;
    #endregion

    private void Awake()
    {
        
        inputActions = new InputSystem_Actions();
    }

    private void Update()
    {
        if (isDiePressed)
        {
            Die();
        }
    }

    private void OnEnable()
    {
        inputActions.PlayerDieSelf.SetCallbacks(this);
        inputActions.PlayerDieSelf.Enable();
    }

    private void OnDisable()
    {
        inputActions.PlayerDieSelf.Disable();
        CancelInvoke(nameof(Die));
    }

    public void OnDie(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            CancelInvoke(nameof(Die));

            InvokeRepeating(nameof(Die), 0f, repeatRate);
        }
        else if (context.canceled)
        {
            CancelInvoke(nameof(Die));
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
        Instantiate(DeadPrefab, transform.position - new Vector3(0, 1, 0), Quaternion.identity);
        Respawn();
    }

    private void Respawn()
    {
        transform.position = resetPoint.position;
    }
}