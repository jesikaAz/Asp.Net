﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OgameLikeTPClassLibrary.Validators
{
    public class DatetimeMoreThanNow : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;
            DateTime dateTime;

            if (DateTime.TryParse(value.ToString(), out dateTime))
            {
                if (DateTime.Compare(dateTime, DateTime.Now) < 0)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}