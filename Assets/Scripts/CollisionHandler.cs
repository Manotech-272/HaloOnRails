using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("sec")][SerializeField] float loadGameDelay = 1;
    [Tooltip("FX explosion on Hornet")][SerializeField] GameObject deathExplosion;
    
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathExplosion.SetActive(true);
        ChangeMeshToDestroyed();
        Invoke("LoadGame",loadGameDelay);
    }

    private void ChangeMeshToDestroyed()
    {
        Transform shipMeshes = transform.Find("ShipParts");

        shipMeshes.Find("gun_l_destroyed1").gameObject.SetActive(true);
        shipMeshes.Find("gun_r_destroyed1").gameObject.SetActive(true);
        shipMeshes.Find("hull_destroyed1").gameObject.SetActive(true);
        shipMeshes.Find("jet_l_destroyed1").gameObject.SetActive(true);
        shipMeshes.Find("jet_r_destroyed1").gameObject.SetActive(true);
        shipMeshes.Find("skid_l_destroyed1").gameObject.SetActive(true);
        shipMeshes.Find("skid_r_destroyed1").gameObject.SetActive(true);
        shipMeshes.Find("tail_destroyed1").gameObject.SetActive(true);


        shipMeshes.Find("gun_l_default1").gameObject.SetActive(false);
        shipMeshes.Find("gun_r_default1").gameObject.SetActive(false);
        shipMeshes.Find("hull_default1").gameObject.SetActive(false);
        shipMeshes.Find("jet_l_default1").gameObject.SetActive(false);
        shipMeshes.Find("jet_r_default1").gameObject.SetActive(false);
        shipMeshes.Find("skid_l_default1").gameObject.SetActive(false);
        shipMeshes.Find("skid_r_default1").gameObject.SetActive(false);
        shipMeshes.Find("tail_default1").gameObject.SetActive(false);
        
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Game1");
    }
}
