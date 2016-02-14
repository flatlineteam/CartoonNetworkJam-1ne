// This class is auto-generated do not modify
namespace k
{
	public static class Layers
	{
		public const int DEFAULT = 0;
		public const int TRANSPARENT_FX = 1;
		public const int IGNORE_RAYCAST = 2;
		public const int WATER = 4;
		public const int UI = 5;
		public const int PLAYER = 8;
		public const int FRIENDLY = 9;
		public const int BUSY_STREET_GOAL = 10;
		public const int HAZARD = 11;
		public const int WORLD_END = 31;


		public static int onlyIncluding( params int[] layers )
		{
			int mask = 0;
			for( var i = 0; i < layers.Length; i++ )
				mask |= ( 1 << layers[i] );

			return mask;
		}


		public static int everythingBut( params int[] layers )
		{
			return ~onlyIncluding( layers );
		}
	}
}