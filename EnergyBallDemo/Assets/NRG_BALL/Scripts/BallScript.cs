using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
struct Floater {
    public Transform transform;
    public float freq;
    public float phase;
    public float amplitude;
}

public class BallScript : MonoBehaviour {
    [SerializeField] float rotationSpeed = 1f;

    [SerializeField] List<Floater> floaters;

    void Start() {
        
    }

    void Update() {
        transform.Rotate(Vector3.up, (360 / rotationSpeed) * Time.deltaTime);

        float T;
        Floater floater;

        for (int i = 0; i < floaters.Count; i++) {
            floater = floaters[i];
            T = (Time.timeSinceLevelLoad + floater.phase) * floater.freq;
            floater.transform.position = new Vector3(
                floater.transform.position.x,
                Mathf.Sin(T) * floater.amplitude,
                floater.transform.position.z
            );
        }
    }
}
