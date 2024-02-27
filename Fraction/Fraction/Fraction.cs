namespace Fraction;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction(int a, int b)
    {
        this._numerator = a;
        this._denominator = b;
    }
    
    public Fraction(Fraction x)
    {
        this._numerator = x._numerator;
        this._denominator = x._denominator;
    }
    
    public Fraction Plus(Fraction other)
    {
        var num = this._numerator * other._denominator + this._denominator * other._numerator;
        var denom = this._denominator * other._denominator;
        return new Fraction(num, denom).Reduce();
    }

    public Fraction Minus(Fraction other)
    {
        var num = this._numerator * other._denominator - this._denominator * other._numerator;
        var denom = this._denominator * other._denominator;
        return new Fraction(num, denom).Reduce();
    }

    public Fraction Times(Fraction other)
    {
        var num = this._numerator * other._numerator;
        var denom = this._denominator * other._denominator;
        return new Fraction(num, denom).Reduce();
    }

    public Fraction DivideBy(Fraction other)
    {
        var num = this._numerator * other._denominator;
        var denom = this._denominator * other._numerator;
        return new Fraction(num, denom).Reduce();
    }

    public double ToDouble()
    {
        return (double)this._numerator / this._denominator;
    }
    
    public override bool Equals(object obj)
    {
        if(object.ReferenceEquals(this, obj)) return true;
        if (obj == null || GetType() != obj.GetType()) return false;
        var other = (Fraction)obj;
        return this._numerator * other._denominator == this._denominator * other._numerator;
    }

    public override int GetHashCode()
    {
        return Tuple.Create(_numerator, _denominator).GetHashCode();
    }
    
    public bool GreaterThan(Fraction other)
    {
        var first = this.Reduce();
        var second = other.Reduce();
        return this._numerator > other._numerator;
    }

    public bool LessThan(Fraction other)
    {
        return !Equals(other);
    }

    public bool GreaterOrEqual(Fraction other)
    {
        return Equals(other) || GreaterThan(other);
    }

    public bool LessOrEqual(Fraction other)
    {
        return Equals(other) || LessThan(other);
    }

    private int GreatestCommonDenominator()
    {
        var num = this._numerator;
        var denom = this._denominator;
        int t;
        while (denom != 0)
        {
            t = denom;
            denom = num % denom;
            num = t;
        }
        return num;
    }
    
    private Fraction Reduce()
    {
        var gcd = this.GreatestCommonDenominator();
        var num = this._numerator / gcd;
        var denom = this._denominator / gcd;
        return new Fraction(num, denom);
    }

    public override string ToString()
    {
        return _numerator + "/" + _denominator;
    }
    
}