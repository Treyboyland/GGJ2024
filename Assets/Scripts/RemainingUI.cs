using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RemainingUI : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text textBox;

    [SerializeField]
    string completeText;

    List<Collectible> allCollectibles;

    // Start is called before the first frame update
    void Start()
    {
        allCollectibles = FindObjectsOfType<Collectible>().ToList();
        UpdateText();
    }

    public void UpdateText()
    {
        int collected = allCollectibles.Where(x => !x.gameObject.activeInHierarchy).Count();
        if (collected != allCollectibles.Count)
        {
            textBox.text = collected + "/" + allCollectibles.Count;
        }
        else
        {
            textBox.text = completeText;
        }
    }

    public bool HasAll()
    {
        return allCollectibles.Where(x => x.gameObject.activeInHierarchy).Count() == 0;
    }

    public bool HasAny()
    {
        return allCollectibles.Where(x => !x.gameObject.activeInHierarchy).Count() != 0;
    }

    public void FailStress()
    {
        textBox.text = "Too stressed. Backspace to try again.";
    }

    public void FailVibe()
    {
        textBox.text = "Failed the vibe check. Backspace to try again.";
    }
}
