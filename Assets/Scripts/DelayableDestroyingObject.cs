using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace miniit.MERGE
{
    public class DelayableDestroyingObject : MonoBehaviour
    {
        [SerializeField] float delayTimeInSeconds = 5f;

        private void Start()
        {
            StartCoroutine(DestroyObjectAfterTime(delayTimeInSeconds));
        }

        public IEnumerator DestroyObjectAfterTime(float delayTimeInSeconds)
        {
            yield return new WaitForSeconds(delayTimeInSeconds);
            Destroy(gameObject);
        }
    }
}
