using System;
using Phanso;
class Program
{
    static void Main()
    {
        PhanSo ps1 = new();
        ps1.Nhap();
        PhanSo ps2 = new();
        ps2.Nhap();
        (ps1 + ps2).Xuat();
        (ps1 - ps2).Xuat();
        (ps1 * ps2).Xuat();
        (ps1 / ps2).Xuat();
        Console.WriteLine();
        PhanSo[] arrPhanSo = new PhanSo[]{
                new PhanSo(3, 4),
                new PhanSo(1, 2),
                new PhanSo(5, 8),
            };

        Array.Sort(arrPhanSo);

        foreach (var PhanSo in arrPhanSo)
        {
            Console.WriteLine($"{PhanSo.TuSo}/{PhanSo.MauSo}");
        }

    }
}