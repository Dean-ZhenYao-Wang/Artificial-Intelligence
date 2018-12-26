using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// 神经元
    /// </summary>
    public class Neuron : INeuron
    {
        #region 构造函数
        /// <summary>
        /// 神经元
        /// </summary>
        /// <param name="bias"></param>
        public Neuron(double bias)
        {
            m_bias = new NeuralFactor(bias);
            m_error = 0;
            m_input = new Dictionary<INeuronSignal, NeuralFactor>();
        }

        #endregion

        #region 成员变量

        private Dictionary<INeuronSignal, NeuralFactor> m_input;
        double m_output, m_error, m_lastError;
        /// <summary>
        /// 偏差
        /// 每个神经元都会有偏见（将其视为另一个输入，但是一个是独立的，而不是来自另一个神经元）
        /// </summary>
        NeuralFactor m_bias;

        #endregion

        #region 属性

        public double Output
        {
            get { return m_output; }
            set { m_output = value; }
        }
        /// <summary>
        /// 神经元的输入由许多其他神经元的输出组成
        /// 键是信号，输出是定义该信号“权重”的类
        /// </summary>
        public Dictionary<INeuronSignal, NeuralFactor> Input
        {
            get { return m_input; }
        }
        /// <summary>
        /// 偏差
        /// 每个神经元都会有偏见（将其视为另一个输入，但是一个是独立的，而不是来自另一个神经元）
        /// </summary>
        public NeuralFactor Bias
        {
            get { return m_bias; }
            set { m_bias = value; }
        }
        public double Error
        {
            get { return m_error; }
            set
            {
                m_lastError = m_error;
                m_error = value;
            }
        }
        public double LastError
        {
            get { return m_lastError; }
            set { m_lastError = value; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取每个输入的值（或每个神经元的输出将信息传递给该神经元）的总和乘以字典中包含的相应权重。
        /// 然后将偏差乘以偏差权重。最终输出由前面讨论的S形曲线“压扁”，
        /// 结果存储在m_output变量中
        /// </summary>
        /// <param name="layer"></param>
        public void Pulse(INeuralLayer layer)
        {
            lock (this)
            {
                m_output = 0;

                foreach (KeyValuePair<INeuronSignal, NeuralFactor> item in m_input)
                    m_output += item.Key.Output * item.Value.Weight;

                m_output += m_bias.Weight;

                m_output = Sigmoid(m_output);
            }
        }
        /// <summary>
        /// 应用神经元学习的方法。
        /// </summary>
        /// <param name="layer"></param>
        public void ApplyLearning(INeuralLayer layer, ref double learningRate)
        {
            foreach (KeyValuePair<INeuronSignal, NeuralFactor> m in m_input)
                m.Value.ApplyWeightChange(ref learningRate);

            m_bias.ApplyWeightChange(ref learningRate);
        }
        /// <summary>
        /// 初始化学习
        /// </summary>
        /// <param name="layer"></param>
        public void InitializeLearning(INeuralLayer layer)
        {
            foreach (KeyValuePair<INeuronSignal, NeuralFactor> m in m_input)
                m.Value.ResetWeightChange();

            m_bias.ResetWeightChange();
        }
        #endregion

        #region 专用静态实用方法
        /// <summary>
        /// 使用Sigmoid曲线将神经元的输出压缩到0和1之间的值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Sigmoid(double value)
        {
            return 1 / (1 + Math.Exp(-value));
        }

        #endregion
    }
}
