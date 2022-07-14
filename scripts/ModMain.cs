
using System;
using System.Collections;
using HutongGames.PlayMaker;
using HKTool;
using HKTool.FSM;

namespace GGBossMusicMod;

class GGBossMusic : ModBase<GGBossMusic>
{
    public override string DisplayName => "GG Boss Music Controller";

    [FsmPatcher(false, objName: "_SceneManager")]
    private static void FsmSceneManager(PlayMakerFSM pm)
    {
        if(!pm.gameObject.scene.name.StartsWith("GG_")) return;
        var initState = pm.Fsm.GetState("Init");
        if(initState == null) return;
        var ggcheck = initState.GetFSMStateActionOnState<GGCheckIfBossSequence>();
        if(ggcheck == null) return;
        ggcheck.trueEvent = FsmEvent.GetFsmEvent("CANCEL");
        pm.Fsm.SetState("Init");
    }
}

