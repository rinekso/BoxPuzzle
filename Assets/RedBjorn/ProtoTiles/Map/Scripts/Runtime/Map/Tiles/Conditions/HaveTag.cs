using RedBjorn.ProtoTiles.Paths;
using UnityEngine;

namespace RedBjorn.ProtoTiles.Tiles.Conditions
{
    [CreateAssetMenu(menuName = ScriptablePath.Tiles.Have)]
    public class HaveTag : TileCondition
    {
        public TileTag Tag;

        public override bool IsMet(TileEntity tile)
        {
            return tile.Preset.Tags.Contains(Tag);
        }
    }
}
