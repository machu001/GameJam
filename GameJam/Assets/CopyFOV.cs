using UnityEngine;

public class CopyFOV : MonoBehaviour
{
    public Camera cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Camera>().fieldOfView = cam.fieldOfView;
    }
}
