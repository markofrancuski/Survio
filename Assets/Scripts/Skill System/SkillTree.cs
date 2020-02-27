
using System.Collections.Generic;

namespace Skill_System
{
    public sealed class SkillTree
    {
        public static class Generator
        {
            public static SkillTree testTree1()
            {

                var tree = new SkillTree();

                var skill1 = Skill.Store.Find("Skill 1");
                var skill2 = Skill.Store.Find("Skill 2");
                var skill3 = Skill.Store.Find("Skill 3");
                var skill4 = Skill.Store.Find("Skill 4");
                var skill5 = Skill.Store.Find("Skill 5");
                var skill6 = Skill.Store.Find("Skill 6");

                var skill1Node = new Node(skill1, 7);
                var skill2Node = new Node(skill2, 7);
                var skill3Node = new Node(skill3, 7);
                var skill4Node = new Node(skill4, 7);
                var skill5Node = new Node(skill5, 7);
                var skill6Node = new Node(skill6, 7);

                tree.root = skill1Node;
                skill1Node.children.Add( (skill2Node, new SkillRequirement(3) ));
                skill1Node.children.Add( (skill3Node, new SkillRequirement(1) ));

                skill2Node.children.Add( (skill4Node, new SkillRequirement(4) ));
                skill2Node.children.Add( (skill5Node, new SkillRequirement(6) ));

                skill3Node.children.Add((skill6Node, new SkillRequirement(2) ));

                tree.NodeCache.Add(skill1, skill1Node);
                tree.NodeCache.Add(skill2, skill2Node);
                tree.NodeCache.Add(skill3, skill3Node);
                tree.NodeCache.Add(skill4, skill4Node);
                tree.NodeCache.Add(skill5, skill5Node);
                tree.NodeCache.Add(skill6, skill6Node);

                return tree;
            }

        }

        private sealed class Node
        {
            public SkillState skillState;
            public List<(Node, SkillRequirement)> children = new List<(Node,SkillRequirement)>();

            public Node(Skill skill, int maxLevel)
            {
                this.skillState = new SkillState(skill, maxLevel);
            }
        }

        private Node root;
        private Dictionary<Skill, Node> NodeCache = new Dictionary<Skill, Node>();
        
        private SkillTree()
        {
        }

        public SkillState GetSkillState(string skillKey)
        {
            return NodeCache[Skill.Store.Find(skillKey)].skillState;
        }

        public IEnumerable<SkillRequirement> GetRequirements(Skill skill)
        {
            var node = NodeCache[skill];
            foreach (var child in node.children)
            {
                yield return child.Item2;
            }
        }

        public IEnumerable<SkillState> Enumerate()
        {
            var Queue = new Queue<Node>();
            Queue.Enqueue(root);
            while(Queue.Count > 0)
            {
                var Node = Queue.Dequeue();
                yield return Node.skillState;

                for (int i = 0; i < Node.children.Count; i++)
                {
                    Queue.Enqueue(Node.children[i].Item1);
                }
            }
        }

        public IEnumerable<(SkillState, SkillRequirement)> EnumerateChildren(Skill skill)
        {
            var Node = NodeCache[skill];

            for (int i = 0; i < Node.children.Count; i++)
            {
                yield return (Node.children[i].Item1.skillState, Node.children[i].Item2);
            }
        }
    }
}
