using System.Collections.Generic;
using UnityEngine;
using System.Xml;

namespace Skill_System
{

    public sealed class Skill
    {

        public static class Store
        {
            private static Dictionary<string, Skill> skills = new Dictionary<string, Skill>();

            static Store()
            {
                /*skills.Add("Skill 1", new Skill("Test Skill 1", "Test Skill description 1"));
                skills.Add("Skill 2", new Skill("Test Skill 2", "Test Skill description 2"));
                skills.Add("Skill 3", new Skill("Test Skill 3", "Test Skill description 3"));
                skills.Add("Skill 4", new Skill("Test Skill 4", "Test Skill description 4"));
                skills.Add("Skill 5", new Skill("Test Skill 5", "Test Skill description 5"));
                skills.Add("Skill 6", new Skill("Test Skill 6", "Test Skill description 6"));*/
            }

            public static void CreateSkill(string sKey, string sName, string sDesc, Sprite sprite, List<SkillEffect> effects)
            {
                skills.Add(sKey, new Skill(sName, sDesc, sprite, effects));
            }

            public static Skill Find(string skillKey) => skills[skillKey];

            public static void ParseSkills(string xml)
            {
                var doc = new XmlDocument();
                doc.LoadXml(xml);

                var root = doc.FirstChild;
                if(root is XmlDeclaration)
                {
                    root = root.NextSibling;
                }
                //<Skill key="skill_1">
                //  <Name> </Name>
                //  <Description> </Description>
                //</Skill>
                foreach (XmlNode child in root.ChildNodes)
                {

                }
            }
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Sprite SkillSprite { get; private set; }
        public List<SkillEffect> Effects { get; private set; }

        private Skill(string name, string description, Sprite sprite, List<SkillEffect> effects)
        {
            this.Name = name;
            this.Description = description;
            this.SkillSprite = sprite;
            this.Effects = effects;
        }

        public void ApplyEffect(object context, int level)
        {
            for (int i = 0; i < Effects.Count; i++)
            {
                Effects[i].ApplyEffect(context, level);
            }
        }
    }
}
