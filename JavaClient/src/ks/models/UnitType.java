package ks.models;

import java.lang.*;
import java.util.*;
import java.nio.*;
import java.nio.charset.Charset;

import ks.KSObject;

public enum UnitType
{
	Soldier((byte) 0),
	Tank((byte) 1),
	Aircraft((byte) 2),
	Artillery((byte) 3),
	HeavyMachineGunner((byte) 4),
	;

	private final byte value;
	UnitType(byte value) { this.value = value; }
	public byte getValue() { return value; }
	
	private static Map<Byte, UnitType> reverseLookup;
	
	public static UnitType of(byte value)
	{
		if (reverseLookup == null)
		{
			reverseLookup = new HashMap<>();
			for (UnitType c : UnitType.values())
				reverseLookup.put(c.getValue(), c);
		}
		return reverseLookup.get(value);
	}
}
