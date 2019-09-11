using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    [SerializeField] Transform bkg1;
    [SerializeField] Transform bkg2;
    [SerializeField] Transform cam;

    private bool bkgOne = true;

    private float currentWidth = 12f;
    
    // Update is called once per frame
    void Update()
    {
        if (currentWidth < cam.position.x)
        {
            if (bkgOne)
            {
                bkg1.localPosition = new Vector3( bkg1.localPosition.x + 22f, 0, 0);
            } else
            {
                bkg2.localPosition = new Vector3( bkg2.localPosition.x + 22f, 0, 0);
            }

            currentWidth += 12f;
            bkgOne = !bkgOne;
        }
        if (currentWidth > cam.position.x + 20f)
        {
            if (bkgOne)
            {
                bkg2.localPosition = new Vector3(bkg2.localPosition.x - 22f, 0, 0);
            }
            else
            {
                bkg1.localPosition = new Vector3(bkg1.localPosition.x - 22f, 0, 0);
            }

            currentWidth -= 12f;
            bkgOne = !bkgOne;
        }
    }
}
