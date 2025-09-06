using UnityEngine;

public class DestructibleObjectManager : MonoBehaviour
{
    public static DestructibleObjectManager instance;

    public GameObject[] destructibles;
    public GameObject destructiblesContainer;
    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        int i = 0;
        while (i < destructiblesContainer.transform.childCount)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
