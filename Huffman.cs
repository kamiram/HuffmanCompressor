﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCompressor
{
    class Huffman
    {
		// принципиальный максимум узлов.
		private const int MAX_TREE_NODES = 511;
		
		// адаптер для записи побитово
		public class BitStream
		{
			public byte[] BytePointer;
			public uint BitPosition;
			public uint Index;
		}
		
		// Структура символа - содержит его частоту, битовую запись в архиве длину.
		public struct Symbol
		{
			public int Sym;
			public uint Count;
			public uint Code;
			public uint Bits;
		}

		// Структура для дерева словаря
		public class Node
		{
			public Node ChildA;
			public Node ChildB;
			public int Count;
			public int Symbol;
		}

		private static void initBitstream(ref BitStream stream, byte[] buffer)
		{
			stream.BytePointer = buffer;
			stream.BitPosition = 0;
		}

		private static void writeBits(ref BitStream stream, uint x, uint bits)
		{
			byte[] buffer = stream.BytePointer;
			uint bit = stream.BitPosition;
			uint mask = (uint)(1 << (int)(bits - 1));

			for (uint count = 0; count < bits; ++count)
			{
				buffer[stream.Index] = (byte)((buffer[stream.Index] & (0xff ^ (1 << (int)(7 - bit)))) + ((Convert.ToBoolean(x & mask) ? 1 : 0) << (int)(7 - bit)));
				x <<= 1;
				bit = (bit + 1) & 7;

				if (!Convert.ToBoolean(bit))
				{
					++stream.Index;
				}
			}

			stream.BytePointer = buffer;
			stream.BitPosition = bit;
		}

		// строим масив всех байт и считаем их частоту
		private static void histogram(byte[] input, Symbol[] sym, uint size)
		{
			int i;
			int index = 0;

			for (i = 0; i < 256; ++i)
			{
				sym[i].Sym = i;
				sym[i].Count = 0;
				sym[i].Code = 0;
				sym[i].Bits = 0;
			}

			for (i = (int)size; Convert.ToBoolean(i); --i, ++index)
			{
				sym[input[index]].Count++;
			}
		}

		// создаем дерево. работает рекурсивно
		private static void storeTree(ref Node node, Symbol[] sym, ref BitStream stream, uint code, uint bits)
		{
			uint symbolIndex;

			if (node.Symbol >= 0)
			{
				writeBits(ref stream, 1, 1);
				writeBits(ref stream, (uint)node.Symbol, 8);

				for (symbolIndex = 0; symbolIndex < 256; ++symbolIndex)
				{
					if (sym[symbolIndex].Sym == node.Symbol)
						break;
				}

				sym[symbolIndex].Code = code;
				sym[symbolIndex].Bits = bits;
				return;
			}
			else
			{
				writeBits(ref stream, 0, 1);
			}
			// вот тут рекурсивно начинаем строить левое и правое дерево
			storeTree(ref node.ChildA, sym, ref stream, (code << 1) + 0, bits + 1);
			storeTree(ref node.ChildB, sym, ref stream, (code << 1) + 1, bits + 1);
		}

		// начало строительства дерева
		private static void makeTree(Symbol[] sym, ref BitStream stream)
		{
			Node[] nodes = new Node[MAX_TREE_NODES];

			for (int counter = 0; counter < nodes.Length; ++counter)
			{
				nodes[counter] = new Node();
			}

			Node node1, node2, root;
			uint i, numSymbols = 0, nodesLeft, nextIndex;
			
			// создаем все узлы. пока неструктурированные.
			for (i = 0; i < 256; ++i)
			{
				if (sym[i].Count > 0)
				{
					nodes[numSymbols].Symbol = sym[i].Sym;
					nodes[numSymbols].Count = (int)sym[i].Count;
					nodes[numSymbols].ChildA = null;
					nodes[numSymbols].ChildB = null;
					++numSymbols;
				}
			}

			root = null;
			nodesLeft = numSymbols;
			nextIndex = numSymbols;
			// начинаем структурировать
			while (nodesLeft > 1)
			{
				node1 = null;
				node2 = null;

				for (i = 0; i < nextIndex; ++i)
				{
					if (nodes[i].Count > 0)
					{
						if (node1 == null || (nodes[i].Count <= node1.Count))
						{
							node2 = node1;
							node1 = nodes[i];
						}
						else if (node2 == null || (nodes[i].Count <= node2.Count))
						{
							node2 = nodes[i];
						}
					}
				}

				root = nodes[nextIndex];
				root.ChildA = node1;
				root.ChildB = node2;
				root.Count = node1.Count + node2.Count;
				root.Symbol = -1;
				node1.Count = 0;
				node2.Count = 0;
				++nextIndex;
				--nodesLeft;
			}
			// строим полноценное бинарное дерево
			if (root != null)
			{
				storeTree(ref root, sym, ref stream, 0, 0);
			}
			else
			{
				root = nodes[0];
				storeTree(ref root, sym, ref stream, 0, 1);
			}
		}

		// Архивация
		public static int Compress(byte[] input, byte[] output, uint inputSize)
		{
			Symbol[] sym = new Symbol[256];
			Symbol temp;
			BitStream stream = new BitStream();
			uint i, totalBytes, swaps, symbol;

			if (inputSize < 1)
				return 0;

			initBitstream(ref stream, output);
			histogram(input, sym, inputSize);
			makeTree(sym, ref stream);

			// сортировка символов по частоте
			do
			{
				swaps = 0;

				for (i = 0; i < 255; ++i)
				{
					if (sym[i].Sym > sym[i + 1].Sym)
					{
						temp = sym[i];
						sym[i] = sym[i + 1];
						sym[i + 1] = temp;
						swaps = 1;
					}
				}
			} while (Convert.ToBoolean(swaps));

			// пишем данные в виде последовательности бит
			// это я уже описал.
			// сама идея алгоритма в том что чатые символы записываются короткой последовательностью а редкие длинной
			for (i = 0; i < inputSize; ++i)
			{
				symbol = input[i];
				writeBits(ref stream, sym[symbol].Code, sym[symbol].Bits);
			}

			totalBytes = stream.Index;
			// учитываем последний неполный байт
			if (stream.BitPosition > 0)
			{
				++totalBytes;
			}

			return (int)totalBytes;
		}

		private static uint readBit(ref BitStream stream)
		{
			byte[] buffer = stream.BytePointer;
			uint bit = stream.BitPosition;

			uint x = (uint)(Convert.ToBoolean((buffer[stream.Index] & (1 << (int)(7 - bit)))) ? 1 : 0);
			bit = (bit + 1) & 7;

			if (!Convert.ToBoolean(bit))
			{
				++stream.Index;
			}

			stream.BitPosition = bit;

			return x;
		}

		private static uint read8Bits(ref BitStream stream)
		{
			byte[] buffer = stream.BytePointer;
			uint bit = stream.BitPosition;
			uint x = (uint)((buffer[stream.Index] << (int)bit) | (buffer[stream.Index + 1] >> (int)(8 - bit)));
			++stream.Index;

			return x;
		}

		// Востанавливаем деревоиз сохраненной таблицы символов
		private static Node recoverTree(Node[] nodes, ref BitStream stream, ref uint nodenum)
		{
			Node thisNode;

			thisNode = nodes[nodenum];
			nodenum = nodenum + 1;
			thisNode.Symbol = -1;
			thisNode.ChildA = null;
			thisNode.ChildB = null;

			if (Convert.ToBoolean(readBit(ref stream)))
			{
				thisNode.Symbol = (int)read8Bits(ref stream);
				return thisNode;
			}

			thisNode.ChildA = recoverTree(nodes, ref stream, ref nodenum);
			thisNode.ChildB = recoverTree(nodes, ref stream, ref nodenum);

			return thisNode;
		}

		// Распаковка
		public static uint Decompress(byte[] input, byte[] output, uint inputSize, uint outputSize)
		{
			Node[] nodes = new Node[MAX_TREE_NODES];

			for (int counter = 0; counter < nodes.Length; ++counter)
			{
				nodes[counter] = new Node();
			}

			Node root, node;
			BitStream stream = new BitStream();
			uint i, nodeCount;
			byte[] buffer;

			if (inputSize < 1)
				return 0;

			initBitstream(ref stream, input);
			nodeCount = 0;
			root = recoverTree(nodes, ref stream, ref nodeCount);
			buffer = output;

			// вот тут иедм по дереву пока не найдем символ.
			// если нашли начинаем искать следующий
			for (i = 0; i < outputSize; ++i)
			{
				node = root;
				try
				{
					while (node.Symbol < 0)
					{
						if (Convert.ToBoolean(readBit(ref stream)))
							node = node.ChildB;
						else
							node = node.ChildA;
					}
				}
                catch(IndexOutOfRangeException ex)
                {
					// это на случай если чтото пошло не так.
					// в норме срабоать не может
					break;
                }
				buffer[i] = (byte)node.Symbol;
			}
			return i;
		}
	}
}
