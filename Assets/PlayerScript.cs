using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    BubbleScript _activebubble;
    SteamVR_TrackedController controller;

	// Use this for initialization
	void Start () {
       controller = GetComponent<SteamVR_TrackedController>();
        if (controller == null)
        {
            controller = gameObject.AddComponent<SteamVR_TrackedController>();
        }
        controller.TriggerClicked += new ClickedEventHandler(Fire);

    }

    // Update is called once per frame
    void Update () {

	}

    // Fire when trigger on controller clicks
    void Fire(object sender, ClickedEventArgs e)
    {
        Debug.Log("Fired");
        int layerMask = 1 << 8;
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, transform.forward * 10, out _hit, 10.0f, layerMask))
        {
            _activebubble = _hit.collider.gameObject.GetComponent<BubbleScript>();
            _activebubble.SendMessage("Pop");
        }
    }
}
