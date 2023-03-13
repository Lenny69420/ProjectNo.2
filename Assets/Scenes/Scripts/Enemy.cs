using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("STATS")]
    [SerializeField] private float Speed;
    [SerializeField] private int minReloadTime;
    [SerializeField] private int maxReloadTime;
    [SerializeField] private float homingTime;
    [SerializeField] private float rotationSpeed;

    [Header("GAMEOBJECT")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private Missile Missile;  
    [SerializeField] private ParticleSystem Death;
    [SerializeField] AudioClip collisionClip;
    [SerializeField] AudioClip clip;

    private bool timerIsRunning = false;
    private bool CanShoot;
    private bool StartShoot;
    private GameObject targetDecoy;

    private Transform target;
    private Vector3 direction;
    void Start()
    {
     targetDecoy = GameObject.Find("Decoy");
     if(targetDecoy != null)
     {
        target = GameObject.Find("Decoy").transform;
     }
     timerIsRunning = true;
     CanShoot = true;
     StartCoroutine(WaitTillShoot());
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        if (targetDecoy != null)
        {
            Timer();
            if(timerIsRunning != false)
            {
            direction = target.position - transform.position;
            direction = direction.normalized;
            var rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
            }
        }
        if(StartShoot == true)
       {
        if ( targetDecoy != null ) {Shoot();}
       }       
    }
    void Shoot ()
    {
        if (CanShoot == true)
        {   
            Missile newMissile = Instantiate(Missile, firePoint.position, Quaternion.identity);
            CanShoot = false;
            StartCoroutine(Reload());
        }
    }

    public void DieOnCollison()
    {
        Speed = 1f;  
        Destroy(gameObject,3f);
        SoundManager.Instance.PlaySound(collisionClip);
    }
    void Timer()
    {
        if (timerIsRunning)
        {
            if (homingTime > 0)
            {
                homingTime -= Time.deltaTime;
            }
            else
            {
                homingTime = 0;
                timerIsRunning = false;
            }
    }
   }
     public void OnTriggerEnter(Collider hitInfo)
     {
       Enemy enemy = hitInfo.GetComponent<Enemy>();
       Bomb bomb = hitInfo.GetComponent<Bomb>();
       if (enemy != null || bomb != null)
       { 
        if(bomb != null) {SoundManager.Instance.PlaySound(clip);}
        else SoundManager.Instance.PlaySound(collisionClip);
        Instantiate(Death,transform.position,Quaternion.identity);
        Speed = 0.25f;
        hitInfo.attachedRigidbody.useGravity = true;
        Destroy(gameObject,4f);
       }  
     }
     IEnumerator Reload()
    {
        int rand = Random.Range(minReloadTime, maxReloadTime);
        yield return new WaitForSeconds(rand);
        CanShoot = true;
     }
     IEnumerator WaitTillShoot()
     {
        yield return new WaitForSeconds (0.8f);
        StartShoot = true;
     }
}