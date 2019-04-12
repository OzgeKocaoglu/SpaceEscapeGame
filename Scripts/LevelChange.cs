using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {


    public Transform effectFab;
    public float effectdelay = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player giriş yaptı");
            Instantiate(effectFab, effectFab.position, effectFab.rotation);
            Destroy(collision.gameObject);
            Debug.Log("İkinci sahne yükleniyor");
            StartCoroutine(Timer());
            
            

        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(effectdelay);
        SceneManager.LoadScene("Shop");

    }

}
