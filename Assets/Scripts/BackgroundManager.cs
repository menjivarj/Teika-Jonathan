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
            Vector2 position = new Vector2(pos, pos);
            backgrounds[i] = Instantiate(background, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
