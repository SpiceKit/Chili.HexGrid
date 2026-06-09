# Chili Hex Grid

C# 向けの軽量なヘックスグリッドライブラリです。

Chili Hex Grid は、軸座標（Axial Coordinates）によるヘックス座標表現と、隣接座標取得、座標回転、2 次元座標変換などの基本的なグリッド操作を提供します。

## 特徴

* 軸座標によるヘックス座標表現 (`HexCoordinates`)
* Pointy Top 形式のヘックスグリッド実装
* 隣接座標の取得
* ヘックス座標の回転
* ヘックス座標から 2 次元座標への変換
* 外部ライブラリへの依存なし

## 使用例

```csharp
using Chili;

IHexGrid grid = new PointyTopHexGrid();

var center = new HexCoordinates(0, 0);

var neighbors = grid.GetNeighbors(center);

foreach (var neighbor in neighbors)
{
    Console.WriteLine(neighbor);
}
```

出力:

```text
(0, 1)
(1, 0)
(1, -1)
(0, -1)
(-1, 0)
(-1, 1)
```

## 座標の回転

原点を中心として座標を回転します。

```csharp
var coord = new HexCoordinates(1, 0);

var rotated = grid.Rotate(coord, 1);
```

正の値を指定すると、60 度単位で時計回りに回転します。

## 座標変換

ヘックス座標を 2 次元座標へ変換します。

```csharp
var point = grid.ToPoint(
    new HexCoordinates(2, 1),
    radius: 32f);
```

## 距離の取得

```csharp
int distance = HexCoordinates.Distance(a, b);
```

## ライセンス

zlib/libpng License