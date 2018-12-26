using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadesOfGray
{
    /// <summary>
    /// 分类器
    /// </summary>
    public interface IClassifier
    {
        /// <summary>
        /// 训练
        /// </summary>
        /// <param name="trainingSet">训练数据集</param>
        void Train(IEnumerable<Observation> trainingSet);
        /// <summary>
        /// 预测图像的标签
        /// </summary>
        /// <param name="pixels">待识别图像的灰度像素组</param>
        /// <returns>预测出的标签</returns>
        string Predict(int[] pixels);
    }
}
