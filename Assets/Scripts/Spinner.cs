using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPostion;
    [SerializeField] Vector3 movmentVector;
    // [SerializeField] [Range(0,1)] float movmentFector;
    float movmentFector;
    [SerializeField] float period = 2f;


    void Start()
    {
        startPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if (period == 0f){ return; } ��� �� ����� ��� ��� ����� ���� ��� ���� ���� ������ ������ ����� ���� ���� ���� 

        if (period == Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // ���� ������� �� �����

        //const ���� ������� �� �����
        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movmentFector = (rawSinWave + 1f) / 2f;// recalculated to go from 0 to 1 so its clraner;

        Vector3 offset = movmentVector * movmentFector;
        transform.position = startPostion + offset;


    }
}
