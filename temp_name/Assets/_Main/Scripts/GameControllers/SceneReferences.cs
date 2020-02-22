using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReferences : BaseView
{
    [SerializeField] private Transform playersTransform;
    public Transform PlayersTransform => playersTransform;
}
