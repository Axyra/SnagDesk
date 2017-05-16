using System;
using System.ComponentModel.DataAnnotations;

namespace SnagDesk.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IntValueAttribute : ValidationAttribute
    {
        public IntValueEquation Equation { get; }
        public int Value { get; }

        public IntValueAttribute(IntValueEquation equation, int value)
        {
            Equation = equation;
            Value = value;
        }

        public override bool IsValid(object value)
        {
            if (!(value is int)) return false;

            var number = (int) value;

            switch (Equation)
            {
                case IntValueEquation.Less:
                    return number < Value;

                case IntValueEquation.LessOrEqual:
                    return number <= Value;

                case IntValueEquation.Equal:
                    return number == Value;

                case IntValueEquation.Greater:
                    return number > Value;

                case IntValueEquation.GreaterOrEqual:
                    return number >= Value;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum IntValueEquation
    {
        Less = 1, LessOrEqual, Equal, Greater, GreaterOrEqual
    }
}