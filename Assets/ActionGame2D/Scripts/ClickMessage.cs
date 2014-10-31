using UnityEngine;
using System.Collections;

public class ClickMessage : MonoBehaviour {
    public GameObject target;
    public string messageUp = "OnClickUp";
    public string messageDn = "OnClickDown";

    public void OnMouseUp()
    {
        if (target) target.SendMessage(messageUp, SendMessageOptions.DontRequireReceiver);
    }
    public void OnMouseDown()
    {
        if (target) target.SendMessage(messageDn, SendMessageOptions.DontRequireReceiver);
    }
}
