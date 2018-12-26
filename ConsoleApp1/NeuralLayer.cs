using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// 基本上是神经元的集合，负责将Pulse（）或ApplyLearning（）命令传递给它的成员神经元。
    /// 这是通过包装List <INeuron>并传递IList <INeuron>方法和属性来实现的
    /// </summary>
    public class NeuralLayer : INeuralLayer
    {
        #region 构造函数
        /// <summary>
        /// 基本上是神经元的集合，负责将Pulse（）或ApplyLearning（）命令传递给它的成员神经元。
        /// </summary>
        public NeuralLayer()
        {
            m_neurons = new List<INeuron>();
        }

        #endregion

        #region 成员变量
        /// <summary>
        /// 神经元（neuron的复数形式）
        /// </summary>
        private List<INeuron> m_neurons;

        #endregion
        #region 属性
        public int Count
        {
            get { return m_neurons.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion
        #region 方法

        public int IndexOf(INeuron item)
        {
            return m_neurons.IndexOf(item);
        }

        public void Insert(int index, INeuron item)
        {
            m_neurons.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            m_neurons.RemoveAt(index);
        }

        public INeuron this[int index]
        {
            get { return m_neurons[index]; }
            set { m_neurons[index] = value; }
        }
        public void Add(INeuron item)
        {
            m_neurons.Add(item);
        }

        public void Clear()
        {
            m_neurons.Clear();
        }

        public bool Contains(INeuron item)
        {
            return m_neurons.Contains(item);
        }

        public void CopyTo(INeuron[] array, int arrayIndex)
        {
            m_neurons.CopyTo(array, arrayIndex);
        }


        public bool Remove(INeuron item)
        {
            return m_neurons.Remove(item);
        }

        public IEnumerator<INeuron> GetEnumerator()
        {
            return m_neurons.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Pulse(INeuralNet net)
        {
            foreach (INeuron n in m_neurons)
                n.Pulse(this);
        }

        public void ApplyLearning(INeuralNet net)
        {
            double learningRate = net.LearningRate;

            foreach (INeuron n in m_neurons)
                n.ApplyLearning(this, ref learningRate);
        }
        /// <summary>
        /// 将所有权重变化设置为零
        /// </summary>
        /// <param name="net">神经网络</param>
        public void InitializeLearning(INeuralNet net)
        {
            foreach (INeuron n in m_neurons)
                n.InitializeLearning(this);
        }

        #endregion
    }

}
