using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region 成员变量

        private NeuralNet net;
        double high, mid, low;

        #endregion
       
        public Form1()
        {
            InitializeComponent();
            high = .99;
            low = .01;
            mid = .5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 声明

            double ll, lh, hl, hh;
            int count, iterations;
            bool verbose;
            double[][] input, output;
            StringBuilder bld;

            #endregion
            #region 初始化

            net = new NeuralNet();
            bld = new StringBuilder();

            input = new double[4][];
            input[0] = new double[] { high, high };
            input[1] = new double[] { low, high };
            input[2] = new double[] { high, low };
            input[3] = new double[] { low, low };

            output = new double[4][];
            output[0] = new double[] { low };
            output[1] = new double[] { high };
            output[2] = new double[] { high };
            output[3] = new double[] { low };

            verbose = false;
            count = 0;
            iterations = 5;

            #endregion
            #region 执行

            // 初始化与
            //   2 感觉神经元
            //   2 隐层神经元
            //   1 输出神经元
            net.Initialize(1, 2, 2, 1);

            do
            {
                count++;

                net.LearningRate = 3;
                net.Train(input, output, TrainingType.BackPropogation, iterations);

                net.PerceptionLayer[0].Output = low;
                net.PerceptionLayer[1].Output = low;

                net.Pulse();

                ll = net.OutputLayer[0].Output;

                net.PerceptionLayer[0].Output = high;
                net.PerceptionLayer[1].Output = low;

                net.Pulse();

                hl = net.OutputLayer[0].Output;

                net.PerceptionLayer[0].Output = low;
                net.PerceptionLayer[1].Output = high;

                net.Pulse();

                lh = net.OutputLayer[0].Output;

                net.PerceptionLayer[0].Output = high;
                net.PerceptionLayer[1].Output = high;

                net.Pulse();

                hh = net.OutputLayer[0].Output;

                #region verbose

                if (verbose)
                {
                    bld.Remove(0, bld.Length);

                    bld.Append("感觉神经元 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
                    foreach (Neuron pn in net.PerceptionLayer)
                        AppendNeuronInfo(bld, pn);

                    bld.Append("\n隐层神经元 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
                    foreach (Neuron hn in net.HiddenLayer)
                        AppendNeuronInfo(bld, hn);

                    bld.Append("\n输出神经元 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
                    foreach (Neuron on in net.OutputLayer)
                        AppendNeuronInfo(bld, on);

                    bld.Append("\n");

                    bld.Append("hh: \t").Append(hh.ToString()).Append(" \t< .5\n");
                    bld.Append("ll: \t").Append(ll.ToString()).Append(" \t< .5\n");

                    bld.Append("hl: \t").Append(hl.ToString()).Append(" \t> .5\n");
                    bld.Append("lh: \t").Append(lh.ToString()).Append(" \t> .5\n");

                    MessageBox.Show(bld.ToString());
                }

                #endregion
            }
            // 真的很好地训练了这件事…
            while (hh > (mid + low) / 2
                || lh < (mid + high) / 2
                || hl < (mid + low) / 2
                || ll > (mid + high) / 2);


            net.PerceptionLayer[0].Output = low;
            net.PerceptionLayer[1].Output = low;

            net.Pulse();

            ll = net.OutputLayer[0].Output;

            net.PerceptionLayer[0].Output = high;
            net.PerceptionLayer[1].Output = low;

            net.Pulse();

            hl = net.OutputLayer[0].Output;

            net.PerceptionLayer[0].Output = low;
            net.PerceptionLayer[1].Output = high;

            net.Pulse();

            lh = net.OutputLayer[0].Output;

            net.PerceptionLayer[0].Output = high;
            net.PerceptionLayer[1].Output = high;

            net.Pulse();

            hh = net.OutputLayer[0].Output;

            bld.Remove(0, bld.Length);
            bld.Append((count * iterations).ToString()).Append(" 训练所需的迭代\n");

            bld.Append("hh: ").Append(hh.ToString()).Append(" < .5\n");
            bld.Append("ll: ").Append(ll.ToString()).Append(" < .5\n");

            bld.Append("hl: ").Append(hl.ToString()).Append(" > .5\n");
            bld.Append("lh: ").Append(lh.ToString()).Append(" > .5\n");

            MessageBox.Show(bld.ToString());

            #endregion
        }
        private void button2_Click(object sender, EventArgs e)
        {
            #region 声明

            bool result, verbose;
            StringBuilder bld;

            #endregion

            #region 初始化

            verbose = true;
            bld = new StringBuilder();

            #endregion

            #region 执行

            net.PerceptionLayer[0].Output = (ckA.Checked) ? high : low;
            net.PerceptionLayer[1].Output = (ckB.Checked) ? high : low;
            net.Pulse();
            result = net.OutputLayer[0].Output > .5;

            #region verbose

            if (verbose)
            {
                bld.Remove(0, bld.Length);

                bld.Append("感觉神经元 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
                foreach (Neuron pn in net.PerceptionLayer)
                    AppendNeuronInfo(bld, pn);

                bld.Append("\n隐层神经元 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
                foreach (Neuron hn in net.HiddenLayer)
                    AppendNeuronInfo(bld, hn);

                bld.Append("\n输出神经元 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n");
                foreach (Neuron on in net.OutputLayer)
                    AppendNeuronInfo(bld, on);

                bld.Append("\n");

                MessageBox.Show(bld.ToString());
            }

            #endregion

            lblResult.Text = result.ToString();

            #endregion
        }
        private static void AppendNeuronInfo(StringBuilder bld, INeuron neuron)
        {
            #region 声明

            int i;
            double value;

            #endregion

            #region 初始化

            i = 1;
            value = 0;

            #endregion

            #region 执行

            bld.Append("========== 神经元 ========== \n");
            bld.Append(" 输出\t: ").Append(neuron.Output.ToString()).Append("\n");
            bld.Append(" 错误\t: ").Append(neuron.Error.ToString());
            bld.Append("\t 上一错误:\t").Append(neuron.LastError.ToString()).Append("\n");
            //bld.Append(" bias value \t: ").Append(neuron.BiasValue.ToString()).Append("\n");
            bld.Append(" 偏差\t: ").Append(neuron.Bias.Weight.ToString()).Append("\n\n");



            foreach (KeyValuePair<INeuronSignal, NeuralFactor> f in neuron.Input)
            {
                bld.Append("输入 ").Append(i++.ToString()).Append(" 值= ").Append(f.Key.Output.ToString()); //.Append("\n");
                bld.Append("  \t权重 = ").Append(f.Value.Weight).Append("\n");


                value += f.Value.Weight * f.Key.Output;
                //bld.Append("\tSig(").Append((f.Key.Output * f.Value.Weight).ToString()).Append(")=").Append(Neuron.Sigmoid(f.Value.Weight + )).Append("\n");
            }

            bld.Append("上层的偏差 = ").Append(neuron.Bias.Weight).Append("\n");
            bld.Append("S形=").Append(Neuron.Sigmoid(value + neuron.Bias.Weight)).Append("\n");
            bld.Append("============================ \n\n");

            #endregion


        }
    }
}
