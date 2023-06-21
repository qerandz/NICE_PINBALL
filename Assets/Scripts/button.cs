using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    [SerializeField] public Text bestscore;
    [SerializeField] public GameObject start;
    private void Update()
    {
        if (ClawController.instance.sty)
        {
            StartCoroutine(hideh());
        }
    }
    private void Start()
    {
        bestscore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        
    }
    IEnumerator hideh()
    {
        
        yield return new WaitForSeconds(0f);
        start.SetActive(false);
    }
    
}
