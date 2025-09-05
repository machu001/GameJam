using UnityEngine;

public class DestructibleHandler : MonoBehaviour
{
    
    public GameObject DestructibleObj;
    public GameObject SwappedPrefab;

    public float despawnTime = 5f;
    float despawnTimer;
    bool countdown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        despawnTimer = despawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown) 
        { 
            despawnTimer -= Time.deltaTime;
        }
        if (despawnTimer < 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void SwapPrefabs()
    {
        Transform savedPos = DestructibleObj.transform;
        Instantiate(SwappedPrefab, savedPos.position, savedPos.rotation, savedPos.parent);
        
        countdown = true;
        Destroy(DestructibleObj);
    }
}
