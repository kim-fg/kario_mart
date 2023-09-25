using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace KarioMart
{
    public class Inititalizer : MonoBehaviour
    {
        [SerializeField] private AssetReference startupScene;

        private void Start()
        {
            startupScene.LoadSceneAsync();
        }
    }
}
