using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public ParticleSystem JumpVFX;

    public static VFXManager _instance;
    public static VFXManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<VFXManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("VFXManager");
                    _instance = container.AddComponent<VFXManager>();
                }
            }

            return _instance;
        }
    }

    public void PlayJumpVFX()
    {
        JumpVFX.Play();
    }
}
