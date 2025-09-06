using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public float destroyRange;
    bool canDrop = true;

    public float hitCD = 0.5f;
    float hitTimer;

    public PlayerCam mouseLookScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitTimer -= Time.deltaTime;
        if(Input.GetMouseButton(0))
        {
            animator.SetInteger("HammerState", 1);
            
            if (hitTimer < 0)
            {
                
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, destroyRange))
                {
                    Debug.Log(hit.transform.gameObject);
                    if(hit.transform.gameObject.CompareTag("Destructible"))
                    {
                        if(hit.transform.gameObject.TryGetComponent<DestructibleInfo>(out DestructibleInfo di))
                        {
                            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("HammerHit");
                            di.dh.SwapPrefabs();
                        }
                        else 
                        {
                            Debug.Log("nie znalaz³o");
                        }
                        hitTimer = hitCD;
                    }   
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            animator.SetInteger("HammerState", 0);
        }
        
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
