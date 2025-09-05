using Unity.VisualScripting;
using UnityEngine;

public class HammerThrow : MonoBehaviour
{
    public GameObject HammerPrefab;
    public Transform ThrowPos;

    public float hammerSpeed;

    public float throwCD;
    float currCD;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (currCD <= 0)
            {
                ThrowHammer();
            }

           
        }

        if(currCD > 0) currCD -= Time.deltaTime;
    }

    void ThrowHammer()
    {
        GameObject thrownObj = Instantiate(HammerPrefab, ThrowPos);
        thrownObj.transform.parent = null;
        currCD = throwCD;
        Rigidbody hammerRB = thrownObj.GetComponent<Rigidbody>();
        hammerRB.linearVelocity = transform.forward * hammerSpeed;
    }

}
