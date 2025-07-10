using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastInputDir;
    private bool isOverriding = false;
    private float moveSpeed = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 direction)
    {
        if (isOverriding) return; // 대쉬 중이면 무시

        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 inputDir = new Vector3(direction.x, 0, direction.y).normalized;
            lastInputDir = inputDir;
            rb.linearVelocity = new Vector3(inputDir.x, rb.linearVelocity.y, inputDir.z) * moveSpeed;
        }
        else
        {
            // 입력이 없으면 수평 속도만 0으로
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

    public void ForceMove(Vector3 dir, float force)
    {
        rb.linearVelocity = dir.normalized * force;
        isOverriding = true;
        Invoke(nameof(ResetOverride), 0.1f); // 0.1초 후 이동 제어 재개
    }

    private void ResetOverride()
    {
        isOverriding = false;
    }

    public Vector3 GetLastMoveDirection()
    {
        return lastInputDir;
    }
    public void CreateAfterImage()
    {
        MeshFilter mfOriginal = GetComponentInChildren<MeshFilter>();
        MeshRenderer mrOriginal = GetComponentInChildren<MeshRenderer>();

        if (mfOriginal == null || mrOriginal == null)
        {
            Debug.LogWarning("MeshFilter or MeshRenderer not found!");
            return;
        }

        GameObject ghost = new GameObject("AfterImage");
        ghost.transform.position = mfOriginal.transform.position;
        ghost.transform.rotation = mfOriginal.transform.rotation;
        ghost.transform.localScale = mfOriginal.transform.lossyScale;

        // 복제된 메시
        MeshFilter mf = ghost.AddComponent<MeshFilter>();
        mf.mesh = mfOriginal.sharedMesh;

        // 복제된 머터리얼
        MeshRenderer mr = ghost.AddComponent<MeshRenderer>();
        mr.material = new Material(Shader.Find("Standard"));
        mr.material.SetColor("_Color", new Color(1f, 1f, 1f, 0.4f));
        mr.material.SetFloat("_Mode", 2); // Fade 모드
        mr.material.renderQueue = 3000;

        // 잔상 스크립트 추가 (자동으로 사라짐)
        ghost.AddComponent<AfterImage>();
    }


    //public void CreateAfterImage()
    //{
    //    Debug.Log("AfterImage");
    //    SkinnedMeshRenderer skin = GetComponentInChildren<SkinnedMeshRenderer>();
    //    if (skin == null) return;

    //    GameObject ghost = new GameObject("AfterImage");
    //    ghost.transform.position = skin.transform.position;
    //    ghost.transform.rotation = skin.transform.rotation;
    //    ghost.transform.localScale = skin.transform.lossyScale;

    //    Mesh mesh = new Mesh();
    //    skin.BakeMesh(mesh);

    //    MeshFilter mf = ghost.AddComponent<MeshFilter>();
    //    mf.mesh = mesh;

    //    MeshRenderer mr = ghost.AddComponent<MeshRenderer>();
    //    mr.material = new Material(skin.material); // 잔상 재질 복사

    //    ghost.AddComponent<AfterImage>(); // 위에 만든 스크립트
    //}
}