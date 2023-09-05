using UnityEngine;
using System;

namespace FSM
{
    public abstract class Transition : ScriptableObject, IUpdateable {
        public delegate void EndTransitionCallback(Transition endingTransition, State toState);
        private event EndTransitionCallback onEndCallback;

        [HideInInspector] public State fromState;
        [SerializeField] protected State endState;
        [SerializeField] protected float timeout;

        public void Start() 
        {
            OnEnter();
        }

        public void OnUpdate() 
        {
            RunUpdate();
            if (!CheckTransitionFinished()) {
                return;
            }
                
            End();
            if (onEndCallback != null)
                onEndCallback(this, endState);
        }

        public void SetEndCallback(EndTransitionCallback callback) 
        {
            onEndCallback = callback;
        }

        public void ClearEndCallback() 
        {
            onEndCallback = null;
        }

        public virtual void RunUpdate() { }

        public abstract void Setup(object properties);
        public abstract void CleanUp();

        protected abstract bool CheckTransitionFinished();
        public abstract void OnEnter();
        public abstract void OnExit();

        private void End() 
        {
            OnExit();
        }
    }
}