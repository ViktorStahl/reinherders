using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {
    public MoveableUnit testUnit = null;

    private List<Unit> units = new List<Unit>();
    private List<MoveableUnit> moveableUnits = new List<MoveableUnit>();
    private List<Unit> selectedUnits = new List<Unit>();

    private void Start()
    {
        if (testUnit != null)
        {
            moveableUnits.Add(testUnit);
        }
    }

    public void RightClick(Ray mouseRay)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(mouseRay, out hitInfo, 1000f, (1 << 9) & (1 << 8)))
        {
            //if enemy is pressed 
            if (true)
            {
                foreach (Unit unit in selectedUnits)
                {
                    //Handle attacking etc.
                }
                return;
            }
            else // Do something for ally?
            {
                
            }
        } if (Physics.Raycast(mouseRay, out hitInfo, 1000f, (int)(1 << 10)))
        {
            foreach (Unit unit in selectedUnits)
            {
                if (unit is MoveableUnit)
                {
                    ((MoveableUnit)unit).destination = hitInfo.point;
                }
            }
        }
    }

    public void Select(Ray mouseRay, bool additative)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(mouseRay, out hitInfo, 1000f, (int)(1 << 9)))
        {
            if (!additative) selectedUnits.Clear();
            selectedUnits.Add(hitInfo.collider.GetComponent<MoveableUnit>());
        } else
        {
            selectedUnits.Clear();
        }
    }

    void Update () {
        
	}
}
