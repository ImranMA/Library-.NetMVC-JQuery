using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Common
{
    public class SearchCriteria
    {
        /// <summary>
        /// Gets or sets the Duration.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the Duration.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the name of the article.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The start index.
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// The end index.
        /// </summary>
        public int EndIndex { get; set; }

        /// <summary>
        /// The sorting column.
        /// </summary>
        public int SortingCol { get; set; }

        /// <summary>
        /// The sort order.
        /// </summary>
        public string SortOrder { get; set; }
    }
}