// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

#nullable enable

using osu.Game.Configuration;
using osu.Game.Rulesets.Configuration;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Space.Configuration
{
    public class SpaceRulesetConfigManager : RulesetConfigManager<SpaceRulesetSetting>
    {
        public SpaceRulesetConfigManager(SettingsStore? settings, RulesetInfo ruleset, int? variant = null)
            : base(settings, ruleset, variant)
        {
        }

        protected override void InitialiseDefaults()
        {
            base.InitialiseDefaults();
            SetDefault(SpaceRulesetSetting.SnakingInSliders, true);
            SetDefault(SpaceRulesetSetting.SnakingOutSliders, true);
            SetDefault(SpaceRulesetSetting.ShowCursorTrail, true);
            SetDefault(SpaceRulesetSetting.PlayfieldBorderStyle, PlayfieldBorderStyle.None);
        }
    }

    public enum SpaceRulesetSetting
    {
        SnakingInSliders,
        SnakingOutSliders,
        ShowCursorTrail,
        PlayfieldBorderStyle,
    }
}
