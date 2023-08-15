using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : Movement
{
    public float changeOrbitRadius;  //궤도 변경 반지름
    protected float maxOrbitRadius; //최대 궤도 반지름
    
    protected void IncreaseOrbit()
    {
        if(orbitRadius >= minOrbitRadius && orbitRadius < minOrbitRadius + 5 * changeOrbitRadius)
        {
            orbitRadius += changeOrbitRadius;
        }
    }

    protected void DecreaseOrbit()
    {
        if(orbitRadius > minOrbitRadius && orbitRadius <= minOrbitRadius + 5 * changeOrbitRadius)
        {
                orbitRadius -= changeOrbitRadius;
        }
    }
}
