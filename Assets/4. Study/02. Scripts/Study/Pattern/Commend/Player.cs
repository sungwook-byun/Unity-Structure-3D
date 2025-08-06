using UnityEngine;

namespace Pattern.Command
{ 
    public class Player : MonoBehaviour
    {
        public void Attack()
        {
            Debug.Log("공격");
        }

        public void AttackCancle()
        {
            Debug.Log("공격캔슬");
        }

        public void Jump()
        {
            Debug.Log("점프");
        }

        public void JumpCancel()
        {
            Debug.Log("점프캔슬");
        }

        public void UseSkill(string skillName)
        {
            Debug.Log($"스킬사용 : {skillName}");
        }

        public void UseSkillCancel(string skillName)
        {
            Debug.Log($"스킬사용취소 : {skillName}");
        }
    }
}
