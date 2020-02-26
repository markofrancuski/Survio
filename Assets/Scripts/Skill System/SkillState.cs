namespace Skill_System
{
    public class SkillState
    {
        public Skill Skill { get; private set; }
        public int Level { get; private set; }
        public int MaxLevel { get; private set; }

        public SkillState(Skill s, int maxLevel,int level = 0)
        {
            this.Skill = s;
            this.MaxLevel = maxLevel;
            this.Level = level;
        }

        public void IncreaseLevel(int by = 1)
        {
            Level += by;
        }
    }
}
