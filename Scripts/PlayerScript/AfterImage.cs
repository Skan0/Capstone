using UnityEngine;

public class AfterImage : MonoBehaviour
{
    public float lifeTime = 0.5f;
    public Color color = new Color(1, 1, 1, 0.5f);

    private float timer;
    private MaterialPropertyBlock propBlock;
    private Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        propBlock = new MaterialPropertyBlock();
        rend.GetPropertyBlock(propBlock);
        propBlock.SetColor("_Color", color);
        rend.SetPropertyBlock(propBlock);
    }

    void Start()
    {
        timer = lifeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        float alpha = Mathf.Clamp01(timer / lifeTime);
        Color c = color;
        c.a *= alpha;

        propBlock.SetColor("_Color", c);
        rend.SetPropertyBlock(propBlock);

        if (timer <= 0f)
            Destroy(gameObject);
    }
}