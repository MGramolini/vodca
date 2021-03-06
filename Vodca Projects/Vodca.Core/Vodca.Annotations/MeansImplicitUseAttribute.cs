//-----------------------------------------------------------------------------
// <copyright file="MeansImplicitUseAttribute.cs" company="JetBrains">
//     Copyright (c) JetBrains. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------
namespace Vodca.Annotations
{
    using System;

    /// <summary>
    /// Should be used on attributes and causes ReSharper to not mark symbols marked with such attributes as unused (as well as by other usage inspections)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class MeansImplicitUseAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeansImplicitUseAttribute"/> class.
        /// </summary>
        [UsedImplicitly]
        public MeansImplicitUseAttribute()
            : this(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeansImplicitUseAttribute"/> class.
        /// </summary>
        /// <param name="useKindFlags">The use kind flags.</param>
        /// <param name="targetFlags">The target flags.</param>
        [UsedImplicitly]
        public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags = ImplicitUseTargetFlags.Default)
        {
            this.UseKindFlags = useKindFlags;
            this.TargetFlags = targetFlags;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeansImplicitUseAttribute"/> class.
        /// </summary>
        /// <param name="targetFlags">The target flags.</param>
        [UsedImplicitly]
        public MeansImplicitUseAttribute(ImplicitUseTargetFlags targetFlags)
            : this(ImplicitUseKindFlags.Default, targetFlags)
        {
        }

        /// <summary>
        /// Gets the use kind flags.
        /// </summary>
        [UsedImplicitly]
        public ImplicitUseKindFlags UseKindFlags { get; private set; }

        /// <summary>
        /// Gets value indicating what is meant to be used
        /// </summary>
        [UsedImplicitly]
        public ImplicitUseTargetFlags TargetFlags { get; private set; }
    }
}