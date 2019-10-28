package ai;

import team.koala.chillin.client.RealtimeAI;
import ks.KSObject;
import ks.models.*;
import ks.commands.*;


public class AI extends RealtimeAI<World, KSObject> {

	public AI(World world) {
		super(world);
	}

	@Override
	public void initialize() {
		System.out.println("initialize");
	}

	@Override
	public void decide() {
		System.out.println("decide");
	}
}
