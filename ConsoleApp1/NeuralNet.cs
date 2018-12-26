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
    public class NeuralNet : INeuralNet
    {
        #region 构造函数
        /// <summary>
        /// 神经网络
        /// </summary>
        public NeuralNet()
        {
            m_learningRate = 0.5;
        }
        #endregion

        #region 成员变量

        private INeuralLayer m_inputLayer;
        private INeuralLayer m_outputLayer;
        private INeuralLayer m_hiddenLayer;
        private double m_learningRate;

        #endregion

        #region 属性
        /// <summary>
        /// 感知层（输入层）
        /// </summary>
        public INeuralLayer PerceptionLayer
        {
            get { return m_inputLayer; }
        }
        /// <summary>
        /// 隐藏层（中间层）
        /// </summary>
        public INeuralLayer HiddenLayer
        {
            get { return m_hiddenLayer; }
        }
        /// <summary>
        /// 输出层
        /// </summary>
        public INeuralLayer OutputLayer
        {
            get { return m_outputLayer; }
        }
        /// <summary>
        /// 学习率
        /// </summary>
        public double LearningRate
        {
            get { return m_learningRate; }
            set { m_learningRate = value; }
        }
        /// <summary>
        /// 只是将命令传递给每一层，然后将它们传递给神经元
        /// </summary>
        public void Pulse()
        {
            lock (this)
            {
                m_hiddenLayer.Pulse(this);
                m_outputLayer.Pulse(this);
            }
        }
        /// <summary>
        /// 只是将命令传递给每一层，然后将它们传递给神经元
        /// </summary>
        public void ApplyLearning()
        {
            lock (this)
            {
                m_hiddenLayer.ApplyLearning(this);
                m_outputLayer.ApplyLearning(this);
            }
        }
        /// <summary>
        /// 初始化学习 将所有权重变化设置为零
        /// </summary>
        public void InitializeLearning()
        {
            lock (this)
            {
                m_hiddenLayer.InitializeLearning(this);
                m_outputLayer.InitializeLearning(this);
            }
        }
        /// <summary>
        /// 应用输入，脉冲网络，并执行学习所需的反向传播。
        /// </summary>
        /// <param name="inputs">输入</param>
        /// <param name="expected">预期</param>
        /// <param name="type">类型</param>
        /// <param name="iterations">迭代次数</param>
        public void Train(double[][] inputs, double[][] expected, TrainingType type, int iterations)
        {
            int i, j;

            switch (type)
            {
                case TrainingType.BackPropogation:

                    lock (this)
                    {

                        for (i = 0; i < iterations; i++)
                        {

                            InitializeLearning(); // 将所有权重变化设置为零

                            for (j = 0; j < inputs.Length; j++)
                                BackPropogation_TrainingSession(this, inputs[j], expected[j]);

                            ApplyLearning(); // 应用一批累计权重变化
                        }

                    }
                    break;
                default:
                    throw new ArgumentException("Unexpected TrainingType");//意外训练类型
            }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 初始化
        /// 负责构建神经网络的所有组件并进行连接
        /// </summary>
        /// <param name="randomSeed">随机数生成器的种子用来构建我们的神经元的NeuralFactors</param>
        /// <param name="inputNeuronCount">输入神经元的数量</param>
        /// <param name="hiddenNeuronCount">隐藏神经元的数量</param>
        /// <param name="outputNeuronCount">输出神经元的数量</param>
        public void Initialize(int randomSeed,
            int inputNeuronCount, int hiddenNeuronCount, int outputNeuronCount)
        {
            Initialize(this, randomSeed, inputNeuronCount, hiddenNeuronCount, outputNeuronCount);
        }

        public void PreparePerceptionLayerForPulse(double[] input)
        {
            PreparePerceptionLayerForPulse(this, input);
        }

        #region 专用静态实用方法
        /// <summary>
        /// 初始化
        /// 负责构建神经网络的所有组件并进行连接
        /// </summary>
        /// <param name="net"></param>
        /// <param name="randomSeed">随机数生成器的种子用来构建我们的神经元的NeuralFactors</param>
        /// <param name="inputNeuronCount">输入神经元的数量</param>
        /// <param name="hiddenNeuronCount">隐藏神经元的数量</param>
        /// <param name="outputNeuronCount">输出神经元的数量</param>
        private static void Initialize(NeuralNet net, int randomSeed,
            int inputNeuronCount, int hiddenNeuronCount, int outputNeuronCount)
        {

            #region 声明

            int i, j;
            Random rand;

            #endregion

            #region 初始化

            rand = new Random(randomSeed);

            #endregion

            #region 执行

            net.m_inputLayer = new NeuralLayer();
            net.m_outputLayer = new NeuralLayer();
            net.m_hiddenLayer = new NeuralLayer();

            for (i = 0; i < inputNeuronCount; i++)
                net.m_inputLayer.Add(new Neuron(0));

            for (i = 0; i < outputNeuronCount; i++)
                net.m_outputLayer.Add(new Neuron(rand.NextDouble()));

            for (i = 0; i < hiddenNeuronCount; i++)
                net.m_hiddenLayer.Add(new Neuron(rand.NextDouble()));

            // 将输入层连接到隐藏层
            for (i = 0; i < net.m_hiddenLayer.Count; i++)
                for (j = 0; j < net.m_inputLayer.Count; j++)
                    net.m_hiddenLayer[i].Input.Add(net.m_inputLayer[j], new NeuralFactor(rand.NextDouble()));

            // 将输出层连接到隐藏层
            for (i = 0; i < net.m_outputLayer.Count; i++)
                for (j = 0; j < net.m_hiddenLayer.Count; j++)
                    net.m_outputLayer[i].Input.Add(net.HiddenLayer[j], new NeuralFactor(rand.NextDouble()));

            #endregion
        }
        /// <summary>
        /// 计算隐藏层神经元上的错误
        /// 计算方式：计算我们期望（作为参数传递）与神经元的实际输出之间的差异来计算输出神经元上的误差
        /// </summary>
        /// <param name="net"></param>
        /// <param name="desiredResults"></param>
        private static void CalculateErrors(NeuralNet net, double[] desiredResults)
        {
            #region 声明

            int i, j;
            double temp, error;
            INeuron outputNode, hiddenNode;

            #endregion

            #region 执行

            // 计算输出误差值
            for (i = 0; i < net.m_outputLayer.Count; i++)
            {
                outputNode = net.m_outputLayer[i];
                temp = outputNode.Output;

                outputNode.Error = (desiredResults[i] - temp) * SigmoidDerivative(temp); //* temp * (1.0F - temp);
            }

            // 计算隐藏层误差值
            for (i = 0; i < net.m_hiddenLayer.Count; i++)
            {
                hiddenNode = net.m_hiddenLayer[i];
                temp = hiddenNode.Output;

                error = 0;
                for (j = 0; j < net.m_outputLayer.Count; j++)
                {
                    outputNode = net.m_outputLayer[j];
                    error += (outputNode.Error * outputNode.Input[hiddenNode].Weight) * SigmoidDerivative(temp);// *(1.0F - temp);                   
                }

                hiddenNode.Error = error;

            }

            #endregion
        }

        private static double SigmoidDerivative(double value)
        {
            return value * (1.0F - value);
        }
        /// <summary>
        /// 计算我们期望（作为参数传递）与神经元的实际输出之间的差异来计算输出神经元上的误差
        /// </summary>
        /// <param name="net"></param>
        /// <param name="input"></param>
        public static void PreparePerceptionLayerForPulse(NeuralNet net, double[] input)
        {
            #region 声明

            int i;

            #endregion

            #region 执行

            if (input.Length != net.m_inputLayer.Count)
                //期望这个网络的{0}输入
                throw new ArgumentException(string.Format("Expecting {0} inputs for this net", net.m_inputLayer.Count));

            // 初始化数据
            for (i = 0; i < net.m_inputLayer.Count; i++)
                net.m_inputLayer[i].Output = input[i];

            #endregion

        }
        /// <summary>
        /// 更新每个神经元输入的调整后的权重以及偏差乘以m_learningRate参数
        /// </summary>
        /// <param name="net"></param>
        public static void CalculateAndAppendTransformation(NeuralNet net)
        {
            #region 声明

            int i, j;
            INeuron outputNode, inputNode, hiddenNode;

            #endregion

            #region 执行

            // 调整输出层权重变化
            for (j = 0; j < net.m_outputLayer.Count; j++)
            {
                outputNode = net.m_outputLayer[j];

                for (i = 0; i < net.m_hiddenLayer.Count; i++)
                {
                    hiddenNode = net.m_hiddenLayer[i];
                    outputNode.Input[hiddenNode].H_Vector += outputNode.Error * hiddenNode.Output;
                }

                outputNode.Bias.H_Vector += outputNode.Error * outputNode.Bias.Weight;
            }

            // 调整隐藏层权重变化
            for (j = 0; j < net.m_hiddenLayer.Count; j++)
            {
                hiddenNode = net.m_hiddenLayer[j];

                for (i = 0; i < net.m_inputLayer.Count; i++)
                {
                    inputNode = net.m_inputLayer[i];
                    hiddenNode.Input[inputNode].H_Vector += hiddenNode.Error * inputNode.Output;
                }

                hiddenNode.Bias.H_Vector += hiddenNode.Error * hiddenNode.Bias.Weight;
            }

            #endregion
        }


        #region 反向传播
        /// <summary>
        /// 这是大部分处理发生的地方。
        /// </summary>
        /// <param name="net"></param>
        /// <param name="input"></param>
        /// <param name="desiredResult"></param>
        public static void BackPropogation_TrainingSession(NeuralNet net, double[] input, double[] desiredResult)
        {
            PreparePerceptionLayerForPulse(net, input);
            net.Pulse();
            CalculateErrors(net, desiredResult);
            CalculateAndAppendTransformation(net);
        }

        #endregion

        #endregion 专用静态实用方法


        #endregion


    }
}
