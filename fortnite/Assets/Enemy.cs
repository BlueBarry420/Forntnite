using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 100;

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP < 0)
        {
            //death type shi
        }
        else
        {

        //get hit
        }

 
}
