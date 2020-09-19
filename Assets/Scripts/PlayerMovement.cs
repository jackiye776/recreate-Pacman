using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator moveDown;
    public Animator moveLeftRight;
    public Animator moveUp;

    public AudioSource walkSFX;

    [SerializeField]
    private GameObject player;
    private PlayerTween activeTween;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(activeTween);
        AddPlayerTween();
        if (activeTween != null)
        {
            // Cubic easing-in interpolation
            float time = (Time.time - activeTween.StartTime) / activeTween.Duration;
            float timeFraction = time * time * time;

            // Distance between current object's position and the EndPos not "StartPos"
            float dist = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);

            if (dist > 0.1f)
            {
                activeTween.Target.transform.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
            }
            if (dist < 0.1f)
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
            }

        }

        // Get position of player
        pos = player.transform.position;

    }
    public void AddPlayerTween()
    {
        if (activeTween == null)
        {
            if (pos.x == 6 && pos.y == -1)
            {
                activeTween = new PlayerTween(player.transform, player.transform.position, new Vector3(6.0f, -5.0f, 0.0f), Time.time, 1.0f);
            }

            if (pos.x == 6 && pos.y == -5)
            {
                activeTween = new PlayerTween(player.transform, player.transform.position, new Vector3(1.0f, -5.0f, 0.0f), Time.time, 1.0f);
            }

            if (pos.x == 1 && pos.y == -5)
            {
                activeTween = new PlayerTween(player.transform, player.transform.position, new Vector3(1.0f, -1.0f, 0.0f), Time.time, 1.0f);
            }

            if (pos.x == 1 && pos.y == -1)
            {
                activeTween = new PlayerTween(player.transform, player.transform.position, new Vector3(6.0f, -1.0f, 0.0f), Time.time, 1.0f);
            }


        }
    }
}

