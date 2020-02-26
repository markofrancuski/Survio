using System.Collections.Generic;

namespace Skill_System
{

    public sealed class Skill
    {

        public static class Store
        {
            private static Dictionary<string, Skill> skills = new Dictionary<string, Skill>();

            static Store()
            {
                skills.Add("Skill 1", new Skill("Test Skill 1", "Test Skill description 1"));
                skills.Add("Skill 2", new Skill("Test Skill 2", "Test Skill description 2"));
                skills.Add("Skill 3", new Skill("Test Skill 3", "Test Skill description 3"));
                skills.Add("Skill 4", new Skill("Test Skill 4", "Test Skill description 4"));
                skills.Add("Skill 5", new Skill("Test Skill 5", "Test Skill description 5"));
                skills.Add("Skill 6", new Skill("Test Skill 6", "Test Skill description 6"));
            }

            public static Skill Find(string skillKey) => skills[skillKey];
        }


        public string Name { get; private set; }
        public string Description { get; private set; }

        private Skill(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
