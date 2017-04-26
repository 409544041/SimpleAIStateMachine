/*===============================================================
Product:    Battlecruiser
Developer:  Dimitry Pixeye - pixeye@hbrew.store
Company:    Homebrew - http://hbrew.store
Date:       26/04/2017 11:02
================================================================*/

/*===============================================================
Example realisation

================================================================*/

using System;
using UnityEngine;
using DG.Tweening;

namespace Homebrew{

	public class SalvageDroneAI : BasicAI<SalvageDroneAI> {

        public Transform model;

        public Transform targetRef;


        #region STATES
        public class LeaveBase : AIState
        {

            bool leftTheBase = false;

            public LeaveBase(SalvageDroneAI ai): base(ai)
            {
                ID = "LeaveBase";
            }

            /// <summary>
            /// Reseting values
            /// </summary>
            public override void End()
            {
                leftTheBase = false;
                AI.SwitchToState("FlyToTarget");
            }

            public override bool EndStateCondition()
            {

                return leftTheBase;
            }

            public override void Update()
            {
               
            }

            public override void Start()
            {
                Debug.Log("Leaving my parent ship. Goodbye!");
                leftTheBase=true;

           
            }


        }
      
        public class FlyToTarget : AIState
        {



            public FlyToTarget(SalvageDroneAI ai): base(ai)
            {
                ID = "FlyToTarget";
            }

            public override void End()
            {
                throw new NotImplementedException();
            }

            public override bool EndStateCondition()
            {
                return false;
            }

            public override void Update()
            {
               
            }

            public override void Start()
            {

                //AI.TargetRef
                if (AI.targetRef==null)
                Debug.Log("I'm on my way! To...err where am I going?!");
                else
                Debug.Log("I'm on my way to the " + AI.targetRef.name);
            }

        }


        #endregion


        protected override void Create()
        {
            base.Create();

            states.Add(new LeaveBase(this));
            states.Add(new FlyToTarget(this));

        }

      


        private void OnEnable()
        {
            SwitchToState("LeaveBase");
            
        }

        private void OnDisable()
        {

        }


    }
}
