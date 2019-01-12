using UnityEngine; //abi library for the program

//name of the class name and the script should be the same else would not work
//do not name a script with space
public class PlayerMovement : MonoBehaviour //monobehavior only works for unity
{
    float h, v;
    public float speed = 6f; //f is to convert the 6 to float
    Ray CameraRay; //some camera class
    RaycastHit CameraHit; //the ray hit the object now we cast the ray
    Rigidbody playerRigitBody; //define in awake
    int FloorMask; //only hits something which is defined in Awake
    Animator anim;

    void Awake() //will only start once in the game
    {
        FloorMask = LayerMask.GetMask("Floor");
        playerRigitBody = GetComponent<Rigidbody>(); //get the components from the unity 
        anim = GetComponent <Animator>();
    }

    void FixedUpdate() //loop function for continuous calculations ; frame/sec
    {
        h = Input.GetAxisRaw("Horizontal"); //input methods; O/P is a float 
        v = Input.GetAxisRaw("Vertical");
        Move(h, v); //th player will move to this location
        Turn();
        Animate(h,v);
    }


    void Move(float x , float y )
    {
        Vector3 Movement = new Vector3(x, 0f, y);

        Movement = Vector3.Normalize(Movement); //normalization
        transform.position += Movement * speed * Time.deltaTime;//transform is a vector in unity so we define vector
    }

    void Turn()
    {
        //the direction and origin of the ray has to be defined
        //CameraRay.origin = Camera.main.transform.position;
        //CameraRay.direction = Camera.main.transform.forward; //the blue direction is forward
        //the above two commands are combined to below 
        CameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(CameraRay, out CameraHit, 100f, FloorMask)) //hit something then returns true else false
        {
            Vector3 CameraHitPoint = CameraHit.point; //vector as its a tranform
            Vector3 Direction = CameraHitPoint - transform.position; //defining the direction to the hit point which is our player
            Direction.y = 0f; //disable y direction
            Quaternion Rotation = Quaternion.LookRotation(Direction); //converts the rotation measurement to euler angles; basically rotation of player
            playerRigitBody.MoveRotation(Rotation);
        }
    } 

    void Animate(float x , float y)
    {
        bool walking = x != 0f || y != 0f; //to check whether the player is walking or not

        anim.SetBool("IsWalking", walking);
    }
}
