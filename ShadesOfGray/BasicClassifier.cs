using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadesOfGray
{
    //第三步 训练分类器
    //第四步 识别图像进行标签预测

    /// <summary>
    /// 分类器
    /// </summary>
    public class BasicClassifier : IClassifier
    {
        private IEnumerable<Observation> data;
        private readonly IDistance distance;
        /// <summary>
        /// 分类器 构造函数
        /// </summary>
        /// <param name="distance">偏差计算接口</param>
        public BasicClassifier(IDistance distance)
        {
            this.distance = distance;
        }
        /// <summary>
        /// 训练
        /// </summary>
        /// <param name="trainingSet">训练数据集</param>
        public void Train(IEnumerable<Observation> trainingSet)
        {
            this.data = trainingSet;
        }
        /// <summary>
        /// 预测
        /// </summary>
        /// <param name="pixels">待识别图像的灰度像素组</param>
        /// <returns>预测出的标签</returns>
        public string Predict(int[] pixels)
        {
            Observation currentBest = null;
            var shortest = Double.MaxValue;
            foreach (Observation obs in this.data)
            {
                var dist = this.distance.Between(obs.Pixels, pixels);
                if (dist < shortest)
                {
                    shortest = dist;
                    currentBest = obs;
                }
            }
            return currentBest.Label;
        }
    }
}
