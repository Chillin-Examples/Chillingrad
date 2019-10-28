using System;

using KoalaTeam.Chillin.Client;
using KS;
using KS.Commands;
using KS.Models;

using KSObject = KS.KSObject;

namespace Game
{
	public class AI : RealtimeAI<World, KSObject>
	{
		private readonly Random random = new Random();

		public AI(World world) : base(world)
		{
		}

		public override void Initialize()
		{
			Console.WriteLine("initialize");
		}

		public override void Decide()
		{
			Console.WriteLine("decide");
		}
	}
}
