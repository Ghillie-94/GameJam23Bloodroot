using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    
    public GameObject boss;
     
    public void SpawnBoss()
    {

        boss.SetActive(true);
        
    }
}
