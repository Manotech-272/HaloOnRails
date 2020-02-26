using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int scoreValue = 500;

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    
    void Start()
    {
        AddNonTriggerBoxCollider();
        
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider col = gameObject.AddComponent<BoxCollider>();
        col.isTrigger = false;
    }

    
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject FX = Instantiate(deathFX, transform.position, Quaternion.identity);
        FX.transform.parent = parent;
        ScoreBoard.instance.ScoreHit(scoreValue);
        Destroy(gameObject);
        
    }

    
}
