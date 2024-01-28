using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Play Death Sound
            StartCoroutine(WaitToQuit());
        }
    }

    private IEnumerator WaitToQuit()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}