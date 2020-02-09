using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneReferences : BaseView
{
    [SerializeField] private GameObject gameTerrain;
    public GameObject GameTerrain => gameTerrain;
}
