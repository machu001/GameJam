using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject DialogueBox;
    public string[] lines;
    public float textSpeed;
    private int index;
    bool check = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;

        Invoke("StartDialogue", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (textComponent.text == lines[index] && !check)
        {
            StartCoroutine(NextLine());
            check = true;
        }
    }


    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        check = false;
    }

    IEnumerator NextLine()
    {
        Debug.Log("Log");
        if (index < lines.Length - 1)
        {
            yield return new WaitForSeconds(3);
            textComponent.text = string.Empty;
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            DialogueBox.SetActive(false);
           
        }
    }
}
