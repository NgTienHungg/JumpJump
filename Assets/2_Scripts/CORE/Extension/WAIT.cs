using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public static class WAIT
{
    public static void Delay(MonoBehaviour mono, float delay, UnityAction action)
    {
        mono.StartCoroutine(Execute(delay, action));
    }

    private static IEnumerator Execute(float delay, UnityAction action)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }

    public static void Delay(this MonoBehaviour mono, int frame, UnityAction action)
    {
        mono.StartCoroutine(Execute2(frame, action));
    }

    private static IEnumerator Execute2(int frame, UnityAction action)
    {
        while (frame > 0)
        {
            frame--;
            yield return null;
        }
        action.Invoke();
    }
}