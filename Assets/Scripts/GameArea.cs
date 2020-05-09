using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    Defender defender;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = 0;

        var obj = Instantiate(defender, SnapToGrid(point), Quaternion.identity);
    }

    private Vector2 SnapToGrid(Vector2 rawPos)
    {
        int newX = Mathf.RoundToInt(rawPos.x);
        int newY = Mathf.RoundToInt(rawPos.y);

        return new Vector2(newX, newY);
    }

    public void SetSelectedDefender(Defender d)
    {
        defender = d;
    }
}
