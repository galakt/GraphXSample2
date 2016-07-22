using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphX.PCL.Common.Models;

namespace GraphXSample2
{
    public class SampleDataVertex : VertexBase
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public int ImageId { get; set; }

        #region Calculated or static props

        public override string ToString()
        {
            return Text;
        }

        #endregion

        public SampleDataVertex():this(string.Empty)
        {
        }

        public SampleDataVertex(string text = "")
        {
            Text = string.IsNullOrEmpty(text) ? "New Vertex" : text;
        }
    }
}
