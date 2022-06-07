using Doozy.Runtime.Signals;
using System.Collections;
using UnityEngine;

namespace miniit.MERGE
{
    public class ItemPlace : ConvertablePlace<DeadItem>, IDelayableAction
    {
        [Tooltip("StreamCategory of signal OnDeadItemCreated.")]
        [SerializeField] private string MusicEvents = nameof(MusicEvents);

        [Tooltip("StreamCategory of signal OnDeadItemCreated.")]
        [SerializeField] private string OnDeadItemCreated = nameof(OnDeadItemCreated);
        [SerializeField] float delayTimeInSeconds = 5f;
        private IEnumerator delayCoroutine = null;

        public override StoringObject StoringObject
        {
            get => storingObject;
            set
            {
                if (delayCoroutine is not null)
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
                        SignalStream.Get(MusicEvents, OnDeadItemCreated).SendSignal();
                        Debug.Log("It is DeadItem!");
                    }
                }
            }
        }

        #region IDelayableAction implementation

        public void BeginDoingAction()
        {
            delayCoroutine = DoActionAfterTime(delayTimeInSeconds);
            StartCoroutine(delayCoroutine);
        }

        public void StopDoingAction()
        {
            StopCoroutine(delayCoroutine);
        }

        public IEnumerator DoActionAfterTime(float delayTimeInSeconds)
        {
            yield return new WaitForSeconds(delayTimeInSeconds);
            ConvertObject();
        }

        #endregion
    }
}