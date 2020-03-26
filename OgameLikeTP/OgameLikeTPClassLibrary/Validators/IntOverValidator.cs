using System.ComponentModel.DataAnnotations;


namespace OgameLikeTPClassLibrary.Validators
{
    public class IntOverValidator : ValidationAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override bool IsValid(object value)
        {
            bool result = true;
            int parsedInt;
            if (value != null)
            {
                if (int.TryParse(value.ToString(), out parsedInt))
                {
                    if (parsedInt < Min || parsedInt > Max)
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