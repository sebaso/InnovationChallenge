using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimes : MonoBehaviour
{
    public GameObject player;
    public float speed;

    void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(MoveOverSpeed(gameObject, player.transform.position, speed));
    }

    void Update()
    {

    }

  public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
 
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Boop");
            other.gameObject.GetComponent<FPSShoot>().life--;
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Proj")
        {
            Destroy(gameObject);
        }
    }
}
