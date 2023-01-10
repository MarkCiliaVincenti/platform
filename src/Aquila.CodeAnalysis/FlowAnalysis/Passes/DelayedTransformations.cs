﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Aquila.CodeAnalysis;
using Aquila.CodeAnalysis.FlowAnalysis;
using Aquila.CodeAnalysis.Symbols;
using Aquila.CodeAnalysis.Symbols.Source;

namespace Aquila.CodeAnalysis.FlowAnalysis.Passes
{
    /// <summary>
    /// Stores certain types of transformations in parallel fashion and performs them serially afterwards.
    /// </summary>
    internal class DelayedTransformations
    {
        /// <summary>
        /// Methods with unreachable declarations.
        /// </summary>
        public ConcurrentBag<SourceMethodSymbolBase> UnreachableMethods { get; } = new ConcurrentBag<SourceMethodSymbolBase>();

        // /// <summary>
        // /// Types with unreachable declarations.
        // /// </summary>
        // public ConcurrentBag<SourceTypeSymbol> UnreachableTypes { get; } = new ConcurrentBag<SourceTypeSymbol>();

        // /// <summary>
        // /// Functions that were declared conditionally but analysis marked them as unconditional.
        // /// </summary>
        // public ConcurrentBag<SourceFunctionSymbol> FunctionsMarkedAsUnconditional { get; } = new ConcurrentBag<SourceFunctionSymbol>();

        public bool Apply()
        {
            bool changed = false;

            foreach (var method in UnreachableMethods)
            {
                if (!method.IsUnreachable)
                {
                    method.Flags |= MethodFlags.IsUnreachable;
                    changed = true;
                }
            }

            // foreach (var type in UnreachableTypes)
            // {
            //     if (!type.IsMarkedUnreachable)
            //     {
            //         type.IsMarkedUnreachable = true;
            //         changed = true;
            //     }
            // }

            // foreach (var f in FunctionsMarkedAsUnconditional)
            // {
            //     if (f.IsConditional && !f.IsUnreachable)
            //     {
            //         f.IsConditional = false;
            //         changed = true;
            //     }
            // }

            //
            return changed;
        }
    }
}
