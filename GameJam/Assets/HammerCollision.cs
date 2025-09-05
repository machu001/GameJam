using UnityEngine;

public class HammerCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go != null)
        {
            if(go.CompareTag("Destructible"))
            {
                Destroy(go);
                
            }
            Destroy(gameObject);
        }
    }

}
