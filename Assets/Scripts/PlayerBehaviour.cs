using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed;
    public GameObject[] sweets;
    private GameObject sweetHeld;
    public float offY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
    }

    // Update is called once per frame
    void Update() {

        if (sweetHeld != null){
            Vector3 playerPos = transform.position;
            Vector3 sweetOffset = new Vector3(0.0f, offY, 0.0f);
            sweetHeld.transform.position = playerPos + sweetOffset;
        } else {
            sweetHeld = Instantiate(sweets[Random.Range(0, 5)], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }

            Keyboard k = Keyboard.current;

        if (k.spaceKey.wasPressedThisFrame){
            Rigidbody2D body = sweetHeld.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;

            Collider2D collider = sweetHeld.GetComponent<Collider2D>();
            collider.enabled = true;

            sweetHeld = null;
        }

        if (k.aKey.isPressed || k.leftArrowKey.isPressed) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed;
            transform.position = newPos;
        }
        if (k.dKey.isPressed || k.rightArrowKey.isPressed) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed;
            transform.position = newPos;
        }

    }
}
