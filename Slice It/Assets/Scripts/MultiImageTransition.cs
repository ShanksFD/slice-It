using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiImageTransition : Button
{
    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        if (state == SelectionState.Pressed)
        {
            transform.GetComponent<Animator>().SetTrigger("clicked");
        }
    }

}

