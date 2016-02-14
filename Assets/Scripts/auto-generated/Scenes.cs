//This class is auto-generated do not modify
using UnityEngine.SceneManagement;
namespace k
{
	public static class Scenes
	{
		public const string HUB_SCENE = "HubScene";
		public const string RACING_SCENE = "RacingScene";
		public const string BUSY_STREET_SCENE = "BusyStreetScene";

		public const int TOTAL_SCENES = 3;


		public static int nextSceneIndex()
		{
			if( SceneManager.GetActiveScene().buildIndex + 1 == TOTAL_SCENES )
				return 0;
			return SceneManager.GetActiveScene().buildIndex + 1;
		}
	}
}