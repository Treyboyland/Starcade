using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetParticleUI : MonoBehaviour
{
    [SerializeField]
    FactionTypeSO faction = null;

    [SerializeField]
    SceneLoader gameScene = null;

    private void OnMouseDown()
    {
        //TODO: This is where we would bring up the UI to attack, assist, or ally with this faction...but that might take a while
        if (gameScene != null)
        {
            gameScene.LoadSceneAsyncSingle();
        }

    }
}
