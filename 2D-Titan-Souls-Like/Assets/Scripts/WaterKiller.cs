using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class WaterKiller : MonoBehaviour
{
    public GameObject particle;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(particle, collision.gameObject.transform.position, Quaternion.Euler(-90,0,0));

            collision.gameObject.transform.parent.GetComponentInChildren<Light2D>().gameObject.transform.parent = null;
            StartCoroutine(Reset());

            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("main");
    }
}
