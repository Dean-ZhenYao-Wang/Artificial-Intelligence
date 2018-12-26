using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadesOfGray
{
    /// <summary>
    /// 偏差计算
    /// </summary>
    public interface IDistance
    {
        /// <summary>
        /// 它接收两个像素数组，并返回一个数字来描述它们的不同之处
        /// </summary>
        /// <param name="pixels1">第一个像素数组</param>
        /// <param name="pixels2">第二个像素数组</param>
        /// <returns>两者之间的偏差</returns>
        double Between(int[] pixels1, int[] pixels2);
    }
}
