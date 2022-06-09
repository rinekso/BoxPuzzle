namespace RedBjorn.ProtoTiles.Paths
{
    public class ScriptablePath
    {
        public const string Root = Utils.Paths.ScriptablePath.Root + "/" + Asset + "/";
        public const string Asset = nameof(ProtoTiles);

        public class Tiles
        {
            public const string Have = Root + nameof(ProtoTiles.Tiles) + "/" + nameof(ProtoTiles.Tiles.Conditions) + "/" + "Have tag";
            public const string Not = Root + nameof(ProtoTiles.Tiles) + "/" + nameof(ProtoTiles.Tiles.Conditions) + "/" + "Not";
            public const string Tag = Root + nameof(ProtoTiles.Tiles) + "/" + "Tag";
        }

        public const string Map = Root + "Map";

        public const string MapWindow = Root + "Map Window Settings";

    }
}
