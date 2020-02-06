using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState {

    protected GameController gameController;

    public virtual void InitState(GameController gameController)
    {
        this.gameController = gameController;
    }

    public virtual void UpdateState(GameController gameController) { }

    public virtual void DeinitState(GameController gameController) { }

}
