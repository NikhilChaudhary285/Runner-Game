using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundScrolling : MonoBehaviour
{
    // [SerializeField] private float grounddurationTime = 5f;

    private Material groundmaterial;
    [SerializeField] private float xVelocity, yVelocity;
    private Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        groundmaterial = GetComponent<Renderer>().material;

        // Tweening Method
        // groundmaterial.DOOffset(new Vector2(10, 0), grounddurationTime).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);

    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(xVelocity, yVelocity);
        groundmaterial.mainTextureOffset += offset * Time.deltaTime;

    }
}
