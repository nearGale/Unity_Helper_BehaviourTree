using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    /// <summary>
    /// 其他 Actor 的信息容器
    /// </summary>
    public struct AIActorState
    {
        public Vector2 Pos;
        public Vector2 Velocity;
        public Vector2 FaceDir;
        public float DistanceToSelf;
        //public EnemyType type;
    }

    /// <summary>
    /// 威胁的信息容器
    /// </summary>
    public struct AIThreatState
    {
        public Vector2 Pos;
        public Vector2 Velocity;
        public Vector2 FaceDir;
        //public ThreatType type;
        public float damage;
    }

    /// <summary>
    /// 世界状态模型
    /// 用来存储/描述世界的状态，与对应事件造成的模拟
    /// </summary>
    public class WorldMemory
    {
        /// <summary>
        /// 在指定的时间段模拟这个AI的行为
        /// </summary>
        /// <param name="time"></param>
        public void Simulate(float time)
        {

        }

        ///// <summary>
        ///// 模拟对 actor 的伤害
        ///// </summary>
        ///// <param name="damage"></param>
        ///// <param name="actor"></param>
        //public void Damage(float damage, Actor actor)
        //{

        //}

        /// <summary>
        /// 关于AI当前状态的数据
        /// </summary>
        public struct ESelfState
        {
            public float Level;
            public float SkillLevel;
            public Vector2 Pos;
            public Vector2 FaceDir;
        }

        public ESelfState SelfState;

        /// <summary>
        /// 目标状态
        /// </summary>
        public AIActorState VictimState;

        public int EnemyStateCount;

        /// <summary>
        /// 敌人状态列表
        /// </summary>
        AIActorState[] EnemeyStates;

        /// <summary>
        /// 威胁状态列表
        /// </summary>
        AIThreatState[] ThreatStates;

    }


}