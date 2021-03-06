﻿using System;
using System.Collections.Generic;

namespace KSPAdvancedFlyByWire
{

    public enum CurveType
    {
        Identity,
        XSquared,
        SqrtX,
        SqrtOfOneMinusXSquared,
        OneOverMinusLnX
    }

    public class Curve
    {
        public virtual float Evaluate(float x)
        {
            return x;
        }
    }

    public class XSquared : Curve
    {
        public override float Evaluate(float x)
        {
            return x * x;
        }
    }

    public class SqrtX : Curve
    {
        public override float Evaluate(float x)
        {
            return (float)Math.Sqrt(x);
        }
    }

    public class SqrtOfOneMinusXSquared : Curve
    {
        public override float Evaluate(float x)
        {
            return (float)Math.Sqrt(1.0 - x * x);
        }
    }

    public class OneOverMinusLnX : Curve
    {
        public override float Evaluate(float x)
        {
            return (float)Math.Sign(x) * 1.0f / (float)-Math.Log((float)Math.Abs(x)) - (float)Math.Sign(x);
        }
    }

    public class CurveFactory
    {

        public static Curve Instantiate(CurveType type)
        {
            switch (type)
            {
            case CurveType.Identity:
                return new Curve();
            case CurveType.XSquared:
                return new XSquared();
            case CurveType.SqrtX:
                return new SqrtX();
            case CurveType.SqrtOfOneMinusXSquared:
                return new SqrtOfOneMinusXSquared();
            case CurveType.OneOverMinusLnX:
                return new OneOverMinusLnX();
            }

            return null;
        }

    }

}
