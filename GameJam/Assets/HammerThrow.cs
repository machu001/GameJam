using Unity.VisualScripting;
using UnityEngine;

public class HammerThrow : MonoBehaviour
{
    public Camera cam;
    public GameObject HammerPrefab;
    public Transform ThrowPos;

    public float hammerSpeed;

    float holdTime = 0;

    public float throwCD;
    float currCD;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            if (currCD >= 0)
            {
                holdTime -= Time.deltaTime;
                if (holdTime > 0.25f) cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 50, 0.01f);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (currCD >= 0)
            {
                currCD -= Time.deltaTime;
                return;
            }
            if (holdTime > 0.25f) ThrowHammer(hammerSpeed * holdTime * 2);
            else ThrowHammer(hammerSpeed);
            holdTime = 0;
            cam.fieldOfView = 75;
        }
        if (currCD > 0) currCD -= Time.deltaTime;
    }

    void ThrowHammer(float speed)
    {
        GameObject thrownObj = Instantiate(HammerPrefab, ThrowPos);
        thrownObj.transform.parent = null;
        currCD = throwCD;
        Rigidbody hammerRB = thrownObj.GetComponent<Rigidbody>();
        hammerRB.linearVelocity = transform.forward * speed;
    }

}
