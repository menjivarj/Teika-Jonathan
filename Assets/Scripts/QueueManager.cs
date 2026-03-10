using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public Sprite[] UISprites;
    public int[] queue;
    private SpriteRenderer[] childRenderers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        childRenderers = new SpriteRenderer[transform.childCount];
        for (int i = 0; i < childRenderers.Length; i++)
        {
            childRenderers[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
        queue = new int[childRenderers.Length];
        for (int i = 0; i < childRenderers.Length; i++) { 
            queue[i] = Random.Range(0, childRenderers.Length);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            childRenderers[i].sprite = UISprites[queue[i]];
        }
    }

    public int updateQueue()
    {
        int returnType = queue[0];
        for (int i = 1; i < queue.Length; i++)
        {
            queue[i - 1] = queue[i];
        }
        queue[queue.Length - 1] = Random.Range(0, childRenderers.Length);
        return returnType;
    }
}
