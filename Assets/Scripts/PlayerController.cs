using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public bool isMoving;
    Vector3 destinationPoint, direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // characterController.Move(Vector3.one  * Time.deltaTime);
        if (Input.GetMouseButtonDown(0)) // click chuột trái
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                destinationPoint =new Vector3( hit.transform.position.x,0,hit.transform.position.z);
                isMoving = true;
            }
        }
        if(isMoving)
        {
            direction= destinationPoint-new Vector3(transform.position.x,0,transform.position.z);
            if(direction.magnitude > 0.05f)
            {
                characterController.Move(direction.normalized * 5f * Time.deltaTime);
                transform.forward = direction;
                Debug.Log("voday");
            }
            else
            {
                isMoving = false;
                transform.forward=new Vector3(0,0,-1);
            }
        }
    }
}
