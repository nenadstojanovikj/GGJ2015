﻿using UnityEngine;
using System.Collections;

public class Conducter : MonoBehaviour {

    public AudioClip[] sounds;
    static DiveFPSController dive;

    void Start()
    {
        dive = GameObject.FindObjectOfType<DiveFPSController>();
        StartCoroutine(IERandomSounds());

    }

    private IEnumerator IERandomSounds()
    {
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        while (true)
        {
            AudioSource.PlayClipAtPoint(sounds[Random.Range(0, sounds.Length)], transform.position);
            yield return new WaitForSeconds(Random.Range(3f, 6f));
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPostition = new Vector3(dive.transform.position.x,
                                       this.transform.position.y,
                                       dive.transform.position.z);
        this.transform.LookAt(targetPostition);
        this.transform.rotation = Quaternion.Euler(270, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

    }

}
