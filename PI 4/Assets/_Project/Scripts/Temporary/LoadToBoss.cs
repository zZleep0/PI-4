using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadToBoss : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void LoadToBossAfterFade()
    {
        levelLoader.LoadLevel("BossDay1");
    }
}
