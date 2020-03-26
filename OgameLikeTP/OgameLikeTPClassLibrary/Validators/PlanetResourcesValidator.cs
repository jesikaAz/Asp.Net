using OgameLikeTPClassLibrary.Extensions;
using OgameLikeTPClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
              
                if (resources.Count != 4)
                {
                    result = false;
                }

                bool energyBool = false;
                bool oxygenBool = false;
                bool steelBool = false;
                bool uraniumBool = false;

                resources.ForEach((x) =>
                {
                    if (ResourceNames.Energy.GetName() == x.Name)
                    {
                        energyBool = true;
                    }
                    else if (ResourceNames.Oxygen.GetName() == x.Name)
                    {
                        result = false;
                        oxygenBool = true;
                    }
                    else if (ResourceNames.Steel.GetName() == x.Name)
                    {
                        steelBool = true;
                    }
                    else if (ResourceNames.Uranium.GetName() == x.Name)
                    {
                        uraniumBool = true;
                    }
                });

                if (!(energyBool && oxygenBool && steelBool && uraniumBool))
                {
                    result = false;
                }
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