using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.Lab04A
{
    /// <summary>
    /// Recursive algorithms over a rooted hierarchy.
    ///
    /// The key idea is structural recursion:
    /// solve the current node, then apply the same operation to each child subtree.
    /// </summary>
    public static class HierarchyTraversal
    {
        public static int CountNodes<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            if (root.IsLeaf == true)
            {
                return 1;
            }
            else
            {
                int count = 1;
                foreach (var node in root.Children)
                {
                    count += CountNodes(node);
                }
                return count;
            }
        }

        public static bool Contains<T>(HierarchyNode<T> root, T target)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (root.IsLeaf == false)
            {
                foreach (var node in root.Children)
                {
                    if (Contains(node, target))
                    {
                        return true;
                    }
                }
            }

            if (root.Value == null)
            {
                return false;
            }
            if (root.Value.Equals(target))
            {
                return true;
            }
            return false;
        }

        public static IReadOnlyList<T> DepthFirstPreOrder<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            List<T> result = new List<T>();

            result.Add(root.Value);
            if (root.IsLeaf != true)
            {
                foreach(var node in root.Children)
                {
                    IReadOnlyList<T> list = DepthFirstPreOrder(node);
                    foreach(var child in list)
                    {
                        result.Add(child);
                    }
                }
            }

            return result;
        }

        public static int MaxDepth<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            if (root.IsLeaf)
            {
                return 0;
            }
            int depth = 1;
            int curDepth = 1;
            foreach (var node in root.Children)
            {
                curDepth += MaxDepth(node);
                if (curDepth >= depth)
                {
                    depth = curDepth;
                }
                curDepth = 1;
            }
            return depth;

            // Depth is measured in edges from the root.
            // A single-node tree therefore has max depth 0.
        }
    }
}
