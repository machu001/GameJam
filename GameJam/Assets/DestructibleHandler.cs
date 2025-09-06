using UnityEngine;

public class DestructibleHandler : MonoBehaviour
{
    
    public GameObject DestructibleObj;
    public GameObject SwappedPrefab;
    public bool canMove;
    public bool canDestroy;
    float moveTimer;
    float moveCD;


    public float despawnTime = 5f;
    float despawnTimer;
    public bool countdown = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        despawnTimer = despawnTime;

        moveTimer = Random.Range(1, 25);
        moveCD = moveTimer;
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

        if (canMove)
        {
            moveCD -= Time.deltaTime;
            if (moveCD < 0)
            {
                MoveObject();
                moveCD = 3;
            }
        }
    }

    public void SwapPrefabs()
    {
        if (!canDestroy) return;
        Transform savedPos = DestructibleObj.transform;
        Instantiate(SwappedPrefab, savedPos.position, savedPos.rotation, savedPos.parent);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().GlassBreak();
        DestructibleObjectManager.instance.destructibles.Remove(gameObject);
        countdown = true;
        Destroy(DestructibleObj);
    }

    public void MoveObject()
    {
        Vector3 RandomVector = new Vector3(Random.Range(-50, 50f), Random.Range(-50, 50f), Random.Range(-50, 50f));
        if (DestructibleObj == null) return;
        if(DestructibleObj.TryGetComponent(out Rigidbody rb))
        {
            Debug.Log("ruszono obiekt");
            rb.AddForce(RandomVector);
        }
    }
}
