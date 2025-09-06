using UnityEngine;

public class DestroyMap : MonoBehaviour
{
    public static DestroyMap Instance;
    public GameObject map;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyTheMap()
    {
        Destroy(map);
    }
}
