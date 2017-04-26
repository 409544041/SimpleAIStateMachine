/*===============================================================
Product:    Utilities
Developer:  Dimitry Pixeye - pixeye@hbrew.store
Company:    Homebrew - http://hbrew.store
Date:       26/04/2017 10:55
================================================================*/
using UnityEngine;
using System.Collections.Generic;
namespace Homebrew{

public abstract class BasicAI<T> : MonoBehaviour {


        [System.Serializable]
        public abstract class AIState
        {
            protected T AI;
            public string ID;
            public AIState(T AI)
            {
                this.AI = AI;
            }

            /// <summary>
            ///  Logic loop. The action itself goes here
            /// </summary>
            public abstract void Update();
            /// <summary>
            /// Checks if we need to kill the current state
            /// </summary>
            /// <returns></returns>
            public abstract bool EndStateCondition();
            /// <summary>
            /// Use to reset some variables / set next state or set state to null
            /// </summary>
            public abstract void End();
            /// <summary>
            /// Some initial setups or actions that happen ONCE when the state becomes active.
            /// </summary>
            public virtual void Start() { }

        }


        public List<AIState> states = new List<AIState>();
        public AIState currentState;


        public void SwitchToState(string ID)
        {
         var state = states.Find(s => s.ID == ID);
            currentState = state;
            if (currentState != null)
                currentState.Start();
        }

        protected virtual void Update()
        {

            if (currentState != null)
            {

                if (currentState.EndStateCondition())
                {
                    currentState.End();

                    return;
                }

                currentState.Update();
 
            }

        }

}
}
