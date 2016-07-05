using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {

    GameController _controller;

	// Use this for initialization
	void Start () {
        _controller = GameObject.FindObjectOfType<Terrain>().GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Pop()
    {
        GetComponent<MeshRenderer>().enabled = false;
        foreach (ParticleSystem _system in gameObject.GetComponentsInChildren<ParticleSystem>(true))
        {
            _system.Play();
        }
        _controller.SendMessage("NewBubble");
        Destroy(gameObject);
    }
}
