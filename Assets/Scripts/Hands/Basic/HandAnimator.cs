using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimator : MonoBehaviour
{
    public float speed = 5.0f;
    public ActionBasedController Controller = null;
    public bool IsClosed = false;

    private Animator animator = null;

    private readonly List<Finger> gripFingers = new List<Finger>()
    {
        new Finger(FingerType.Middle),
        new Finger(FingerType.Ring),
        new Finger(FingerType.Pinky)
    };

    private readonly List<Finger> pointFingers = new List<Finger>()
    {
        new Finger(FingerType.Index),
        new Finger(FingerType.Thumb)
    };


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Store input
        if (IsClosed)
        {
            SetFingerTargets(gripFingers, 1.0f);
            SetFingerTargets(pointFingers, 1.0f);
        }
        else
        {
            CheckGrip();
            CheckPointer();
        }

        // Smooth input 
        SmoothFinger(gripFingers);
        SmoothFinger(pointFingers);

        // Apply smooth values
        AnimateFinger(gripFingers);
        AnimateFinger(pointFingers);

    }

    private void CheckGrip()
    {
        float gripValue = Controller.selectActionValue.action.ReadValue<float>();
        SetFingerTargets(gripFingers, gripValue);
    }

    private void CheckPointer()
    {
        float pointerValue = Controller.activateActionValue.action.ReadValue<float>();
        SetFingerTargets(pointFingers, pointerValue);
    }

    private void SetFingerTargets(List<Finger> fingers, float value)
    {
        foreach (Finger finger in fingers)
        {
            finger.target = value;
        }
    }

    private void SmoothFinger(List<Finger> fingers)
    {
        foreach (Finger finger in fingers)
        {
            float time = speed * Time.unscaledDeltaTime;
            finger.current = Mathf.MoveTowards(finger.current, finger.target, time);
        }
    }

    private void AnimateFinger(List<Finger> fingers)
    {
        foreach (Finger finger in fingers)
            AnimateFinger(finger.type.ToString(), finger.current);
    }

    private void AnimateFinger(string finger, float blend)
    {
        animator.SetFloat(finger, blend);
    }
}