using System.Collections.Generic;

namespace ConsoleApp1
{
    /// <summary>
    /// 神经层
    /// 这将用于传递脉冲或将学习命令应用于层中的每个神经元
    /// </summary>
    public interface INeuralLayer : IList<INeuron>
    {
        /// <summary>
        /// 传递脉冲
        /// </summary>
        /// <param name="net">神经网络</param>
        void Pulse(INeuralNet net);
        /// <summary>
        /// 将学习命令应用于层中的每个神经元
        /// </summary>
        /// <param name="net">神经网络</param>
        void ApplyLearning(INeuralNet net);
        /// <summary>
        /// 初始化学习
        /// </summary>
        /// <param name="net">神经网络</param>
        void InitializeLearning(INeuralNet net);
    }
}