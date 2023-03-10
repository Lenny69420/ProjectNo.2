using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject traget;
    [SerializeField] private GameObject enemy;
    [SerializeField] private RectTransform panelTransform;
    [SerializeField] private int minTime;
    [SerializeField] private int maxTime;  
    [SerializeField] private int depth;  

    void Start()
    {
        traget = GameObject.Find("Decoy");
        StartCoroutine(spawnEnemies());
    }
    IEnumerator spawnEnemies()
    {
        int spawnRand = Random.Range(minTime,maxTime);
        yield return new WaitForSeconds (spawnRand);
        Vector3 newEnemy = spawningCord();
        Instantiate(enemy, newEnemy ,Quaternion.identity);
        if(traget != null){StartCoroutine(spawnEnemies());}
        else {StopCoroutine(spawnEnemies());}
    }
    Vector3 spawningCord()
    {
        Vector3 top_right = panelTransform.TransformPoint(new Vector2(panelTransform.rect.xMax, panelTransform.rect.yMax));
        Vector3 top_left = panelTransform.TransformPoint(new Vector2(panelTransform.rect.xMin, panelTransform.rect.yMax));
        Vector3 bottom_right = panelTransform.TransformPoint(new Vector2(panelTransform.rect.xMax, panelTransform.rect.yMin));
        Vector3 bottom_left = panelTransform.TransformPoint(new Vector2(panelTransform.rect.xMin, panelTransform.rect.yMin));

        Vector3 top_right_world = Camera.main.ScreenToWorldPoint(top_right);
        Vector3 top_left_world = Camera.main.ScreenToWorldPoint(top_left);
        Vector3 bottom_right_world = Camera.main.ScreenToWorldPoint(bottom_right);
        Vector3 bottom_left_world = Camera.main.ScreenToWorldPoint(bottom_left);
        
        int rand = Random.Range(0, 5);
        if (rand == 1)
        {
           //Debug.Log("1");
        return new Vector3(Random.Range(top_right_world.x,top_left_world.x), depth, Random.Range(top_right_world.z,top_left_world.z)); //x 35 -35 y -40 -45
        }
        else if ( rand == 2)
        {
            //Debug.Log("2");
        return new Vector3(Random.Range(bottom_right_world.x,bottom_left_world.x), depth, Random.Range(bottom_right_world.z,bottom_left_world.z));// x 35 -35 y 40 45
        }
        else if( rand == 3)
        {
            //Debug.Log("3");
        return new Vector3(Random.Range(top_right_world.x, bottom_right_world.x),depth, Random.Range(top_right_world.z, bottom_right_world.z));// x -30 -35 y 40 -40 
        }
        else if ( rand == 4)
        {
            //Debug.Log("4");
        return new Vector3(Random.Range(bottom_left_world.x,top_left_world.x), depth, Random.Range(bottom_left_world.z,top_left_world.z));// x 35 -35 y 40 45        
        }
        else
        {
            //Debug.Log("0");
        return new Vector3(Random.Range(bottom_left_world.x,top_left_world.x), depth, Random.Range(bottom_left_world.z,top_left_world.z));// x 35 -35 y 40 45
        }
    
    }

}
