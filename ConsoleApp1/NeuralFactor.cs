namespace ConsoleApp1
{
    /// <summary>
    /// 跟踪神经元输入的权重和变化
    /// 不仅可以存储信号的权重，还可以存储我们在更新时应用的调整量。
    /// </summary>
    public class NeuralFactor
    {
        #region 构造函数
        /// <summary>
        /// 跟踪神经元输入的权重和变化
        /// 不仅可以存储信号的权重，还可以存储我们在更新时应用的调整量。
        /// </summary>
        public NeuralFactor(double weight)
        {
            m_weight = weight;
            m_lastDelta = m_delta = 0;
        }

        #endregion

        #region 成员变量

        private double m_weight, m_lastDelta, m_delta;

        #endregion

        #region 属性
        /// <summary>
        /// 权重
        /// </summary>
        public double Weight
        {
            get { return m_weight; }
            set { m_weight = value; }
        }
        /// <summary>
        /// H-向量
        /// </summary>
        public double H_Vector
        {
            get { return m_delta; }
            set { m_delta = value; }
        }
        /// <summary>
        /// 最后的H矢量
        /// </summary>
        public double Last_H_Vector
        {
            get { return m_lastDelta; }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 应用权重变化
        /// </summary>
        /// <param name="learningRate">学习率</param>
        public void ApplyWeightChange(ref double learningRate)
        {
            m_lastDelta = m_delta;
            m_weight += m_delta * learningRate;
        }
        /// <summary>
        /// 重置权重变化
        /// </summary>
        public void ResetWeightChange()
        {
            m_lastDelta = m_delta = 0;
        }

        #endregion
    }
}