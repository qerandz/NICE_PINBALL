using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class los : MonoBehaviour
{
    [SerializeField] public GameObject loss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            loss.SetActive(true);
            StartCoroutine(restart());
        }   
        
    }
    IEnumerator restart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SampleScene");
    }
    
}
