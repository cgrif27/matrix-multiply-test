/*
  Copyright (c) 2016 Tanay PrabhuDesai, Sameer Jain, Akshaya Prabhu Salgaonkar
  
  Permission is hereby granted, free of charge, to any person obtaining a copy
  of this software and associated documentation files (the "Software"), to deal
  in the Software without restriction, including without limitation the rights
  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
  copies of the Software, and to permit persons to whom the Software is
  furnished to do so, subject to the following conditions:
  
  The above copyright notice and this permission notice shall be included in
  all copies or substantial portions of the Software.
  
  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
  THE SOFTWARE.
*/
using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
//using Aneka;
//using Aneka.Entity;
//using Aneka.Threading;
//using Aneka.Tasks;

namespace Test
{

	class MainClass
	{

		static double[][] MatrixCreate(int rows, int cols)
		{
			var rnd = new Random();
			// do error checking here
			double[][] result = new double[rows][];
			for (int i = 0; i < rows; ++i)
				result[i] = new double[cols];
			return result;
		}

		static double[][] MatrixProduct(double[][] matrixA, double[][] matrixB)
		{
			int aRows = matrixA.Length; int aCols = matrixA[0].Length;
			int bRows = matrixB.Length; int bCols = matrixB[0].Length;
			if (aCols != bRows)
				throw new Exception("xxx");

			double[][] result = MatrixCreate(aRows, bCols);

			for (int i = 0; i < aRows; ++i) // each row of A
				for (int j = 0; j < bCols; ++j) // each col of B
					for (int k = 0; k < aCols; ++k) // could use k < bRows
						result[i][j] += matrixA[i][k] * matrixB[k][j];
			return result;
		}

		static double[][] MatrixProductSeq(double[][] matrixA, double[][] matrixB)
		{
			int aRows = matrixA.Length; int aCols = matrixA[0].Length;
			int bRows = matrixB.Length; int bCols = matrixB[0].Length;
			if (aCols != bRows)
				throw new Exception("xxx");

			double[][] result = MatrixCreate(aRows, bCols);

			for (int i = 0; i < aRows; ++i) // each row of A
				for (int j = 0; j < bCols; ++j) // each col of B
					for (int k = 0; k < aCols; ++k) // could use k < bRows
						result[i][j] += matrixA[i][k] * matrixB[k][j];
			return result;
		}

		public static void Main(string[] args)
		{
			var matrix = MatrixCreate(900, 500);
			var matrix2 = MatrixCreate(500, 900);

			var s = new Stopwatch();

            Console.WriteLine("Starting to run");

			s.Start();

			var product = MatrixProduct(matrix, matrix2);


			s.Stop();

            Console.WriteLine(s.ElapsedMilliseconds);

			var s2 = new Stopwatch();

			Console.WriteLine("Starting to run");

			s2.Start();

			var productSeq = MatrixProductSeq(matrix, matrix2);


			s2.Stop();

			Console.WriteLine(s2.ElapsedMilliseconds);

            Console.WriteLine(product.SequenceEqual(productSeq));

		}
	}
}