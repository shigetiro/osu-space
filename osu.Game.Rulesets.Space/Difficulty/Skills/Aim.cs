using System;
using osu.Game.Rulesets.Difficulty.Preprocessing;
using osu.Game.Rulesets.Difficulty.Skills;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Space.Difficulty.Preprocessing;

namespace osu.Game.Rulesets.Space.Difficulty.Skills
{
    public class Aim : StrainSkill
    {
        protected virtual double SkillMultiplier => 10;
        protected virtual double StrainDecayBase => 0.15;

        private double currentStrain;

        public Aim(Mod[] mods)
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
            var spaceCurrent = (SpaceDifficultyHitObject)current;

            double time = Math.Max(spaceCurrent.DeltaTime, 50);

            double velocity = spaceCurrent.JumpDistance / time;

            double angleBonus = 1.0;
            if (spaceCurrent.Angle != null)
            {
                double angle = spaceCurrent.Angle.Value;

                double angleFactor = Math.Sin(angle);
                angleBonus = 1.0 + 0.5 * angleFactor;
            }

            return velocity * angleBonus;
        }

        private double strainDecay(double ms) => Math.Pow(StrainDecayBase, ms / 1000);
    }
}
