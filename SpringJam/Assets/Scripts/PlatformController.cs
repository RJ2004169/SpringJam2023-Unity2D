using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    private const float platformMovementSpeed = -5f;

    private static float CurrentTopYPosition = -5.0f;
    private static double CurrentPlatformX = -3.0f;
    //private static bool GeneratePlatform = false;
    private System.Random random = new System.Random();
    public List<GameObject> platformList = new List<GameObject>();
    private Rigidbody2D currentPlatformPosition = new Rigidbody2D();

    public GameObject platformPrefab;
    public GameObject groundPrefab;

    // Start is called before the first frame update
    void Start()
    {
        platformList.Add(groundPrefab);
        while (CurrentTopYPosition < 4.8)
        {
            GenerateRandomPlatform();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //moveAllPlatforms();           MOVED TO FIXEDUPDATE()
        //while (CurrentTopYPosition < 4.8)
        //{
        //    GenerateRandomPlatform();

        //}

    }

    private void FixedUpdate()
    {
        moveAllPlatforms();
        while (CurrentTopYPosition < 4.8)
        {
            GenerateRandomPlatform();

        }
    }
    private void moveAllPlatforms()
    {
        for (int i = 0; i<platformList.Count; i++)//GameObject platform in platformList)
        {
            if (platformList[i] != null)
            {
                if (platformList[i].transform.position.y < -5.0f)
                {
                    //platformList.Remove(platformList[i]);
                    Destroy(platformList[i]);
                    platformList.RemoveAll(s => s == null);
                    
                }
                else
                {
                    currentPlatformPosition = platformList[i].GetComponent<Rigidbody2D>();
                    currentPlatformPosition.MovePosition((Vector2)platformList[i].transform.position + new Vector2(0.0f, platformMovementSpeed) * Time.deltaTime);
                    //platform.transform.position.Set(currentPlatformPosition.x, currentPlatformPosition.y - 0.5f, currentPlatformPosition.z);
                }
            }
        }
        CurrentTopYPosition = platformList[platformList.Count-1].transform.position.y;

    }

    public void GenerateRandomPlatform()
    {
        CurrentTopYPosition += 4.0f;
        CurrentPlatformX = random.NextDouble() * (6.7f) - 3.0f; //min and max bounds for x hardcoded to generate random starting position for platforms
        platformList.Add((GameObject)Instantiate(platformPrefab, new Vector3((float)CurrentPlatformX, CurrentTopYPosition, 0.0f), Quaternion.identity));
    }
}
