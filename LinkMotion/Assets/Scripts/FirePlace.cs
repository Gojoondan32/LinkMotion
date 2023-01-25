using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlace : MonoBehaviour
{
    public static FirePlace Instance;
    [SerializeField] private List<Log> _logList; 
    [SerializeField] private Transform[] _firePlaceMarkers;
    [SerializeField] private GameObject[] _fireParticles;
    private void Awake(){
        if(Instance == null) Instance = this;
        else Destroy(gameObject);

        _logList = new List<Log>();
    }

    private void Update(){
        
    }

    //Check the boundries of the fireplace to determine if a log is present
    public bool LogInFireplace(Vector3 position){
        if(position.x > _firePlaceMarkers[0].position.x && position.x < _firePlaceMarkers[1].position.x)
            if(position.z > _firePlaceMarkers[0].position.z && position.z < _firePlaceMarkers[1].position.z)
                return true;
        return false;
    }

    public void IncreaseSizeOfFire(Log log){
        _logList.Add(log);
        Debug.Log("IN FIRE");
        int maxActiveParticles = _logList.Count > 5 ? 5 : _logList.Count; //Create a cap to prevent an index out of range error
        for(int i = 0; i < maxActiveParticles; i++){
            _fireParticles[i].SetActive(true);
        }
        
    }
    public void DecreaseSizeOfFire(Log log){
        _logList.Remove(log);
        foreach(GameObject fire in _fireParticles)
            fire.SetActive(false); //Needed to ensure the correct amount of fire particles are being shown

        int maxActiveParticles = _logList.Count > 5 ? 5 : _logList.Count; //Create a cap to prevent an index out of range error
        for(int i = 0; i < maxActiveParticles; i++){
            _fireParticles[i].SetActive(true);
        }
    }
    
}
