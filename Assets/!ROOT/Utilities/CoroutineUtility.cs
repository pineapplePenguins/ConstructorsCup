using System;
using System.Collections;
using UnityEngine;

namespace Code.Scripts.Utility
{
    public class CoroutineUtility
    {
        public static IEnumerator ExecuteOverTime(float duration, Action<float> action, Action onEnd = null)
        {
            var timeElapsed = 0f;

            while (timeElapsed < duration)
            {
                timeElapsed += Time.deltaTime;
                var t = Mathf.Clamp01(timeElapsed / duration);
                
                action(t);
                
                yield return null;
            }
            
            action(1f);
            onEnd?.Invoke();
        }
    }
}