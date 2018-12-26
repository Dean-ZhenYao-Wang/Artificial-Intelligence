using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// 神经网络
    /// </summary>
    public interface INeuralNet
    {
        /// <summary>
        /// 感知层（输入层）
        /// </summary>
        INeuralLayer PerceptionLayer { get; }
        /// <summary>
        /// 隐藏层（中间层）
        /// </summary>
        INeuralLayer HiddenLayer { get; }
        /// <summary>
        /// 输出层
        /// </summary>
        INeuralLayer OutputLayer { get; }
        /// <summary>
        /// 学习率
        /// </summary>
        double LearningRate { get; set; }
        /// <summary>
        /// 脉冲
        /// </summary>
        void Pulse();
        /// <summary>
        /// 将脉冲应用到整个神经网络（将命令传递给每个层，然后将命令传递给层中的每个神经元）
        /// </summary>
        void ApplyLearning();
        /// <summary>
        /// 初始学习
        /// </summary>
        void InitializeLearning();
    }
}
