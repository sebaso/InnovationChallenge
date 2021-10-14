using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public GameObject impactVFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Proj")
        {
            GameObject impact = Instantiate(impactVFX, transform.position, Quaternion.identity);
            Destroy(impact, 2);
            Destroy(gameObject);
        }
        
    }
}
