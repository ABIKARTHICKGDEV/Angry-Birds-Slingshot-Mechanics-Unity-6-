using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class SliceShortHandeller : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRendererRIGNT;
    [SerializeField]private LineRenderer lineRendererLEFT;

    [SerializeField]private Transform leftstartposition;
    [SerializeField] private Transform rightstartposition;

    [SerializeField] private Transform bird;

   

    private bool isDragging;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update() {
        if (isDragging) {
            DrawSLingShort();
        }
    }
    public void StartDragging() {
        isDragging = true;
    }

    public void StopDragging() {
        isDragging = false;

        ResetBands();
    }
    private void DrawSLingShort()
    {
        //Vector3 touchposition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        setlines(bird.position);
    }
    private void setlines(Vector2 position) {
        lineRendererLEFT.SetPosition(0, leftstartposition.position);
        lineRendererLEFT.SetPosition(1, position);

        lineRendererRIGNT.SetPosition(0, rightstartposition.position);
        lineRendererRIGNT.SetPosition(1, position);
    }
    private void ResetBands() {
        lineRendererLEFT.SetPosition(0, leftstartposition.position);
        lineRendererLEFT.SetPosition(1, leftstartposition.position);

        lineRendererRIGNT.SetPosition(0, rightstartposition.position);
        lineRendererRIGNT.SetPosition(1, rightstartposition.position);
    }
    
}
