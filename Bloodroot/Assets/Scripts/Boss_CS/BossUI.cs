using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    public GameObject bossCanvas;
    public BossTrigger bossTrigger;
    public GameObject bossSpawn;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bossCanvas.SetActive(true);
            bossTrigger.SpawnBoss();
           
        }
    }
}
