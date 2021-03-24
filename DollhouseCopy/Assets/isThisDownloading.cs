using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isThisDownloading : MonoBehaviour
{
    public static bool isDownloading = false;

    public static int itemsToDownload = 0;

    public static int itemsDownloaded = 0;

    public GameObject LoadingObject;

    public static Text loadingtext;

    private void Start()
    {
        loadingtext = LoadingObject.GetComponentInChildren(typeof(Text)) as Text;
    }


    public static void ChangeText()
    {
        
        loadingtext.text = "loaded " + itemsDownloaded + " of " + itemsToDownload + " items...";
    }

}
