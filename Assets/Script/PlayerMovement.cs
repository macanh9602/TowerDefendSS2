using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    Rigidbody2D rb;
    private float xInput, yInput;
    [SerializeField] float speedMove = 5000f;
    [SerializeField] float speedScrolling = 8f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        Move();
        ZoomCamera();
    }
    public void Move()
    {
        rb.velocity = new Vector3(xInput * speedMove * Time.deltaTime, yInput * speedMove * Time.deltaTime, 0);
    }
    public void ZoomCamera()
    {
        float y = Input.mouseScrollDelta.y;
        if (Input.mouseScrollDelta.y != 0)
        {

            virtualCamera.m_Lens.OrthographicSize -= y * speedScrolling;
            virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize, 20, 50);
        }

    }
}
