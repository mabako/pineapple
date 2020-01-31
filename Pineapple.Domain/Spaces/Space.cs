﻿using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Domain.Spaces
{
    /// <inheritdoc/>
    public class Space : ISpace
    {
        protected Space()
        {
            Pages = new PageCollection();
        }
        
        /// <inheritdoc/>
        public SpaceName Name { get; protected set; }
        
        /// <summary>
        /// All pages contained within this space.
        /// </summary>
        public PageCollection Pages { get; protected set; }
    }
}