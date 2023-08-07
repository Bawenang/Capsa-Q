using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{

    public abstract class StateController : MonoBehaviour
    {
        public enum RunningState
        {
            NOT_STARTED,
            RUNNING,
            FINISHED
        }
        private enum ControllerType
        {
            NONE,
            FSM_STATE,
            FSM_TRANSITION
        }
        [SerializeField] protected State startingState;
        [SerializeField] protected bool startImmediately = true;
        protected RunningState runningState = RunningState.NOT_STARTED;

        private IUpdateable currentUpdateable = null;

        private ControllerType activeType = ControllerType.NONE;

        // Start is called before the first frame update
        virtual public void Start()
        {
            if (startImmediately && startingState != null)
            {
                runningState = RunningState.RUNNING;
                Activate(startingState);
            }
        }

        // Update is called once per frame
        virtual public void Update()
        {
            if (currentUpdateable != null)
            {
                currentUpdateable.OnUpdate();
            }
        }

        public virtual void StartManually(State startingState = null)
        {
            State startState = (startingState == null) ? this.startingState : startingState;
            if (runningState != RunningState.RUNNING && startState != null)
            {
                runningState = RunningState.RUNNING;
                this.startingState = startState;
                OnStartedManually();
                Activate(startState);
            }
        }

        virtual protected void OnStartedManually()
        {

        }

        private void Activate(State state)
        {
            if (runningState == RunningState.RUNNING)
            {
                activeType = ControllerType.FSM_STATE;
                state.SetEndCallback(EndState);
                OnActivateState(state);
                currentUpdateable = state;
            }
        }

        private void Activate(Transition transition)
        {
            if (runningState == RunningState.RUNNING)
            {
                activeType = ControllerType.FSM_TRANSITION;
                transition.SetEndCallback(EndTransition);
                OnActivateTransition(transition);
                currentUpdateable = transition;
                transition.OnEnter();
            }
        }

        protected void EndState(State endingState, Transition withTransition)
        {
            if (runningState == RunningState.RUNNING)
            {
                endingState.ClearEndCallback();
                endingState.CleanUp();
                withTransition.fromState = endingState;
                OnEndStateCallback(withTransition);
                Activate(withTransition);
            }
        }

        protected void EndTransition(Transition endingTransition, State toState)
        {
            if (runningState == RunningState.RUNNING)
            {
                endingTransition.ClearEndCallback();
                endingTransition.CleanUp();
                if (toState != null)
                {
                    OnEndTransitionCallback(toState);
                    Activate(toState);
                }
            }
        }


        protected abstract void OnActivateState(State state);
        protected abstract void OnActivateTransition(Transition transition);
        protected abstract void OnEndStateCallback(Transition withTransition);
        protected abstract void OnEndTransitionCallback(State toState);
    }

}
