using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    ResourcePile currentPile = null;
    public float productivityMultiplier = 2;

    protected override void BuildingInRange()
    {
        if(currentPile == null)
        {
            //try to find a pile
            ResourcePile pile = m_Target as ResourcePile;

            //if we do find a pile, add a multiplier
            if(pile != null)
            {
                currentPile = pile;
                currentPile.ProductionSpeed *= productivityMultiplier;
            }
        }
    }

    void resetProductivity()
    {
        // reset the productivity speed when leaving a pile
        if(currentPile != null)
        {
            currentPile.ProductionSpeed /= productivityMultiplier;
            currentPile = null;
        }

    }

    public override void GoTo(Building target)
    {
        resetProductivity();
        base.GoTo(target);
    }


    public override void GoTo(Vector3 position)
    {
        resetProductivity();
        base.GoTo(position);
    }

}
