using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PanelSync : MonoBehaviour
{
    public GameObject Panel1, Panel2, Panel3, Panel4, Panel5;
    private Vector2 xy1, xy2, xy3, xy4, xy5;
    private Vector2 newPosition1, newPosition2, newPosition3, newPosition4;

    public void ChangePosition()
    {
        xy1.y = Panel1.transform.position.y;
        xy2.y = Panel2.transform.position.y;
        xy3.y = Panel3.transform.position.y;
        xy4.y = Panel4.transform.position.y;
        xy5.y = Panel5.transform.position.y;

        xy1.x = Panel1.transform.position.x;
        xy2.x = Panel2.transform.position.x;
        xy3.x = Panel3.transform.position.x;
        xy4.x = Panel4.transform.position.x;
        xy5.x = Panel5.transform.position.x;

        // Moving from the 5th panel
        if (xy1.y == xy2.y
           && xy1.y == xy3.y 
           && xy1.y == xy4.y)
        {
            newPosition1 = new Vector2(xy1.x, xy5.y);
            newPosition2 = new Vector2(xy2.x, xy5.y);
            newPosition3 = new Vector2(xy3.x, xy5.y);
            newPosition4 = new Vector2(xy4.x, xy5.y);
            Panel1.transform.position = newPosition1;
            Panel2.transform.position = newPosition2;
            Panel3.transform.position = newPosition3;
            Panel4.transform.position = newPosition4;
        } 
        else if // Moving from the 4th panel
            (xy1.y == xy2.y
             && xy1.y == xy3.y
             && xy1.y == xy5.y)
        {
            newPosition1 = new Vector2(xy1.x, xy4.y);
            newPosition2 = new Vector2(xy2.x, xy4.y);
            newPosition3 = new Vector2(xy3.x, xy4.y);
            newPosition4 = new Vector2(xy5.x, xy4.y);
            Panel1.transform.position = newPosition1;
            Panel2.transform.position = newPosition2;
            Panel3.transform.position = newPosition3;
            Panel5.transform.position = newPosition4;
        }
        else if // Moving from the 3rd panel
          (xy1.y == xy2.y
           && xy1.y == xy4.y
           && xy1.y == xy5.y)
        {
            newPosition1 = new Vector2(xy1.x, xy3.y);
            newPosition2 = new Vector2(xy2.x, xy3.y);
            newPosition3 = new Vector2(xy4.x, xy3.y);
            newPosition4 = new Vector2(xy5.x, xy3.y);
            Panel1.transform.position = newPosition1;
            Panel2.transform.position = newPosition2;
            Panel4.transform.position = newPosition3;
            Panel5.transform.position = newPosition4;
        }
        else if // Moving from the 2nd panel
          (xy1.y == xy3.y
           && xy1.y == xy4.y
           && xy1.y == xy5.y)
        {
            newPosition1 = new Vector2(xy1.x, xy2.y);
            newPosition2 = new Vector2(xy3.x, xy2.y);
            newPosition3 = new Vector2(xy4.x, xy2.y);
            newPosition4 = new Vector2(xy5.x, xy2.y);
            Panel1.transform.position = newPosition1;
            Panel3.transform.position = newPosition2;
            Panel4.transform.position = newPosition3;
            Panel5.transform.position = newPosition4;
        }
        else if // Moving from the 1st panel
          (xy2.y == xy3.y
           && xy2.y == xy4.y
           && xy2.y == xy5.y)
        {
            newPosition1 = new Vector2(xy2.x, xy1.y);
            newPosition2 = new Vector2(xy3.x, xy1.y);
            newPosition3 = new Vector2(xy4.x, xy1.y);
            newPosition4 = new Vector2(xy5.x, xy1.y);
            Panel2.transform.position = newPosition1;
            Panel3.transform.position = newPosition2;
            Panel4.transform.position = newPosition3;
            Panel5.transform.position = newPosition4;
        }

    }

}
