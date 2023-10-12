using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackGroundScrolling : MonoBehaviour
{
    // [SerializeField] private float backgrounddurationTime = 15f;

    private Material backgroundmaterial;

    [SerializeField] private float xVelocity, yVelocity;
    private Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        backgroundmaterial = GetComponent<Renderer>().material;
        // Tweening Method
        //backgroundmaterial.DOOffset(new Vector2(-10, 0), backgrounddurationTime).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);

    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(xVelocity, yVelocity);
        backgroundmaterial.mainTextureOffset += offset * Time.deltaTime;

    }


}
