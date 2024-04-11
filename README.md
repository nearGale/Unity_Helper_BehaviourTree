## 目标


### 原理

# BehaviourTree

*C# 行为树*

*Unity 可放心食用*

### 包含基础节点
Action
Behavior
Composite
Condition
Decoreator
Filter
Monitor
Parallel
Selector
Sequence

### Action 节点
* ActionLog
* ActionWait - 等待x秒后，返回Succeed，过程中持续Running

### Condition 节点
* ConditionTrue
* ConditionFalse

### DecoratorNodes
* DecoratorRepeat - 装饰器节点：多次执行
* DecoratorInvert - 装饰器节点：取反

## BTreeBlackBoard 黑板
可记录环境信息、树内共享信息
* EnableRunningLog - 打印运行时log，便于跟踪运行情况

![image](https://github.com/nearGale/Unity_BehaviourTree/assets/48747051/e3321179-25fd-4dbb-8809-22f711752e77)

## 树的构造
![image](https://github.com/nearGale/Unity_BehaviourTree/assets/48747051/be31a8cf-ea03-4bc9-863c-7c58c0e75aaa)

## 行为树编辑器[Unity_BehaviourTreeEditor]
可以编辑树、填入节点参数，输出Json文件，这边读取使用
https://github.com/nearGale/Unity_BehaviourTreeEditor
![image](https://github.com/nearGale/Unity_BehaviourTree/assets/48747051/97165422-19d4-4276-bae2-0bb86c9373df)


## 读取Json文件生成树
Json文件放在Resources文件夹下

BTreeJsonReader.ReadBTreeJson("BTreeExample");
![image](https://github.com/nearGale/Unity_BehaviourTree/assets/48747051/0d9d93b3-0bd1-42dc-be88-9f250262e7ca)

## 树快照
Snapshot()

![image](https://github.com/nearGale/Unity_BehaviourTree/assets/48747051/310bfef7-98a7-471e-8026-7dbbe8dda6cf)
