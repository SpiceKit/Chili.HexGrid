// zlib/libpng License
//
// Copyright (c) 2026 Gai Takakura
//
// This software is provided 'as-is', without any express or implied warranty.
// In no event will the authors be held liable for any damages arising from the use of this software.
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it freely,
// subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software.
//    If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
// 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
// 3. This notice may not be removed or altered from any source distribution.
using System;

namespace Chili
{
	public readonly struct Point2
	{
		public float X { get; }
		public float Y { get; }

		public Point2(float x, float y)
		{
			X = x;
			Y = y;
		}
	}

	public interface IHexGrid
	{
		Point2 ToPoint(HexCoordinates coordinate, float radius);
		HexCoordinates[] GetNeighbors(HexCoordinates coordinate);
		HexCoordinates GetNeighbor(HexCoordinates coordinate, int dir);
		HexCoordinates Rotate(HexCoordinates coordinate, int steps);
	}

	public sealed class PointyTopHexGrid : IHexGrid
	{
		public Point2 ToPoint(HexCoordinates coordinate, float radius = 1f)
		{
			float width = (float)Math.Sqrt(3f) * radius;
			float height = 1.5f * radius;
			float x = width * coordinate.Column + (coordinate.Row * width * 0.5f);
			float y = coordinate.Row * height;
			return new Point2( x, y );
		}

		public HexCoordinates[] GetNeighbors(HexCoordinates coordinate)
		{
			return new HexCoordinates[]
			{
				new HexCoordinates(coordinate.Q    , coordinate.R + 1),  // 右上
				new HexCoordinates(coordinate.Q + 1, coordinate.R),      // 右
				new HexCoordinates(coordinate.Q + 1, coordinate.R - 1),  // 右下
				new HexCoordinates(coordinate.Q    , coordinate.R - 1),  // 左下
				new HexCoordinates(coordinate.Q - 1, coordinate.R),      // 左
				new HexCoordinates(coordinate.Q - 1, coordinate.R + 1),  // 左上
			};
		}

		public HexCoordinates GetNeighbor(HexCoordinates coordinate, int dir)
		{
			return dir switch
			{
				0 => new HexCoordinates(coordinate.Q    , coordinate.R + 1),  // 右上
				1 => new HexCoordinates(coordinate.Q + 1, coordinate.R),      // 右
				2 => new HexCoordinates(coordinate.Q + 1, coordinate.R - 1),  // 右下
				3 => new HexCoordinates(coordinate.Q    , coordinate.R - 1),  // 左下
				4 => new HexCoordinates(coordinate.Q - 1, coordinate.R),      // 左
				5 => new HexCoordinates(coordinate.Q - 1, coordinate.R + 1),  // 左上
				_ => throw new System.NotImplementedException(),
			};
		}

		public HexCoordinates Rotate(HexCoordinates coordinate, int steps)
		{
			steps = ((steps % 6) + 6) % 6;
			var q = coordinate.Q;
			var r = coordinate.R;
			var s = coordinate.S;

			return steps switch
			{
				0 => coordinate,

				1 => new HexCoordinates(-s, -q),
				2 => new HexCoordinates( r,  s),
				3 => new HexCoordinates(-q, -r),
				4 => new HexCoordinates( s,  q),
				5 => new HexCoordinates(-r, -s),

				_ => throw new System.InvalidOperationException(),
			};
		}
	}

	//public sealed class FlatTopHexGrid : IHexGrid {}
}
