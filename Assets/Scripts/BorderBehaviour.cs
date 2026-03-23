using UnityEngine;
using TMPro;

public class BorderBehaviour : MonoBehaviour
{
    public float timeout;
    private float timeStart;
    public GameObject gameOver;
    public TMP_Text timerText;
    private int sweetsOnBorder = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sweet"))
        {
            if (sweetsOnBorder == 0)
            {
                timeStart = Time.time;
                timerText.SetText("5.0s");
            }
            sweetsOnBorder++;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        float timer = timeout + (timeStart - Time.time);
        timerText.SetText(System.MathF.Round(timer, 2).ToString() + "s");
        other.GetComponent<Rigidbody2D>().WakeUp();
        if (other.gameObject.CompareTag("Sweet") && timer <= 0)
        {
            gameOver.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().GameOver();
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        sweetsOnBorder--;
        if (sweetsOnBorder == 0)
        {
            timerText.SetText("");
        }
    }

}
