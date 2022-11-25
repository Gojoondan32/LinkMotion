using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    
    private Vector3 _startPos;
    private bool _startBurning;
    private bool _pickedUp;
    private void Awake(){
        _startBurning = false;
        _pickedUp = false;
        Destroy(gameObject, 20f);
    }
    public void Update(){
        if(!_startBurning && FirePlace.Instance.LogInFireplace(transform.position)){
            _startBurning = true;
            Debug.Log("Start Burning");
            StartCoroutine(BurningTime());
        }
    }
    private IEnumerator BurningTime(){
        float currentTime = 0f;
        FirePlace.Instance.IncreaseSizeOfFire(this);
        while(currentTime < _maxTime){
            currentTime += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Log has burnt out");
        FirePlace.Instance.DecreaseSizeOfFire(this);
        Destroy(gameObject);
    }
}
