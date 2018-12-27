using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadesOfGray
{
    /// <summary>
    /// 距离函数 分类器
    /// </summary>
    public class FunctionalExample
    {
        private IEnumerable<Observation> data;
        private readonly Func<int[], int[], int> distance;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="distance">距离函数</param>
        public FunctionalExample(Func<int[],int[],int> distance)
        {
            this.distance = distance;
        }
        public Func<int[],int[],int> Distance
        {
            get { return this.distance; }
        }

        public void Train(IEnumerable<Observation> trainingSet)
        {
            this.data = trainingSet;
        }
        public string Predict(int[] pixels)
        {
            Observation currentBest = null;
            var shortest = double.MaxValue;
            foreach(Observation obs in this.data)
            {
                var dist = this.Distance(obs.Pixels, pixels);
                if(dist<shortest)
                {
                    shortest = dist;
                    currentBest = obs;
                }
            }
            return currentBest.Label;
        }
    }
}
