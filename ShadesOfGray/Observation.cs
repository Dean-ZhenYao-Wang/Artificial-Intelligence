using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadesOfGray
{
    /*作为第一步，我们需要将CSV文件中的数据读入观察数据集（标注好的样本数据）。*/
   
    /// <summary>
    /// 观察结果
    /// </summary>
    public class Observation
    {
        public Observation(string label,int[] pixels)
        {
            this.Label = label;
            this.Pixels = pixels;
        }
        /// <summary>
        /// 第一列(标签)表明数字图像代表了什么
        /// </summary>
        public string Label { get; private set; }
        /// <summary>
        /// 表示原始图像的每个像素的灰度编码,从0到255(255 0代表纯黑色,纯白色,和介于两者之间的任何东西是灰色的水平)
        /// 共784列
        /// </summary>
        public int[] Pixels { get; private set; }
    }
}
