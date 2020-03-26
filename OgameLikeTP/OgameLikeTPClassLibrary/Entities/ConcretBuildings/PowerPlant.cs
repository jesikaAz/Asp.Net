﻿using OgameLikeTPClassLibrary.Extensions;
using OgameLikeTPClassLibrary.Utils;
using System;
using System.Collections.Generic;

namespace OgameLikeTPClassLibrary.Entities.ConcretBuildings
{
    public class PowerPlant : ResourceGenerator
    {
        private Func<int?, int?> energyFunc = (int? x) => { return x; };
        private Func<int?, int?> oxygenFunc = (int? x) => { return x + (200 * (x / 10)) + 20; };
        private Func<int?, int?> steelFunc = (int? x) => { return x + (100 * (x / 8)) + 20; };
        private Func<int?, int?> uraniumFunc = (int? x) => { return int.Parse((Math.Pow(x.Value, 3) + (200 * (x / 20)) + 20).ToString()); };

        public override List<Resource> TotalCost
        {
            get
            {
                List<Resource> result = new List<Resource>()
                {
                    new Resource() { Name = ResourceNames.Energy.GetName(), LastUpdate = DateTime.Now,
                        LastQuantity = MathUtil.FactorialExpression(energyFunc,this.Level) },
                    new Resource() { Name = ResourceNames.Oxygen.GetName(), LastUpdate = DateTime.Now,
                        LastQuantity = MathUtil.FactorialExpression(oxygenFunc,this.Level) },
                    new Resource() { Name = ResourceNames.Steel.GetName(), LastUpdate = DateTime.Now,
                        LastQuantity = MathUtil.FactorialExpression(steelFunc,this.Level) },
                    new Resource() { Name = ResourceNames.Uranium.GetName(), LastUpdate = DateTime.Now,
                        LastQuantity = MathUtil.FactorialExpression(uraniumFunc,this.Level) }
                };

                return result;
            }
        }

        public override List<Resource> NextCost
        {
            get
            {
                List<Resource> result = new List<Resource>()
                {
                    new Resource() { Name = ResourceNames.Energy.GetName(), LastUpdate = DateTime.Now, LastQuantity = energyFunc.Invoke(this.Level + 1) },
                    new Resource() { Name = ResourceNames.Oxygen.GetName(), LastUpdate = DateTime.Now, LastQuantity = oxygenFunc.Invoke(this.Level + 1) },
                    new Resource() { Name = ResourceNames.Steel.GetName(), LastUpdate = DateTime.Now, LastQuantity = steelFunc.Invoke(this.Level + 1) },
                    new Resource() { Name = ResourceNames.Uranium.GetName(), LastUpdate = DateTime.Now, LastQuantity = uraniumFunc.Invoke(this.Level + 1) }
                };

                return result;
            }
        }

        public override List<Resource> ResourceBySecond
        {
            get
            {
                List<Resource> result = new List<Resource>()
                {
                    new Resource() { Name = ResourceNames.Energy.GetName(), LastUpdate = DateTime.Now, LastQuantity = 3 * this.Level + 10 }
                };

                return result;
            }
        }
    }
}