using System.Drawing.Drawing2D;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    PlayerInput playerInput;
    InputAction moveAction;
    InputAction dashAction;
    [SerializeField] float speed = 5;
    [SerializeField] float dashSpeed = 20f;

    bool isDashing = false;
    float dashTimeRemaining = 0f;
    Vector3 dashDirection;
    [SerializeField] float dashDuration = 0.2f;

    Color cubeColor;

    Renderer rend;

    public Color GetCurrentPanelColor()
    {
        return cubeColor;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rend =  GetComponent<Renderer>();
        moveAction = playerInput.actions.FindAction("Move");
        dashAction = playerInput.actions.FindAction("Dash");


        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDashing)
        {
            MovePlayer();

            if (dashAction.triggered)
            {
                Vector2 direction = moveAction.ReadValue<Vector2>();
                if (direction.magnitude > 0)
                {
                    dashDirection = transform.TransformDirection(new Vector3(direction.x, 0f, direction.y).normalized);

                   // dashDirection = new Vector3(direction.x, 0f, direction.y).normalized;
                    isDashing = true;
                    dashTimeRemaining = dashDuration;
                }
            }
        }
        else
        {
            float dashStep = dashSpeed * Time.deltaTime;
            transform.position += dashDirection * dashStep;
            dashTimeRemaining -= Time.deltaTime;

            if (dashTimeRemaining <= 0)
            {
                isDashing = false;
            }
        } 
    }
    void MovePlayer()
    {
       // Debug.Log(moveAction.ReadValue<Vector2>());

        Vector2 direction = moveAction.ReadValue<Vector2>();

        Vector3 move = new Vector3(direction.x, 0f, direction.y);
        transform.position += transform.TransformDirection(move) * speed * Time.deltaTime;

       // transform.position += new Vector3(direction.x, 0f, direction.y) * speed * Time.deltaTime;

    }

    void Dash()
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        Vector3 dashDirection = new Vector3(direction.x, 0f, direction.y).normalized;
        transform.position += dashDirection * dashSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.name == "Cube")
        {

            rend = collision.gameObject.GetComponent<Renderer>();
            cubeColor =  rend.material.color;
        }
        

    }
    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

}
