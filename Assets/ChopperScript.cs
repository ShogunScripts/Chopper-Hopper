using UnityEngine;

public class ChopperScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool isChopperSafe = true;
    public float deadZoneUp = 26;
    public float deadZoneDown = -26;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isChopperSafe)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        if(transform.position.y >= deadZoneUp || transform.position.y <= deadZoneDown)
        {
            logic.gameOver();
            Debug.Log("Game Over");
            Destroy(gameObject);
            Debug.Log("Chopper Deleted");
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isChopperSafe = false;
    }
}
