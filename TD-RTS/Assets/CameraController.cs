using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 20f;
    public float panBorderThickness = 20f;
    public Vector2 panLimit;

    //zoom values
    public float zoomSpeed = 4f;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 20.0f;
    private float targetOrtho;



    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
    }


    void Update()
    {

        Vector2 pos = transform.position;

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        #region PC Camera Controls
        //mouse.position is measured from bottom left corner of screen
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float zoom = Input.GetAxis("Mouse ScrollWheel");
        if (zoom != 0.0f)
        {
            targetOrtho -= zoom * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
        #endregion
#endif
        #region Mobile Camera Controls
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;

            targetOrtho += deltaMagDiff * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
        }


        /*if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime, -touchDeltaPosition.y * speed * Time.deltaTime, 0);

            Vector3 tmpPosX = transform.position;
            tmpPosX.x = Mathf.Clamp(tmpPosX.x, maxXleft, maxXright);
            transform.position = tmpPosX;


            Vector3 tmpPosY = transform.position;
            tmpPosY.y = Mathf.Clamp(tmpPosY.y, maxYleft, maxYright);
            transform.position = tmpPosY;

        }*/

        /*if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            Vector2 touchPosition = Input.GetTouch(0).position;
            Vector2 touchDeltaMag = (touchDeltaPosition - touchPosition);
            //transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime, -touchDeltaPosition.y * speed * Time.deltaTime, 0);
            pos.x = -touchDeltaMag.x * panSpeed * Time.deltaTime;
            pos.y =  -touchDeltaMag.y * panSpeed * Time.deltaTime;
        }*/

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            //transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);

            //pos.x = touchDeltaPosition.x * Time.deltaTime;
            //pos.y = touchDeltaPosition.y * Time.deltaTime;
            pos = touchDeltaPosition * Time.deltaTime;
        }



        #endregion





        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        transform.position = new Vector3 (pos.x, pos.y, -10) ;
    }
    
}
