using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlightPlants : MonoBehaviour
{
    private LuminescentPlants plants;
    private BrightFoothold brightFoothold;

    [ColorUsage(true, true)]
    public Color _color;
    public float brightStep = Mathf.Clamp(0, 0, 4);

    public Vector2 pos;
    private float size = 3f;
    private SpriteRenderer sprite;
    public LayerMask foothold;

    private void Awake()
    {
        plants = GameObject.Find("Luminescent Plants").GetComponent<LuminescentPlants>();
        sprite = GetComponent<SpriteRenderer>();

        plants.OnPlants += Overlap;
        plants.OnPlants += BrightnessControl;
    }


    private void BrightnessControl()
    {
        sprite.color = _color;

        if (Input.GetKeyDown(KeyCode.I))
        {
            _color = _color * 5f;
            brightStep += 1;
            print(brightStep);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            _color = _color * 0.1f;
            brightStep -= 1;
            print(brightStep);
        }
    }
    private void Overlap()
    {
        Collider2D collision = Physics2D.OverlapCircle(pos, size, foothold);
        if (collision)
        {
                brightFoothold.BrightStep();
                print("dd");
        }
    }

    void OnDrawGizmos() // 범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
