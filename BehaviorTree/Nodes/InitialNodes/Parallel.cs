using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Parallel : Composite
    {
        public enum Policy
        {
            RequireOne,
            RequireAll,
        }

        public Parallel(Policy success, Policy failure)
        {
            m_SuccessPolicy = success;
            m_FailurePolicy = failure;
        }

        protected Policy m_SuccessPolicy;
        protected Policy m_FailurePolicy;

        protected override BTreeStatus Update()
        {
            int successCount = 0;
            int failureCount = 0;

            if (m_Children == null)
                return BTreeStatus.Invalid;

            foreach (var child in m_Children)
            {
                if (child == null)
                    return BTreeStatus.Invalid;

                if (!child.IsTermintaed())
                    child.Tick();

                if (child.Status == BTreeStatus.Success)
                {
                    successCount++;
                    if (m_SuccessPolicy == Policy.RequireOne)
                        return BTreeStatus.Success;
                }

                if (child.Status == BTreeStatus.Failure)
                {
                    failureCount++;
                    if (m_FailurePolicy == Policy.RequireOne)
                        return BTreeStatus.Failure;
                }

                if (child.Status == BTreeStatus.Invalid)
                    return BTreeStatus.Invalid;
            }

            if (m_FailurePolicy == Policy.RequireAll && failureCount == m_Children.Count)
                return BTreeStatus.Failure;

            if (m_SuccessPolicy == Policy.RequireAll && successCount == m_Children.Count)
                return BTreeStatus.Success;

            return BTreeStatus.Running;
        }

        protected override void OnTerminate(BTreeStatus status)
        {
            base.OnTerminate(status);

            if (m_Children != null)
            {
                foreach (var child in m_Children)
                {
                    if (child.Status == BTreeStatus.Running)
                        child.Abort();
                }
            }
        }
    }
}