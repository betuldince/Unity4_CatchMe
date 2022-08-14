using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float speed;
    private GameObject focalP;
    private bool isPoweredUp = false;
    private float powerUpStrength=15f;
    public GameObject indicator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalP = GameObject.Find("focalPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(vertical * speed * focalP.transform.forward);
        indicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && isPoweredUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 oppositeD = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(oppositeD * powerUpStrength, ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "PowerUp") {
            Destroy(collision.gameObject);
            isPoweredUp = true;
            indicator.SetActive(true);
            StartCoroutine(countDown(7));
        }
    }

    IEnumerator countDown(float secs)
    {
        yield return new WaitForSeconds(secs);
        isPoweredUp = false;
        indicator.SetActive(false);
    }
}
