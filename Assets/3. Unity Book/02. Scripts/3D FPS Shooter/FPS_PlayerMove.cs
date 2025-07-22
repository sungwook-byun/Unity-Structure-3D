using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPS_PlayerMove : MonoBehaviour
{
    private CharacterController cc;
    private Animator anim;

    public float moveSpeed = 7f;

    private float gravity = -20f;
    private float yVelocity = 0f;

    public float jumpPower = 10f; // 점프 파워
    public bool isJumping = false; // 점프 중인지 여부

    public int hp = 20;

    private int maxHp = 20; // 최대 체력
    public Slider hpSlider;

    public GameObject hitEffect;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // 크기와 방향만 있는 벡터
        anim.SetFloat("MoveMotion", dir.magnitude);

        dir = dir.normalized; // 방향만 있는 벡터


        // 카메라의 Transform 기준으로 변환
        dir = Camera.main.transform.TransformDirection(dir);

        // 중력 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime); // 캐릭터 컨트롤러에 내장된 이동기능

        if (cc.collisionFlags == CollisionFlags.Below) // 바닥에 닿아있는지 확인
        {
            if (isJumping)
                isJumping = false;

            yVelocity = 0f; // 점프가 끝나면 yVelocity를 0으로 초기화
        }

        // 점프 기능
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true; // 점프 중으로 설정
            yVelocity = jumpPower; // 점프 파워를 yVelocity에 할당
        }
    }

    public void DamageAction(int damage)
    {
        hp -= damage; // hp 감소

        hpSlider.value = (float)hp / (float)maxHp; // 슬라이더 값 업데이트

        if (hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }

    }

    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true); // 이펙트 활성화
        yield return new WaitForSeconds(0.3f); // 0.3초 대기
        hitEffect.SetActive(false); // 이펙트 비활성화
    }
}
