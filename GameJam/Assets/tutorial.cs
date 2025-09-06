using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject tutor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Tutorialwylacz", 30f);
    }

    void Tutorialwylacz()
    {
        tutor.SetActive(false);
    }
}
