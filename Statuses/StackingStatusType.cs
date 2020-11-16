﻿using System;
using System.Collections.Generic;
using System.Text;

using static War3Api.Common;
using static War3Api.Blizzard;

namespace NoxRaven.Statuses
{
    public class StackingStatusType : TimedStatusType
    {
        public readonly int StackLimit;
        public readonly int InitialStacks;
        public StackingStatusType(StatusFunction apply, StatusFunction reset, StatusFunction onRemove, string specialEffectAttachmentPoint, string specialEffectPath, int stackLimit = 0, int initialStacks = 1) : base(apply, reset, onRemove, specialEffectPath, specialEffectAttachmentPoint)
        {
            StackLimit = stackLimit;
            InitialStacks = initialStacks;
        }

        public Status ApplyStatus(NoxUnit source, NoxUnit target, int level, float duration, int applyStacks = 1)
        {
            if (!target.ContainsStatus(Id))
                // create new status and add it to unit
                return target.AddStatus(Id, new Status(Id, this, source, target, level, InitialStacks, StackLimit, duration, 0, false, true, false));
            return target.GetStatus(Id).Reapply(duration, level, applyStacks);
        }

        private new Status ApplyStatus(NoxUnit source, NoxUnit target, int level, float duration)
        {
            return null;
        }

    }
}
