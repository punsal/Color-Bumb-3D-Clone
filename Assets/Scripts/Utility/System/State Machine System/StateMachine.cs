using UnityEngine;
using Utility.System.State_Machine_System.Data;

/*
 * Use this script with care. It has only one functionality
 * TODO: Finish extended capabilities of this basic StateMachine
 */

namespace Utility.System.State_Machine_System
{
    public class StateMachine : MonoBehaviour
    {
        [Header("Debug")] [SerializeField] private State currentState;
#pragma warning disable 414
        // ReSharper disable once RedundantDefaultMemberInitializer
        [SerializeField] private int startingIndex = 0;
#pragma warning restore 414

        [Header("Internal")]
#pragma warning disable 649
        [SerializeField]
        private State[] states;
#pragma warning restore 649

        public void NextState()
        {
            foreach (var state in states)
            {
                if (state.currentGameState != currentState.nextGameState) continue;
                currentState = state;

                currentState.onStateEvent.Invoke();
                break;
            }
        }
        
        public void ResetState()
        {
            currentState = states[0];
            currentState.onStateEvent.Invoke();
        }
    }
}