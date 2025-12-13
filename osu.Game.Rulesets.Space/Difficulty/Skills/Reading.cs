using System;
using osu.Game.Rulesets.Difficulty.Preprocessing;
using osu.Game.Rulesets.Difficulty.Skills;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Space.Difficulty.Preprocessing;

namespace osu.Game.Rulesets.Space.Difficulty.Skills
{
    public class Reading : StrainSkill
    {
        protected virtual double SkillMultiplier => 1.0;
        protected virtual double StrainDecayBase => 0.15;

        private double currentStrain;

        public Reading(Mod[] mods)
            : base(mods)
        {
        }

        protected override double StrainValueAt(DifficultyHitObject current)
        {
            currentStrain *= strainDecay(current.DeltaTime);
            currentStrain += StrainValueOf(current) * SkillMultiplier;

            return currentStrain;
        }

        protected override double CalculateInitialStrain(double time, DifficultyHitObject current)
        {
            return currentStrain * strainDecay(time - current.Previous(0).StartTime);
        }

        protected double StrainValueOf(DifficultyHitObject current)
        {
            var spaceObject = (SpaceDifficultyHitObject)current;

            double density = 1.0 / Math.Max(current.DeltaTime, 50);

            double overlapBonus = 1.0;
            if (spaceObject.JumpDistance < 50)
            {
                overlapBonus = 1.2;
            }

            return density * overlapBonus;
        }

        private double strainDecay(double ms) => Math.Pow(StrainDecayBase, ms / 1000);
    }
}
