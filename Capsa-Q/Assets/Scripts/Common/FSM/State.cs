using UnityEngine;
using System;

namespace FSM
{   
    public abstract class State : ScriptableObject, IUpdateable {
        public delegate void EndStateCallback(State endingState, Transition withTransition);
        private event EndStateCallback onEndCallback;

        [SerializeField] protected Transition[] transitionList;

        public void OnUpdate() {
            DoUpdateAction();

            int transitionIndex = CheckTransition();
            if (transitionIndex >= 0) {
                if (onEndCallback != null)
                    onEndCallback(this, transitionList[transitionIndex]);
            }
        }

        public void SetEndCallback(EndStateCallback callback) {
            onEndCallback = callback;
        }

        public void ClearEndCallback() {
            onEndCallback = null;
        }

        //Should be called to setup the state. Should try to check for sanity of the properties.
        public abstract void Setup(object properties);
        public abstract void CleanUp();

        protected abstract void DoUpdateAction();

        //Should return -1 on not transitioning, 0 or more if transitioning to another state
        protected abstract int CheckTransition(); 
    }
}