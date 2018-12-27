using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadesOfGray
{
    //第五步 评估我们模型的质量（交叉验证法）
    /// <summary>
    /// 模型质量评估
    /// </summary>
    public class Evaluator
    {
        /// <summary>
        /// 准确率计算
        /// </summary>
        /// <param name="obs">验证对象</param>
        /// <param name="classifier">分类器</param>
        /// <returns>准确率</returns>
        private static double Score(Observation obs,IClassifier classifier)
        {
            if (classifier.Predict(obs.Pixels) == obs.Label)
                return 1.0;
            else 
                return 0.0;
        }
        /// <summary>
        /// 评估
        /// </summary>
        /// <param name="validataionSet">验证数据集</param>
        /// <param name="classifier">分类器</param>
        /// <returns>平均准确率</returns>
        public static double Correct(IEnumerable<Observation> validataionSet,IClassifier classifier)
        {
            return validataionSet
                .Select(obs => Score(obs, classifier))
                .Average();
        }
        /// <summary>
        /// 评估
        /// </summary>
        /// <param name="validataionSet">验证数据集</param>
        /// <param name="classifier">分类器</param>
        /// <returns>平均准确率</returns>
        public static double Correct(IEnumerable<Observation> validataionSet, FunctionalExample classifier)
        {
            return validataionSet
                .Select(obs => Score(obs, classifier))
                .Average();
        }
        /// <summary>
        /// 准确率计算
        /// </summary>
        /// <param name="obs">验证对象</param>
        /// <param name="classifier">分类器</param>
        /// <returns>准确率</returns>
        private static double Score(Observation obs, FunctionalExample classifier)
        {
            if (classifier.Predict(obs.Pixels) == obs.Label)
                return 1.0;
            else
                return 0.0;
        }
    }
}
