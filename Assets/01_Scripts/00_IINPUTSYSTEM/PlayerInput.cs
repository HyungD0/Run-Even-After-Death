using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput {  get; private set; }
    public bool JumpInputPressed { get; private set; }
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        JumpInputPressed = Input.GetButtonDown("Jump");
    }
}
