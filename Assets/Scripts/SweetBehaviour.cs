using UnityEngine;

public class SweetBehaviour : MonoBehaviour
{
    //public float timeout;
    //private float timeStart;

    public GameObject[] sweets;
    public int sweetType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sweets = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().sweets;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 otherPos = other.transform.position;
        if (other.gameObject.CompareTag("Sweet") && (other.gameObject.GetComponent<SweetBehaviour>().sweetType == sweetType) && (sweetType < sweets.Length - 1) && (gameObject.transform.position.x < otherPos.x || (gameObject.transform.position.x == otherPos.x && gameObject.transform.position.y >= otherPos.y)))
        {
            //Create merged sweet
            GameObject current = Instantiate(sweets[sweetType + 1], Vector3.Lerp(gameObject.transform.position, otherPos, 0.5f), Quaternion.identity);
            current.GetComponent<Collider2D>().enabled = true;
            current.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

            //Update score
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().updateScore(sweetType);

            //Destroy both sweets
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }



    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("TopBorder"))
    //    {
    //        timeStart = Time.time;
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("TopBorder") && (Time.time - timeStart) > timeout)
    //    {
    //        print("Game Over");
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("TopBorder"))
    //    {
    //        timeStart = 0.0f;
    //    }
    //}

}
