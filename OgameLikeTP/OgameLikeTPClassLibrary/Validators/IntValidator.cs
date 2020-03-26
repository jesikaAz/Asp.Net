﻿using System.ComponentModel.DataAnnotations;


namespace OgameLikeTPClassLibrary.Validators
{
    public class IntValidator : ValidationAttribute
    {
        private int min;
        private int max;

        public IntValidator(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
        public override bool IsValid(object value)
        {
            bool result = true;
            int parsedInt;
            if (value != null)
            {
                if (int.TryParse(value.ToString(), out parsedInt))
                {
                    if (parsedInt < min || parsedInt > max)
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }
    }
}