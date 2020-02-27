namespace Skill_System
{
    public class DamageEffect : SkillEffect
    {
        private float _dmgMultiplier;

        public override void ApplyEffect(object context, int level)
        {
            throw new System.NotImplementedException();
        }

        public DamageEffect(float dmgMultiplier = 1f)
        {
            this._dmgMultiplier = dmgMultiplier;
        }
    }
}
