using UnityEngine;

public class Items : MonoBehaviour
{
    Rigidbody rb;

    Vector3 ScreenPoint;
    Vector3 Offset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnMouseDown()
    {
        rb.useGravity = false;
        ScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z));
    }

    private void OnMouseDrag()
    {

        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + Offset;
        cursorPosition.x = Mathf.Clamp(cursorPosition.x, -1.3f, 1.3f);
        cursorPosition.z = Mathf.Clamp(cursorPosition.z, -2.04f, 2.4f);

        rb.position = cursorPosition;
        rb.MovePosition(new Vector3(rb.position.x, 1f, rb.position.z));
    }

    private void OnMouseUp()
    {
        rb.useGravity = true;
    }
}
