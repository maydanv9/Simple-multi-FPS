using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneReferences : BaseView
{
    [SerializeField] private GameObject gameTerrain;
    public GameObject GameTerrain { get { return gameTerrain; } }

    [SerializeField] private GameObject menuTerrain;
    public GameObject MenuTerrain { get { return menuTerrain; } }

    [SerializeField] private GameObject examineRoom;
    public GameObject ExamineRoom { get { return examineRoom; } }
}
