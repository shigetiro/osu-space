using osu.Game.Beatmaps;
using osu.Game.Rulesets.Space.Objects;
using osu.Game.Rulesets.Replays;
using System.Collections.Generic;
using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.Space.Replays
{
    public class SpaceAutoGenerator : AutoGenerator<SpaceReplayFrame>
    {
        public new Beatmap<SpaceHitObject> Beatmap => (Beatmap<SpaceHitObject>)base.Beatmap;

        public SpaceAutoGenerator(IBeatmap beatmap, IReadOnlyList<Mod> mods)
            : base(beatmap)
        {
        }

        protected override void GenerateFrames()
        {
            Frames.Add(new SpaceReplayFrame());

            foreach (SpaceHitObject hitObject in Beatmap.HitObjects)
            {
                Frames.Add(new SpaceReplayFrame
                {
                    Time = hitObject.StartTime,
                    Position = hitObject.Position,
                });
            }
        }
    }
}
