using System;

public class MixedNumber
{
    public MixedNumber(bool ujemna, int czesc_calkowita, int licznik, int mianownik)
    {
        Zn = ujemna;
        C = czesc_calkowita;
        M = mianownik;
        L = licznik;
    }

    public MixedNumber(int czesc_calkowita, int licznik, int mianownik) :
    this(czesc_calkowita < 0, Math.Abs(czesc_calkowita), licznik, mianownik)
    { }

    public MixedNumber(int licznik, int mianownik) :
    this((licznik < 0) ^ (mianownik < 0), 0, Math.Abs(licznik), Math.Abs(mianownik))
    { }

    public void Deconstruct(out bool zn, out int c, out int l, out int m){
        (zn, c, l, m) = (Zn, C, L, M);
    }

    public static int repairs = 0;
    private int _l = 0;
    private int _m = 0;
    private int _c = 0;

    public bool Zn { get; set; }
    public int C
    {
        get => _c;
        set
        {
            if (value < 0)
                value = 0;
            _c = value;
        }
    }
    public int L
    {
        get => _l;
        set
        {
            if (value < 0)
                value = 0;
            _l = value;
            reduceIfPossible();
            divideIfPossible();
        }
    }

    public double ToDouble
    {
        get
        {
            double d = (double)(L + C * M)/M;
            if(Zn)
                d *= -1;
            return d;
        }
    }

    public override string ToString()
    {
        return $"{(Zn?"-":"")}{L + C * M}/{M}";
    }

    public int M
    {
        get => _m;
        set
        {
            if (value <= 0)
                value = 1;
            _m = value;
            reduceIfPossible();
            divideIfPossible();
        }
    }

    private static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }

    private void reduceIfPossible()
    {
        if(L >= M) 
            repairs++;
        while (L >= M)
        {
            C += 1;
            _l -= M;
        }
    }
    private void divideIfPossible()
    {
        var v = GCD(L, M);
        if (L != 0 && M != 0 && v != 1)
        {
            repairs++;
            _l = L / v;
            _m = M / v;
        }
    }

    public static bool operator >(MixedNumber a, MixedNumber b)
    {
        if (a.Zn != b.Zn)
            return !a.Zn;
        int la = (a.L + a.C * a.M) * b.M;
        int lb = (b.L + b.C * b.M) * a.M;

        return a.Zn != (la > lb);
    }

    public static bool operator <(MixedNumber a, MixedNumber b)
    {
        return !(a > b);
    }

    public static MixedNumber operator +(MixedNumber a, MixedNumber b)
    {
        bool zn;
        int la = (a.L + a.C * a.M) * b.M;
        int lb = (b.L + b.C * b.M) * a.M;
        int m = a.M * b.M;
        int l;
        if (a.Zn != b.Zn)
            l = Math.Abs(la - lb);
        else
        {
            l = la + lb;
        }
        if (la > lb)
            zn = a.Zn;
        else
            zn = b.Zn;
        if (zn)
            l = -l;
        return new MixedNumber(l, m);
    }
}
