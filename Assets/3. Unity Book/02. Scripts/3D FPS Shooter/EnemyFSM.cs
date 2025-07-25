
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    private enum EnemyState { Idle, Move, Attack, Return, Damaged, Die }
    private EnemyState m_State;

    public float findDistance = 8f; // 탐지거리
    private Transform player; // 타겟
    public float attackDistance = 3f; // 공격 가능거리
    public float moveSpeed = 5f; // 이동 속도
    private CharacterController cc; // 캐릭터 컨트롤러

    private Animator anim;
    private NavMeshAgent smith;

    private float currentTime = 0f; // 타이머
    private float attackDelay = 2f; // 공격 딜레이 시간

    public int attackPower = 3;
    public int hp = 15;
    private int maxHp = 15; // 최대 체력
    public Slider hpSlider; // 체력 슬라이더 UI

    private Vector3 originPos;
    private Quaternion originRot;
    public float moveDistance = 20f; // 이동 거리 (원래 위치에서 이동할 거리)

    private void Start()
    {
        m_State = EnemyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        originPos = transform.position; // 원래 위치 저장
        originRot = transform.rotation;
        anim = transform.GetComponentInChildren<Animator>();
        smith = GetComponent<NavMeshAgent>();

        // Cursor.visible = false; // 커서 숨김
        // Cursor.lockState = CursorLockMode.Locked; // 커서 잠금
    }

    private void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                // Damaged();
                break;
            case EnemyState.Die:
                // Die();
                break;
        }

        hpSlider.value = (float)hp / (float)maxHp;
    }

    private void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            anim.SetTrigger("IdleToMove"); // 애니메이션 트리거 설정
            m_State = EnemyState.Move;
            Debug.Log("상태 전환 : Idle -> Move");
        }
    }
    private void Move()
    {
        if(Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return; // 원래 위치에서 너무 멀리 이동한 경우 -> Return 상태로 전환
            Debug.Log("상태 전환 : Move -> Return");
        }
        else if (Vector3.Distance(transform.position, player.position) > attackDistance) // 타겟이 공격 거리보다 먼 경우 -> 이동 실행
        {
            smith.isStopped = true;
            smith.ResetPath(); // NavMeshAgent의 경로를 초기화

            smith.stoppingDistance = attackDistance;
            smith.SetDestination(player.position); // NavMeshAgent를 사용하여 타겟 위치로 이동
        }
        else // 타겟이 공격 거리보다 가까운 경우 -> 공격 전환
        {
            currentTime = attackDelay;
            anim.SetTrigger("MoveToAttackDelay"); // 애니메이션 트리거 설정
            m_State = EnemyState.Attack;
            Debug.Log("상태 전환 : Move -> Attack");
        }
    }
    private void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance) // 공격 범위 내에 있는 경우 -> 공격 실행
        {
            currentTime += Time.deltaTime;
            if(currentTime > attackDelay) // 공격 딜레이가 끝났을 때
            {
                currentTime = 0f; // 타이머 초기화
                // player.GetComponent<FPS_PlayerMove>().DamageAction(attackPower); // 플레이어에게 데미지 적용
                anim.SetTrigger("StartAttack"); // 애니메이션 트리거 설정
                Debug.Log("공격");
            }
        }
        else // 공격 범위 밖에 있을 경우 -> Move 전환
        {
            currentTime = 0f; // 타이머 초기화
            anim.SetTrigger("AttackToMove"); // 애니메이션 트리거 설정
            m_State = EnemyState.Move;
            Debug.Log("상태 전환 : Attack -> Move");
        }
    }

    public void AttackAction()
    {
        player.GetComponent<FPS_PlayerMove>().DamageAction(attackPower);
    }

    private void Return()
    {   
        if (Vector3.Distance(transform.position, originPos) > 0.1f) // 원래 위치로 돌아가는 중
        {
            smith.SetDestination(originPos); // NavMeshAgent를 사용하여 원래 위치로 이동
            smith.stoppingDistance = 0f; // 도착 거리 설정
        }
        else // 원래 위치에 도착한 경우 -> Idle 상태로 전환
        {
            smith.isStopped = true; // NavMeshAgent 정지
            smith.ResetPath(); // NavMeshAgent의 경로를 초기화

            transform.position = originPos; // 위치를 원래 위치로 설정
            transform.rotation = originRot; // 회전을 원래 회전으로 설정
            hp = 15;
            anim.SetTrigger("MoveToIdle"); // 애니메이션 트리거 설정
            m_State = EnemyState.Idle;
            Debug.Log("상태 전환 : Return -> Idle");
        }
    }

    public void HitEnemy(int hitPower)
    {
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return) // 이미 피격 상태이거나 죽은 상태이거나 원래 위치로 돌아가는 중인 경우
            return; // 아무것도 하지 않음

        hp -= hitPower;
        smith.isStopped = true; // NavMeshAgent 정지
        smith.ResetPath(); // NavMeshAgent의 경로를 초기화

        if (hp > 0) // 공격을 받았는데 살았다면
        {
            anim.SetTrigger("Damaged"); // 피격 애니메이션 트리거 설정
            m_State = EnemyState.Damaged; // 피격 상태로 전환
            Debug.Log("상태 전환 : Any State -> Damaged");
            Damaged(); // 피격 처리 실행
        }
        else // 공격을 받아서 죽었다면
        {
            anim.SetTrigger("Die"); // 죽음 애니메이션 트리거 설정
            m_State = EnemyState.Die; // 죽음 상태로 전환
            Debug.Log("상태 전환 : Any State -> Die");
            Die(); // 죽음 처리 실행
        }
    }

    private void Damaged()
    {
        StartCoroutine(DamageProcess()); // 데미지 코루틴 실행
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(1f); // 피격 애니메이션 시간만큼 대기

        m_State = EnemyState.Move; // 피격 후 이동 상태로 전환
        Debug.Log("상태 전환 : Damage -> Move");
    }

    private void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess()); // 죽음 코루틴 실행
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false; // 캐릭터 컨트롤러 비활성화

        yield return new WaitForSeconds(2f); // 죽음 애니메이션 시간만큼 대기
        Debug.Log("소멸");
        Destroy(gameObject); // 오브젝트 제거
    }
}
