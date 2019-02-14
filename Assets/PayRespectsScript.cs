using UnityEngine;
using System.Collections;

public class PayRespectsScript : MonoBehaviour
{
    public KMSelectable AddTimeButton;
    public KMAudio Audio;

    void Awake()
    {
        GetComponent<KMNeedyModule>().OnNeedyActivation += OnNeedyActivation;
        GetComponent<KMNeedyModule>().OnNeedyDeactivation += OnNeedyDeactivation;
        AddTimeButton.OnInteract += AddTime;
        GetComponent<KMNeedyModule>().OnTimerExpired += OnTimerExpired;
    }

    protected void OnNeedyActivation()
    {

    }

    protected void OnNeedyDeactivation()
    {

    }

    protected void OnTimerExpired()
    {
        GetComponent<KMNeedyModule>().OnStrike();
    }

    protected bool AddTime()
    {
        AddTimeButton.AddInteractionPunch();
        float time = GetComponent<KMNeedyModule>().GetNeedyTimeRemaining();
        if (time > 0)
        {
            GetComponent<KMNeedyModule>().SetNeedyTimeRemaining(time + 1f);
        }
        if (time > 29)
        {
            GetComponent<KMNeedyModule>().SetNeedyTimeRemaining(time - 0f);
        }
        

        return false;
    }
}