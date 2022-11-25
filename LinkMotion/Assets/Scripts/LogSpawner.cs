using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class LogSpawner : MonoBehaviour
{
    public static LogSpawner Instance;
    [SerializeField] private Transform _logPrefab;
    private int cap = 5;
    private bool grabTimer;
    
    private void Awake(){
        if(Instance == null) Instance = this;
        else Destroy(gameObject);

        grabTimer = true;
    }

    private void Update(){
        if(GameObject.FindGameObjectsWithTag("Log").Length < cap){
            Instantiate(_logPrefab, transform.position, Quaternion.Euler(new Vector3(0-90, 0, 0)));
        }
    }

    private void OnTriggerExit(Collider other){
        Debug.Log("Exiting");
        //int length = GameObject.FindGameObjectsWithTag("Log").Length;
        //if(length > cap) return;
        
    }
}
