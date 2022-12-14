using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int posNum;
    float[] positions = new float[] { -4.7f, -0.2f, 4.3f };
    public float speed;
    public float switchSpeed;
    public Rigidbody2D rb;
    public PlayerControls playerControls;

    private Vector2 screenBounds;
    

    // Start is called before the first frame update
    void Awake()
    {
        posNum = 1;

        playerControls = new PlayerControls();
        //playerControls.Player.Enable();
        //playerControls.Player.Movement.performed += Movement;
        playerControls.PlayerAlt.Enable();
        playerControls.PlayerAlt.Horizontal.performed += LaneSwitch;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    private void Movement(InputAction.CallbackContext context)
    {
        //Debug.Log(context);

        //rb.MovePosition(rb.position + context.ReadValue<Vector2>() * 3 * Time.fixedDeltaTime);
    }

    private void LaneSwitch(InputAction.CallbackContext context)
    {
        //Debug.Log(context);

        if(context.ReadValue<float>() > 0)
        {

            if(posNum >= 2)
            {
                return;
            }

            posNum++;
        } else if (posNum > 0)
        {
            posNum--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.RightArrow) && posNum != 2)
        {
            posNum++;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && posNum != 0)
        {
            posNum--;
        }*/

        //Move();

        //Vector2 inputVector = playerControls.Player.Movement.ReadValue<Vector2>();
        //rb.MovePosition(rb.position + inputVector * speed * Time.fixedDeltaTime);

        Vector2 pos = new Vector2(positions[posNum], rb.position.y + playerControls.PlayerAlt.Vertical.ReadValue<float>());
        rb.position = Vector2.Lerp(rb.position, pos, Time.deltaTime * switchSpeed);
    }

    void LateUpdate()
    {
        Vector2 viewPos = rb.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1, screenBounds.x * 1);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y * 1);
        rb.position = viewPos;
    }

    private void Move()
    {
        //Vector2 newPos = Vector2.Lerp(rb.position, new Vector2(rb.position.x, positions[posNum]), Time.deltaTime * speed);
        //Vector2 newPos = new Vector2(rb.position.x, positions[posNum]);

        //rb.MovePosition(newPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Candy")
        {
            Spawner.score += collision.GetComponent<Candy>().scoreValue;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Dead!");
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        //playerControls.Player.Movement.performed -= Movement;
        playerControls.PlayerAlt.Disable();

        FindObjectOfType<Spawner>().Die();

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
