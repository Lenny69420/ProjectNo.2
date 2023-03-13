using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
Transform target;
Vector3 direction;
private bool timerIsRunning = false;
private GameObject target_Check;
private int damage;
public float homing_Time;
[SerializeField] private float Speed;
[SerializeField] private float rotaion_Speed;
[SerializeField] private ParticleSystem Explosion;
[SerializeField] AudioClip clip;
void Start ()
{
    timerIsRunning = true;
    target_Check = GameObject.Find("Plane");
    if(target_Check != null)
    {
        target = GameObject.Find("Plane").transform;
    }
}
void Update()
{
    transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    if (target != null )
    {
        Timer();
        if(timerIsRunning != false)
        {
            direction = target.position - transform.position;
            direction = direction.normalized;
            var rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotaion_Speed * Time.deltaTime);
        }
    }
}
void Timer()
{
        if(timerIsRunning)
    {
        if (homing_Time > 0)
        {
            homing_Time -= Time.deltaTime;
        } else 
        {
            homing_Time = 0;
            timerIsRunning = false;
        }
    }
}
public void OnTriggerEnter (Collider hitInfo)
{
    Flying plane = hitInfo.GetComponent<Flying>();
    if (plane != null) 
    {
        plane.Die();
        Instantiate(Explosion, transform.position, transform.rotation);
    }
    Missile missile = hitInfo.GetComponent<Missile>();
    Bomb bomb = hitInfo.GetComponent<Bomb>();
    if (missile != null || bomb != null)
    {
        SoundManager.Instance.PlaySound(clip);
        Instantiate(Explosion, transform.position, transform.rotation);
    }
    Destroy(gameObject);
}
}
