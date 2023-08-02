using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//space 키를 누르는 동안 이동이 잠깐 증가함(50% 증가)
//space 키를 떼면 효과가 없어짐.
//대쉬 게이지가 있음.(게이지가 있을 때에만 대쉬 사용 가능)
//대쉬하는 동안 게이지가 없어짐. -> 대쉬를 안 하면, 일정시간동안 게이지가 채워진다.