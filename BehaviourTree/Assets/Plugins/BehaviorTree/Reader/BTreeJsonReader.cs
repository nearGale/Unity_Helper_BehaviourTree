
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEditor.ShaderData;

namespace BehaviorTree
{
    public static class BTreeJsonReader
    {
        public static BTreeDynamic ReadBTreeJson(string name)
        {
            var jsonData = CommonHelper.ReadJson(name);
            if (jsonData == null) { return null; }

            BTreeDynamic tree = new BTreeDynamic();
            Selector root = null;

            foreach (var key in jsonData.Keys)
            {
                // key: node名
                // sType: node类型

                // Selector、Sequence: 拥有children，是子节点的 key
                // Condition、Action：sType是细分类型，如 ActionLog、ActionWait

                var sType = jsonData[key]["type"].ToString();
                if(sType == "RootNode")
                {
                    root = InitTreeNode(key, jsonData, tree) as Selector;
                }
            }

            if (root == null)
                return null;

            tree.CreateDynamic(root, true);
            return tree;
        }

        private static BTreeBehavior InitTreeNode(string nodeName, JsonData jsonData, BTreeDynamic tree)
        {
            BTreeBehavior node = null;

            // nodeName: node名
            // sType: node类型

            // Selector、Sequence: 拥有children，是子节点的 key
            // Condition、Action：sType是细分类型，如 ActionLog、ActionWait

            var sType = jsonData[nodeName]["type"].ToString();
            switch (sType)
            {
                case "RootNode":
                case "SelctorNode":
                case "SequenceNode":
                    if (sType == "RootNode" || sType == "SelctorNode")
                    {
                        node = new Selector(tree, nodeName);
                    }
                    else
                    {
                        node = new Sequence(tree, nodeName);
                    }
                    var sChildren = jsonData[nodeName]["children"].ToString();
                    // sChildren: 子节点的名称合集，如 "ActionWait, ConditionTrue"
                    string[] childrenName = sChildren.Split(',');
                    foreach (var item in childrenName)
                    {
                        var childName = item.Trim();
                        var childNode = InitTreeNode(childName, jsonData, tree);
                        (node as Composite).AddChild(childNode);
                    }
                    break;
                default:
                    // 包含Action、Condition
                    if (sType.StartsWith("Action") || sType.StartsWith("Condition"))
                    {
                        Type type = Type.GetType("BehaviorTree." + sType); // 获取对应类型
                        //Debug.Log($"{sType} {type}");

                        // 获取带有特定参数类型的构造函数信息
                        ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(BehaviorTree), typeof(string), typeof(string) });
                        if(constructor == null)
                        {
                            Debug.LogError($"{type} 找不到对应的构造函数！！！");
                            return null;
                        }
                        //foreach (ParameterInfo p in constructor.GetParameters())
                        //{
                        //    Debug.Log(p.Name);
                        //}

                        string sParam = null;
                        var param = jsonData[nodeName]["param"];
                        if(param != null)
                        {
                            sParam = param.ToString();
                        }

                        // 使用反射创建实例，传递参数值
                        object[] constructorArgs = { tree, nodeName, sParam }; // 参数值数组
                        object instance = Activator.CreateInstance(type, constructorArgs); // 创建实例

                        // 现在instance是对应类的一个实例，可以使用正常的方式操作它。

                        node = instance as Leaf;
                    }
                    break;
            }

            return node;
        }
    }
}