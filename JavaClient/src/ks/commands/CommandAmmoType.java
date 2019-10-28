package ks.commands;

import java.lang.*;
import java.util.*;
import java.nio.*;
import java.nio.charset.Charset;

import ks.KSObject;

public enum CommandAmmoType
{
	RifleBullet((byte) 0),
	TankShell((byte) 1),
	Bomb((byte) 2),
	ArtilleryShell((byte) 3),
	HMGBullet((byte) 4),
	;

	private final byte value;
	CommandAmmoType(byte value) { this.value = value; }
	public byte getValue() { return value; }
	
	private static Map<Byte, CommandAmmoType> reverseLookup;
	
	public static CommandAmmoType of(byte value)
	{
		if (reverseLookup == null)
		{
			reverseLookup = new HashMap<>();
			for (CommandAmmoType c : CommandAmmoType.values())
				reverseLookup.put(c.getValue(), c);
		}
		return reverseLookup.get(value);
	}
}
