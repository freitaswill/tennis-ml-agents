using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public TennisAgent redAgent;
    public TennisAgent blueAgent;
    public float throwForce;
    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.tag)
        {
            case "Blue": body.AddForce(collision.contacts[0].normal * throwForce, ForceMode.Impulse);
                         blueAgent.AddReward(1f);
                break;
            case "Red": body.AddForce(collision.contacts[0].normal * throwForce, ForceMode.Impulse);
                        redAgent.AddReward(1f);
                break;
            case "Blue Court":
                blueAgent.AddReward(10f);
                //redAgent.AddReward(-2.5f);
                blueAgent.EndEpisode();
                redAgent.EndEpisode();
                break;
            case "Red Court":
                redAgent.AddReward(10f);
                //blueAgent.AddReward(-2.5f);
                blueAgent.EndEpisode();
                redAgent.EndEpisode();
                break;
        }
    }
}
