using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollhouseUpstairsWallsDownloaded : MonoBehaviour
{
    public bool wallsDownloaded;

    void Start()
    {
        wallsDownloaded = WallsDownloaded.dollUpWallsDownloaded;
    }

}
