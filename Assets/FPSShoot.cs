using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR.Cardboard;

public class FPSShoot : MonoBehaviour
{
    public GameObject proj;
    public float projectileSpeed = 30f;
    public Camera cam;
    private Vector3 destination;
    public Transform LHFirepoint, RHFirepoint;
    private bool leftHand;
    public int life = 3;
    public  float arcRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0)
        {
            Debug.Log("Perdiste");
        }
        if (Api.IsTriggerPressed || Input.GetKeyDown(KeyCode.A))
        {
            ShootProjectile();
        }
       
    }
    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
  
        }
        else
            destination = ray.GetPoint(1000);
        if (leftHand)
        {
            leftHand = false;
            CreateProj(LHFirepoint);
        }
        else
        {
            CreateProj(RHFirepoint);
            leftHand = true;
        }

    }
    void CreateProj(Transform firepoint)
    {
        GameObject projectileObj = Instantiate(proj, firepoint.position, Quaternion.identity) ;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firepoint.position).normalized * projectileSpeed;
        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange),0), Random.Range(0.5f,2f));
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
}
    