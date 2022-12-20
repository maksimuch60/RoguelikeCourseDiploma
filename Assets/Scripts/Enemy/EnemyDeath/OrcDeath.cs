namespace RogueLike
{
    public class OrcDeath : EnemyDeath
    {
        protected override void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;

            _enemyAttack.enabled = false;
            _enemyHp.enabled = false;
            _enemyMovement.enabled = false;
        }
    }
}