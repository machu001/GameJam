using UnityEngine;
using System.Collections.Generic;
public class DestructibleObjectManager : MonoBehaviour
{
    public static DestructibleObjectManager instance;

    public List<GameObject> destructibles = new();
    public GameObject destructiblesContainer;
    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        int i = 0;
        while (i < destructiblesContainer.transform.childCount)
        {
            destructibles.Add(destructiblesContainer.transform.GetChild(i).gameObject);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
