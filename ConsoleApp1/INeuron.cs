using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// 穿过网络神经元的信号
    /// </summary>
    public interface INeuronSignal
    {
        double Output { get; set; }
    }
    /// <summary>
    /// 神经元的输入
    /// </summary>
    public interface INeuronReceptor
    {
        /// <summary>
        /// 神经元的输入由许多其他神经元的输出组成
        /// 键是信号，输出是定义该信号“权重”的类
        /// </summary>
        Dictionary<INeuronSignal, NeuralFactor> Input { get; }
    }
    /// <summary>
    /// 实际的神经元
    /// 每个神经元都是一个受体和一个信号
    /// </summary>
    public interface INeuron:INeuronSignal,INeuronReceptor
    {
        /// <summary>
        /// 处理脉冲的方法。
        /// </summary>
        /// <param name="layer"></param>
        void Pulse(INeuralLayer layer);
        /// <summary>
        /// 应用神经元学习的方法。
        /// </summary>
        /// <param name="layer">神经层</param>
        void ApplyLearning(INeuralLayer layer, ref double learningRate);

        void InitializeLearning(INeuralLayer layer);
        /// <summary>
        /// 偏差
        /// 每个神经元都会有偏见（将其视为另一个输入，但是一个是独立的，而不是来自另一个神经元）
        /// </summary>
        NeuralFactor Bias { get; set; }

        double Error { get; set; }
        double LastError { get; set; }
    }
}
