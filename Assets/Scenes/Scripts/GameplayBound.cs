using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayBound : MonoBehaviour
{
  void OnTriggerEnter(Collider hitInfo)
  {
    Flying fly = hitInfo.GetComponent<Flying>();
    if (fly != null)
    {
        fly.Die();
    }
    if (hitInfo.gameObject.tag == "Missile")
    {
        Destroy(hitInfo.gameObject);
    }
  }
}
