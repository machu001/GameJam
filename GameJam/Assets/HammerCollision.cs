using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    public float despawnTime = 3f;
    bool countdown = false;
    float despawnTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        despawnTimer = despawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown) despawnTimer -= Time.deltaTime;
        if( despawnTimer <= 0 ) Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go != null)
        {
            if(go.CompareTag("Destructible"))
            {
                if (collision.gameObject.TryGetComponent<DestructibleHandler>(out DestructibleHandler t))
                {
                    Debug.Log("Znalaz³o komponent");
                    if(t.canDestroy) t.SwapPrefabs();
                }
              
            }
            countdown = true;
        }
    }

}
