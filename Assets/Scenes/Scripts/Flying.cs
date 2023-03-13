using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
[Header ("Speed")]
[SerializeField] private float Fly_Speed;
[SerializeField] private float Yaw_Ammount;
[SerializeField] private float Roll_Angle;

[Header("BOMBING")]    
[SerializeField] GameObject Bullets;
[SerializeField] private Transform firePoint;
[SerializeField] private float fireRate;
    
[Header("GAMEOBJECT")]

[SerializeField] private ParticleSystem Death;
[SerializeField] private GameObject RetryMenu;
[SerializeField] AudioClip clip;
private float Yaw;
private float GiveAxis;
private float nextFire;
private float timer;
void Awake ()
{
    Input.multiTouchEnabled = false;
}
private void Start()
{
}
void Update()
{
    Fly_Movement();
}
public void Move_Right()
{
    GiveAxis = 0.25f;
}
public void Move_Left()
{
    GiveAxis = -0.25f;
}
public void Neutral()
{
    GiveAxis = 0;
}
public void Drop()
{
    Shoot();
}
void Fly_Movement ()
{
    transform.position += transform.forward * Fly_Speed * Time.deltaTime;
    float horizontalInput = GiveAxis;
    Yaw += horizontalInput * Yaw_Ammount * Time.deltaTime;
    float roll = Mathf.Lerp(0, Roll_Angle, Mathf.Abs (horizontalInput)) * -Mathf.Sign(horizontalInput);
    transform.localRotation = Quaternion.Euler (Vector3.up * Yaw + Vector3.forward *roll); 
}
private void Shoot () 
{
    if (Time.time > nextFire )
    {
        nextFire = Time.time + fireRate;
        Instantiate(Bullets, firePoint.position, firePoint.rotation);
    }       
}
public void Die()
{
    SoundManager.Instance.PlaySound(clip);
    Destroy(this.gameObject);
    Instantiate(Death,transform.position,Quaternion.identity);
    RetryMenu.SetActive(true);
}
}
