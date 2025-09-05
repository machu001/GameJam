using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject player;
    GameObject clickedObj;
    public float destroyRange;
    bool canDrop = true;

    public PlayerCam mouseLookScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("klika sie");
            if (clickedObj == null)
            {
                Debug.Log("RaycastCheck");
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, destroyRange))
                {
                    Debug.Log("Raycast dzia³a");
                    if(hit.transform.gameObject.CompareTag("Destructible"))
                    {
                        clickedObj = hit.transform.gameObject;
                        Destroy(clickedObj);
                    }   
                }
            }
        }
    }

    void StopClipping()
    {
        var clipRange = Vector3.Distance(clickedObj.transform.position, transform.position);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);

        if (hits.Length > 1)
        {
            clickedObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
        }
     
    }
}
