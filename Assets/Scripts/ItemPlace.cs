using System.Collections;
using UnityEngine;

namespace miniit.MERGE
{
    public class ItemPlace : ConvertablePlace<DeadItem>, IDelayableAction
    {
        [SerializeField] float delayTimeInSeconds = 5f;
        private IEnumerator delayCoroutine = null;

        public override StoringObject StoringObject
        {
            get => storingObject;
            set
            {
                Debug.Log(storingObject + " is prev! " + value + " is now!");
                if(delayCoroutine is not null)
                {
                    StopDoingAction();
                }

                storingObject = value;
                if (value is not null)
                {
                    storingObject.Place = this;
                    AnchorItem();
                    if (storingObject is not DeadItem)
                    {
                        BeginDoingAction();
                    }
                    else
                    {
                        Debug.Log("It is DeadItem!");
                    }
                }
            }
        }

        #region IDelayableAction implementation

        public void BeginDoingAction()
        {
            delayCoroutine = DoActionAfterTime(delayTimeInSeconds);
            Debug.Log("Converting " + storingObject + " after " + delayTimeInSeconds + "sec!");
            StartCoroutine(delayCoroutine);
        }

        public void StopDoingAction()
        {
            Debug.Log("Stop converting!");
            StopCoroutine(delayCoroutine);
        }

        public IEnumerator DoActionAfterTime(float delayTimeInSeconds)
        {
            yield return new WaitForSeconds(delayTimeInSeconds);
            Debug.Log("Converting!");
            ConvertObject();
        }

        #endregion
    }
}