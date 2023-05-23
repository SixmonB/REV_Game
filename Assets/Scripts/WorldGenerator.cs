using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldGenerator : MonoBehaviour
{
    public GameObject target;
    private GameObject targetInstance;

    public AudioClip spawnSound;
    private AudioSource audioSource;
    private Color objectColor = Color.red;
    private float spawnSize = 30f;
    private float spawnTimer = 0f;
    public float spawnInterval = 2f;

    public GameObject playerPrefab;
    private GameObject player;

    public PlayerInteract playerinteract;

    public GameObject canvas;
    private GameObject canvasInstance;
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Awake()
    {
        Vector3 spawnPosition = new Vector3(0f,1.05f,0f); 
        player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        audioSource = GetComponent<AudioSource>();
        playerinteract = player.GetComponent<PlayerInteract>();
        playerinteract.onHit.AddListener(HandleScoreIncrease);
        canvasInstance = Instantiate(canvas, Vector3.zero, Quaternion.identity);
        Transform child = canvasInstance.transform.Find("ScoreText");
        scoreText = child.GetComponent<TextMeshProUGUI>();
        Debug.Log("text " + scoreText.text);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnInterval)
        {
            DestroyPrevious();
            SpawnObject();
            spawnTimer = 0f;
        }
    }

    private void SpawnObject()
    {
         Vector3 spawnPosition = transform.position + new Vector3(
            Random.Range(-spawnSize / 2f, spawnSize / 2f),
            Random.Range(1f, 3f),
            Random.Range(-spawnSize / 2f, spawnSize / 2f)
        );
        targetInstance = Instantiate(target, spawnPosition, Quaternion.identity);
        Renderer renderer = targetInstance.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material material = renderer.material;
            material.color = objectColor;
        }
        if (audioSource != null && spawnSound != null)
        {
            audioSource.PlayOneShot(spawnSound);
        }
    }

    private void DestroyPrevious()
    {
        if(targetInstance != null)
        {
            Destroy(targetInstance);
        }
    }

    public void HandleScoreIncrease(int score)
    {
        // Process the score information received from the player
        Debug.Log("Score increased: " + score);
        scoreText.text = "Score: " + score.ToString();
    }
}
