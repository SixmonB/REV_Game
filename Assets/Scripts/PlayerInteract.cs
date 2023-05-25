using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    private InputManager input;
    [SerializeField] public UnityEvent<int> onHit;

    private int score = 0;

    public AudioClip gunShotSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponent<PlayerLook>().cam;
        input = GetComponent<InputManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // variable storing collision information
        if(input.onFoot.Shoot.triggered)
        {
            if (audioSource != null && gunShotSound != null)
            {
                Debug.Log("gunshot");
                audioSource.PlayOneShot(gunShotSound);
            }
            if(Physics.Raycast(ray, out hitInfo, distance, mask))
            {     
                if(hitInfo.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                    interactable.BaseInteract();
                    onHitTriggered();
                }
                
            }
        }
    }

    public void onHitTriggered()
    {
        score++;
        onHit.Invoke(score);
    }
}
