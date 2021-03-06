﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadesOfGray
{
    /// <summary>
    /// 偏差计算实现类
    /// </summary>
    public class ManhattanDistance : IDistance
    {
        /// <summary>
        /// 计算两个曼哈顿图像之间的偏差
        /// </summary>
        /// <param name="pixels1">第一个图像的像素组</param>
        /// <param name="pixels2">第二个图像的像素组</param>
        /// <returns>偏差值；偏差值越小两者越接近</returns>
        public double Between(int[] pixels1, int[] pixels2)
        {
            if (pixels1.Length != pixels2.Length)
            {
                throw new ArgumentException("图片大小不一致。");
            }
            var length = pixels1.Length;
            var distance = 0;
            for (int i = 0; i < length; i++)
            {
                // = OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO.                          ,OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO ^ 
                // =@@@@@@@@@@@@@@@@@@@@@@O.................... = O.                          = O ^ ...................= O@@@@@@@@@@@@@@@@@@@@@O ^
                // =@@@@@@@@@@@@@@@@@@@@@@O.                   \O.                          = O ^                   = O@@@@@@@@@@@@@@@@@@@@@O ^
                // =@@@@@@@@@@@@@@@@@@@@@@O.                   = O.                          = O ^                   = O@@@@@@@@@@@@@@@@@@@@@O ^
                // =@@@@@@@@@@@@@@@@@@@@@@O.                   = O.                          = O ^                   = O@@@@@@@@@@@@@@@@@@@@@O ^
                // =@@@@@@@@@@@@@@@@@@@@@@O.                   = O.                          = O ^                   = O@@@@@@@@@@@@@@@@@@@@@O ^
                // =@@@@@@@@@@@@@@@@@@@@@@O.                   = O.                          = O ^                   = O@@@@@@@@@@@@@@@@@@@@@O ^
                // =@@@@@@@@@@@@@@@@@@@@@@O.                   = O.                          = O ^                   = O@@@@@@@@@@@@@@@@@@@@@O ^
                // =@@@@@@@@@@@@@@@@@@@@@@O.                   / O.                          = O ^                   = O@@@@@@@@@@@@@@@@@@@@@O ^
                // =@@@@@@@@@@@@@@@@@@@@@@O.                   \O.                          = O ^                   = O@@@@@@@@@@@@@@@@@@@@@O ^
                // =@@@@@@@@@@@@@@@@@@@@@@O`.................../ O.                          = O ^ ...................= O@@@@@@@@@@@@@@@@@@@@@O ^
                // = O /[[[[[[[[[[[[[[[[[[[O@@@@@@@@@@@@@@@@@@@@@@O.                          = O@@@@@@@@@@@@@@@@@@@@@O /[[[[[[[[[[[[[[[[[[[OO ^
                // = O.                  .=@@@@@@@@@@@@@@@@@@@@@@O.                          = O@@@@@@@@@@@@@@@@@@@@@@^.                  = O ^
                // = O.                  .=@@@@@@@@@@@@@@@@@@@@@@O.                          = O@@@@@@@@@@@@@@@@@@@@@@^.                  = O ^
                // = O.                  .=@@@@@@@@@@@@@@@@@@@@@@O.                          = O@@@@@@@@@@@@@@@@@@@@@@^.                  = O ^
                // = O.                  .=@@@@@@@@@@@@@@@@@@@@@@O.                          = O@@@@@@@@@@@@@@@@@@@@@@^.                  = O ^
                // = O.                  .=@@@@@@@@@@@@@@@@@@@@@@O.                          = O@@@@@@@@@@@@@@@@@@@@@@^.                  = O ^
                // = O.                  .=@@@@@@@@@@@@@@@@@@@@@@O.                          = O@@@@@@@@@@@@@@@@@@@@@@^.                  = O ^
                // = O.                  .=@@@@@@@@@@@@@@@@@@@@@@O.                          = O@@@@@@@@@@@@@@@@@@@@@@^.                  = O ^
                // = O.                  .=@@@@@@@@@@@@@@@@@@@@@@O.                          = O@@@@@@@@@@@@@@@@@@@@@@^.                  = O ^
                // = O.                  .=@@@@@@@@@@@@@@@@@@@@@@O.                          = O@@@@@@@@@@@@@@@@@@@@@@^.                  = O ^
                // = OOOOOOOOOOOOOOOOOOOOOO@@@@@@@@@@@@@@@@@@@@@@O.                          = O@@@@@@@@@@@@@@@@@@@@@@OOOOOOOOOOOOOOOOOOOOOO ^
                // ...............................................                          ...............................................                           

                //上图解释了为何此处要使用绝对值
                distance += Math.Abs(pixels1[i] - pixels2[i]);
            }

            return distance;
        }
    }
}
