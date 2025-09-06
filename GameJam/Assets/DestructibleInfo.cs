using System.Collections;
using UnityEngine;

public class DestructibleInfo : MonoBehaviour
{
    public DestructibleHandler dh;
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
        if(collision.gameObject.CompareTag("Hammer"))
        {
            StartCoroutine(SwapPrefabs());
        }
    }

    public IEnumerator SwapPrefabs()
    {
        yield return new WaitForSeconds(0.0666f);

        dh.SwapPrefabs();
    }
}
