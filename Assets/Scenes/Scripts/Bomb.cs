using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] private float Speed;
    [SerializeField] GameObject particle;
    [SerializeField] AudioClip clip;
    void Update ()
    {
        rb.AddForce(rb.transform.forward * Speed);
        Destroy(gameObject , 1f);
    }
       public void OnTriggerEnter (Collider hitInfo)
    {
       Enemy enemy = hitInfo.GetComponent<Enemy>();
       if (enemy != null)
       {
        Instantiate(particle, transform.position, transform.rotation);
        enemy.DieOnCollison();
        SoundManager.Instance.PlaySound(clip);
        hitInfo.attachedRigidbody.useGravity = true;
       }
       Missile missile = hitInfo.GetComponent<Missile>();
        if (missile != null)
       {
         Instantiate(particle, transform.position, transform.rotation);
       }

       Destroy(gameObject);
       
    }
}
