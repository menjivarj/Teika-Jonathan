using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject background;
    private GameObject[] backgrounds;
    public float pivotPoint;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backgrounds = new GameObject[3];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float pos = pivotPoint - (pivotPoint / 2 * i);
            backgrounds[i] = Instantiate(background, new Vector2(pos, pos), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].transform.position += new Vector3(Time.deltaTime * speed, Time.deltaTime * speed, 0);
            if (backgrounds[i].transform.position.x > ((-1 * pivotPoint) / 2))
            {
                backgrounds[i].transform.position = new Vector3(pivotPoint, pivotPoint, 0);
            }
        }
    }
}
