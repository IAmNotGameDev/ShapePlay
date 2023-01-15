using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdScript : MonoBehaviour
{

    public string gameId = "4122755";
    public string surfacingId = "Banner_Android";
    public bool testMode = false;

    void Start()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(surfacingId);
    }
}