﻿using System.Linq;
using System.Collections.Generic;
using GameWork.Core.Utilities;

namespace GameWork.Core.Extensions
{
    /// <summary>
    /// Todo: Please contact us if you see this message
    /// </summary>
    public static class EnumerableExtensions
    {
        public static ICollection<TSource> Shuffle<TSource>(this IEnumerable<TSource> enumerable)
        {
            return enumerable.OrderBy(x => RandomUtil.Next()).ToList();
        }
    }
}