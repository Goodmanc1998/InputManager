using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    MovableLimb moveableLimb;

    public PairInput[] pairInput;

    [System.Serializable]
    public class PairInput
    {
        [Tooltip("The button that will be used to control the limb")]
        public string input;

        [Tooltip("The limbs you would like to control")]
        public MovableLimb[] limb;
    }

    [System.Serializable]
    public class PairAxis
    {
        public string axis;

        [Tooltip("The limbs you would like to control")]
        public MovableLimb[] limb;
    }

    public PairAxis[] pairAxis;
    
    float[] movementDirection;

    int activeLimbs = 0;
    public int maxLimbs = 4;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 

        foreach (PairInput pair in pairInput)
        {
            bool controlled = Input.GetButton(pair.input);

            

            if (Input.GetButton(pair.input))
            {
                playerControlingInput(controlled);
                
                activeLimbs++;
            }
        }

        foreach (PairAxis pairAxis in pairAxis)
        {

            float horizontalAxis = pairAxis.axis[0];
            float verticalAxis = pairAxis.axis[1];
            Vector2 movement = new Vector2(pairAxis.axis[0], pairAxis.axis[1]);

            playercontrollingAxis(horizontalAxis, verticalAxis, movement);

            //Debug.Log(horizontalAxis + " : " + verticalAxis);


        }




    }

    public void playerControlingInput(bool controlled)
    {
        //activeLimbs++;

        if (activeLimbs <= maxLimbs)
        {
            moveableLimb.SetControlled(controlled);

            Debug.Log("Player being controlled " + controlled);
        }

        if(controlled == false)
            activeLimbs--;

        Debug.Log(activeLimbs);
    }

    public void playercontrollingAxis(float horizontalAxis, float verticalAxis, Vector2 movement)
    {
        moveableLimb.Axis(horizontalAxis, verticalAxis);
        moveableLimb.ForceDirection(movement);


        Debug.Log(horizontalAxis + " : " + verticalAxis);
        //return pairAxis.
    }
}
