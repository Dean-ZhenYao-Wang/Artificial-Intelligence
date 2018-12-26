using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadesOfGray
{
    /*第二步，让我们添加一个DataReader类，用它读取来自数据文件的观察结果。
     * 我们在这里有两个不同的任务要执行:
     * 从文本文件中提取每一行相关的代码，
     * 并将每一行转换为我们的观察类型。
     * 让我们把它分成两种方法:*/

    public class DataReader
    {
        private static Observation ObservationFactory(string data)
        {
            var commaSeparated = data.Split(',');
            var label = commaSeparated[0];
            var pixels =
                commaSeparated
                .Skip(1)
                .Select(x => Convert.ToInt32(x))
                .ToArray();
            return new Observation(label, pixels);
        }
        /// <summary>
        /// 读取来自数据文件的观察结果
        /// </summary>
        /// <param name="dataPath">数据文件的地址</param>
        /// <returns></returns>
        public static Observation[] GetObservations(string dataPath)
        {
            var data =
                File.ReadAllLines(dataPath)
                .Skip(1)
                .Select(ObservationFactory)
                .ToArray();
            return data;
        }

    }
}
