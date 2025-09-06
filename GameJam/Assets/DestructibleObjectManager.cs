using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class DestructibleObjectManager : MonoBehaviour
{
    public static DestructibleObjectManager instance;
    bool check = false;
    public List<GameObject> destructibles = new();
    public GameObject destructiblesContainer;
    public DialogueScript ds;

    public FadeScript lowTaperFade;
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
        if(destructibles.Count == 0)
        {
            Debug.Log("You win!");
            if(!check) StartCoroutine(NextLevel());
            check = true;
            
        }
    }

    IEnumerator NextLevel()
    {
        
        lowTaperFade.FadeOut();

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            ds.StartCoroutine(ds.TypeLine(1));
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            ds.StartCoroutine(ds.TypeLine(1));
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            ds.StartCoroutine(ds.TypeLine(0));
            DestroyMap.Instance.DestroyTheMap();
            yield return new WaitForSeconds(15);

            ds.StartCoroutine(ds.TypeLine(1));
            yield return new WaitForSeconds(10);
        }

        yield return new WaitForSeconds(10);
        yield return new WaitForSeconds(10);
        if(SceneManager.GetActiveScene().buildIndex < 3) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(0);
    }
}
