using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    private static float CurrentTopYPosition = -5.0f;
    private static double CurrentPlatformX = -3.0f;
    private static bool GeneratePlatform = false;
    private System.Random random = new System.Random();
    public List<GameObject> platformList = new List<GameObject>();
    private Vector3 currentPlatformPosition = new Vector3();

    public GameObject platformPrefab;
    public GameObject groundPrefab;

    // Start is called before the first frame update
    void Start()
    {
                          platformList.Add(groundPrefab);
        while (CurrentTopYPosition < 4.8)
        {
            GenerateRandomPlatform();

            if (GeneratePlatform)
            {
                createPlatform();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        moveAllPlatforms();
        //CurrentTopYPosition -= 0.5f;
        while (CurrentTopYPosition < 4.8)
        {
            GenerateRandomPlatform();
            if (GeneratePlatform)
            {
                createPlatform();
            }
        }

    }
    private void moveAllPlatforms()
    {
        foreach (GameObject platform in platformList)
        {
            if (platform.transform.position.y < -5.0f)
            {
                Destroy(platform);
                platformList.Remove(platform);
            }
            else
            {
                currentPlatformPosition = platform.transform.position;
                platform.transform.position.Set(currentPlatformPosition.x, currentPlatformPosition.y - 0.5f, currentPlatformPosition.z);
            }
        }
        //CurrentTopYPosition -= 0.5f;

    }

    private void createPlatform()
    {
        GeneratePlatform = false;
        CurrentPlatformX = random.NextDouble() * (6.7f) - 3.0f; //min and max bounds for x hardcoded to generate random starting position for platforms
        platformList.Add((GameObject) Instantiate(platformPrefab, new Vector3((float)CurrentPlatformX, CurrentTopYPosition, 0.0f), Quaternion.identity));
    }

    public static void GenerateRandomPlatform()
    {
        CurrentTopYPosition += 2.0f;
        CurrentPlatformX += 0.7f;
        GeneratePlatform = true;
    }
}
