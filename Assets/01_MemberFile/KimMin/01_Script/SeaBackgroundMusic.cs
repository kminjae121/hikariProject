using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaBackgroundMusic : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.ChangeMainStageVolume("SeaStageSound", true, ISOund.BGM);
    }
}
