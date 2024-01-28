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

    // Update is called once per frame
    void Update()
    {

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
}