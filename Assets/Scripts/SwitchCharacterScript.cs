using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour
{
    public GameObject[] avatars;
    private int whichAvatarIsOn = 0;

    void Start()
    {
        ActivateAvatar(0);
    }

    public void NextAvatar()
    {
        ActivateAvatar((whichAvatarIsOn + 1) % avatars.Length);
    }

    private void ActivateAvatar(int aIndex)
    {
        whichAvatarIsOn = aIndex;
        for (int i = 0; i < avatars.Length; i++)
            avatars[i].SetActive(i == aIndex);
    }
}