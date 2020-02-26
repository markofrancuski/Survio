using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_System
{
    public struct SkillRequirement
    {
        public int requiredLevel { get; private set; }

        public SkillRequirement(int level)
        {
            requiredLevel = level;
        }
    }
}
