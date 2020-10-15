using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Mole : MonoBehaviour
{

    private SpriteRenderer sprite;
    public Color colour;
    public Color mouseColour;

    public bool beenClicked;
    public bool isUp;
    public float timerReset = 0.25f;
    private float popUpTimer;
    private float goDownTimer;
    private float redTimer;

    private Color down = Color.black;
    private Color up = Color.yellow;
    private Color missed = Color.red;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        sprite.color = down;
        popUpTimer = (int)(Random.Range(5, 10));
        goDownTimer = (int)(Random.Range(0, 20));
        redTimer = (int)(2);

        //      popUpTimer = timerReset;
        //      goDownTimer = timerReset;
    }

    private void OnMouseDown()
    {
        beenClicked = true;
        sprite.color = down;

    }

    void Update()
    {

        Debug.Log("Pop Up Timer : " + popUpTimer);
        Debug.Log("Go Down Timer : " + goDownTimer);

        if (sprite.color == down)
        {
            PopUp();
        }


        if (sprite.color == up)
        {

            goDownTimer -= Time.deltaTime;


            if (goDownTimer <= 2 && goDownTimer >= 0.01f) //if it still has NOT been clicked
            {

                goDownTimer = (int)(5);

                beenClicked = false;
                isUp = true;
                sprite.color = missed;
            }


            if (goDownTimer <= 0) //mole runs away
            {
                sprite.color = down;
                beenClicked = false;
                isUp = false;
            }




        }





        if (beenClicked == true)
        {
            GoDown();
        }





    }


    public void PopUp()
    {
        isUp = true;

        popUpTimer -= Time.deltaTime; //countdown for how long it takes to pop up


        if (popUpTimer <= 0)
        {
            popUpTimer = (int)(Random.Range(0, 15));  //randomly get back up again
            sprite.color = up;
        }
    }


    public void GoDown() //how long it takes to go down
    {
        goDownTimer -= Time.deltaTime;


        if (goDownTimer <= 2 && sprite.color == up) //mole turns red
        {
            goDownTimer = (int)(5);
            sprite.color = missed;
            beenClicked = false;
            isUp = false;

            if (sprite.color == missed)
            {

            }


        }


        if (goDownTimer <= 0 && isUp == true) //mole runs away
        {
            goDownTimer = (int)(Random.Range(0, 20)); //??
            sprite.color = down;
            beenClicked = false;
            isUp = false;

        }

    }


    //MISSED code: (not working atm)

    //   if (goDownTimer == goDownTimer/4) //if it still has NOT been clicked
    //  {
    //     beenClicked = false;
    //    sprite.color = missed;
    // }


    /**
    public void Missed() //when happens when missed
    {

        beenClicked = false;
        sprite.color = missed;

        GoDown();

        //pause

        //turn off clickability (maybe)

        //

    }

*/




}
