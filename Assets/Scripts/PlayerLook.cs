using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    private PlayerControll _controls;
    private Vector2 _lookInput;
    public float sensitivity = 1f;

    private void Awake()
    {
        _controls = new PlayerControll();

        _controls.Gameplay.Look.performed += ctx => _lookInput = ctx.ReadValue<Vector2>();
        _controls.Gameplay.Look.canceled += ctx => _lookInput = Vector2.zero;
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Update()
    {
        float mouseX = _lookInput.x * sensitivity;
        float mouseY = _lookInput.y * sensitivity;

        // Rotate horizontally (Y-axis)
        transform.Rotate(Vector3.up * mouseX);

        // For vertical look (pitch), you would rotate the camera separately here.
    }
}
