using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Interactable
{
    public GameObject PS_explosion;
    private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        promptMessage = "Destroyed";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        explosion = Instantiate(PS_explosion, transform.position, Quaternion.identity);
        explosion.transform.parent = transform.parent;
        //Debug.Log("Destroyed " + gameObject.name);
        Destroy(gameObject);
    }
}