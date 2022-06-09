using RedBjorn.ProtoTiles.Paths;
using UnityEngine;

namespace RedBjorn.ProtoTiles.Tiles.Conditions
{
    [CreateAssetMenu(menuName = ScriptablePath.Tiles.Not)]
    public class Not : TileCondition
    {
        public TileCondition Condition;

        public override bool IsMet(TileEntity tile)
        {
            return Condition == null ? false : !Condition.IsMet(tile);
        }
    }
}
