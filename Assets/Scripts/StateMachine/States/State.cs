using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{

    public Action[] actions;
    public Transition[] transitions;

    public Color GizmoColor;
    public Skill skill;
    public string type;

    public void UpdateState(StateMachine state_machine)
    {
        DoActions(state_machine);
        CheckTransitions(state_machine);
    }

    private void DoActions(StateMachine state_machine)
    {
        for (int i=0; i<actions.Length; i++)
        {
            actions[i].Act(state_machine);
        }
    }


    private void CheckTransitions(StateMachine state_machine)
    {
        for (int i=0; i<transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(state_machine);

            if (decisionSucceeded)
            {
                state_machine.TransitionToState(transitions[i].trueState);
            }
            else
            {
                state_machine.TransitionToState(transitions[i].falseState);
            }
        }
    }
    
}
