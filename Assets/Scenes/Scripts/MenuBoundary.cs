using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBoundary : MonoBehaviour
{
[SerializeField] private GameObject Player;
void OnTriggerEnter(Collider hitInfo)
  {
     if (hitInfo.gameObject.tag == "Bound1")
     {
        transform.position = new Vector3(-35f,transform.position.y,transform.position.z);
     }
     if (hitInfo.gameObject.tag == "Bound2")
     {
        transform.position = new Vector3(35f,transform.position.y,transform.position.z);
     }
     if (hitInfo.gameObject.tag == "Bound3")
     {
        transform.position = new Vector3(transform.position.x,transform.position.y,-60f);
     }
     if (hitInfo.gameObject.tag == "Bound4")
     {
        transform.position = new Vector3(transform.position.x,transform.position.y,40f);  
     }

  }
}
