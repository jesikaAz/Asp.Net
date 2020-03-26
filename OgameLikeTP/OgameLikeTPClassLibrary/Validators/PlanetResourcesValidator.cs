using OgameLikeTPClassLibrary.Extensions;
using OgameLikeTPClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace OgameLikeTPClassLibrary.Validators
{
    public class PlanetResourcesValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;

            try
            {
                List<Resource> resources = value as List<Resource>;
                List<String> names = new List<string>()
                {
                    ResourceNames.Energy.GetName(),
                    ResourceNames.Oxygen.GetName(),
                    ResourceNames.Steel.GetName(),
                    ResourceNames.Uranium.GetName()
                };
                if (resources.Count != 4)
                {
                    result = false;
                }

                resources.ForEach((x) =>
                {
                    if (!names.Contains(x.Name))
                    {
                        result = false;
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                result = false;
            }

            return result;
        }
    }
}