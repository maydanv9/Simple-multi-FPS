using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState, IGameView, IMovement
{

    private InputController.InputValues inputs;

    public override void InitState(GameController gameController)
    {
        base.InitState(gameController);
        #region LISTENERS
        this.gameController.UIController.GameView.listener = this;
        this.gameController.InputController.movementlistener = this;
        #endregion 
        this.gameController.UIController.GameView.ShowView();
        this.gameController.SceneReferences.GameTerrain.SetActive(true);
        this.gameController.MovementController.Init(gameController);
    }

    public override void UpdateState(GameController gameController)
    {
        gameController.InputController.InputUpdate();
        gameController.MovementController.MovementUpdate(inputs);
    }

    public override void DeinitState(GameController gameController)
    {
        base.DeinitState(gameController);
        #region LISTENERS
        this.gameController.UIController.GameView.listener = this;
        this.gameController.InputController.movementlistener = this;
        #endregion 
        this.gameController.UIController.GameView.HideView();
        this.gameController.SceneReferences.MenuTerrain.SetActive(false);
    }

    public void SetMenuState()
    {
        gameController.ChangeState(new MenuState());

    }

    #region INTERFACES
    public void UpdateAxis(InputController.InputValues inputValues)
    {
        inputs = inputValues;
    }
    #endregion
}
