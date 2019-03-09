using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public PairInput[] pairInput;

    [System.Serializable]
    public class PairInput
    {
        [Tooltip("The button that will be used to control the limb")]
        public string input;

        //[Tooltip("The limbs you would like to control")]
        public MovableLimb limb;
    }


    [System.Serializable]
    public class PairAxis
    {
        public string[] axis;

        //[Tooltip("The limbs you would like to control")]
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

            

            if (Input.GetButtonDown(pair.input))
            {
                playerControlingInput(controlled, pair.limb);
                
                activeLimbs++;
            }

            if(Input.GetButtonUp(pair.input))
            {
                playerControlingInput(controlled, pair.limb);

                activeLimbs--;
            }


        }

        foreach (PairAxis pair in pairAxis)
        {

            float horizontalAxis = Input.GetAxis(pair.axis[0]);
            float verticalAxis = Input.GetAxis(pair.axis[1]);


            //float verticalAxis = Input.GetAxis(pair.axis[1]);
            //float PlayerAxis = Input.GetAxis(pair.axis);

            Vector2 movement = new Vector2(horizontalAxis, verticalAxis);

            //playercontrollingAxis(movement, horizontalAxis, verticalAxis, pair.limb[]);

            for (int i = 0; i < pair.limb.Length; i++)
            {
                

                playercontrollingAxis(movement, horizontalAxis, verticalAxis, pair.limb[i]);
            }
            

            Debug.Log(horizontalAxis + " : " + verticalAxis);


        }






    }

    public void playerControlingInput(bool controlled, MovableLimb limb)
    {
        //activeLimbs++;

        if (activeLimbs <= maxLimbs)
        {
            //moveableLimb.SetControlled(controlled);
            limb.SetControlled(controlled);

            //Debug.Log("Player being controlled " + controlled);
        }

        //Debug.Log(activeLimbs);

      
    }

    public void playercontrollingAxis(Vector2 movement, float horizontalAxis, float verticalAxis, MovableLimb limb)
    {
        limb.Axis(horizontalAxis, verticalAxis);
        limb.ForceDirection(movement);

        //Debug.Log(horizontalAxis + " : " + verticalAxis);
        //return pairAxis.
    }
}
