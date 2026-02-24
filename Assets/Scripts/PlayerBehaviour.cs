using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    public float limit;
    public GameObject[] sweets;
    private GameObject sweetHeld;
    public float offY;
    private int move;
    public float dropDelay;
    private float lastDropTime;

    public int[] points;
    public int total;
    public TMP_Text textField;
    public AudioClip dropSound;
    public AudioClip mergeSound;
    private bool gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        move = 0; // Can move both left and right on move = 0
        total = 0; // Set point total to 0
        gameOver = false;
    }

    // Update is called once per frame
    void Update() {

        if (gameOver)
        {
            return;
        }

        // Moves sweet held by player along with the player
        Vector3 playerPos = transform.position;
        if (sweetHeld != null){
            Vector3 sweetOffset = new Vector3(0.0f, offY, 0.0f);
            sweetHeld.transform.position = playerPos + sweetOffset;
        } else { // Creates sweet for player to hold if there is none held
            sweetHeld = Instantiate(sweets[GameObject.FindGameObjectWithTag("Queue").GetComponent<QueueManager>().updateQueue()], playerPos, Quaternion.identity);
        }

        Keyboard k = Keyboard.current;

        // Dropping sweetHeld
        if (k.spaceKey.wasPressedThisFrame && (Time.time - lastDropTime) > dropDelay){
            Rigidbody2D body = sweetHeld.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;

            Collider2D collider = sweetHeld.GetComponent<Collider2D>();
            collider.enabled = true;

            sweetHeld = null;
            lastDropTime = Time.time;
            GetComponent<AudioSource>().PlayOneShot(dropSound);
        }

        // Keyboard player movement
        float offset = 0.0f;
        if ((k.aKey.isPressed || k.leftArrowKey.isPressed) && move != 1) {
            offset = -speed;
        }
        if ((k.dKey.isPressed || k.rightArrowKey.isPressed) && move != -1) {
            offset = speed;
        }
        Vector3 newPos = transform.position;
        if (!((newPos.x + offset) > limit || (newPos.x + offset) < (-1 * limit))) {
            newPos.x = newPos.x + offset;
        }
        transform.position = newPos;
    }

    public void updateScore (int index)
    {
        total += points[index];
        textField.SetText("Score:\n" +  total);
        GetComponent<AudioSource>().PlayOneShot(mergeSound);
    }

    public void GameOver()
    {
        gameOver = true;
    }

}
