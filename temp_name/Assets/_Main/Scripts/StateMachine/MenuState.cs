using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuState : BaseState, IMenuView, IMovement
{

    private InputController.InputValues inputs;

    public override void InitState(GameController gameController)
    {
        base.InitState(gameController);
        gameController.UIController.MenuView.listener = this;
        gameController.UIController.MenuView.ShowView();
        gameController.WebController.Client.Init(gameController);
        //this.gameController.SceneReferences.MenuTerrain.SetActive(true);
    }

    public override void UpdateState(GameController gameController)
    {
        //this.gameController.MovementController.MovementUpdate(inputs);
    }

    public override void DeinitState(GameController gameController)
    {
        base.DeinitState(gameController);
        gameController.UIController.MenuView.listener = null;
        gameController.UIController.MenuView.HideView();
        //this.gameController.SceneReferences.MenuTerrain.SetActive(false);
    }

    public void SetGameState()
    {
        gameController.ChangeState(new GameState());
    }

    #region INTERFACES
    public void UpdateAxis(InputController.InputValues inputValues)
    {
        inputs = inputValues;
    }
    #endregion
}
