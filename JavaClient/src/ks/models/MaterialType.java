package ks.models;

import java.lang.*;
import java.util.*;
import java.nio.*;
import java.nio.charset.Charset;

import ks.KSObject;

public enum MaterialType
{
	Powder((byte) 0),
	Steel((byte) 1),
	Aluminum((byte) 2),
	Shell((byte) 3),
	Nickel((byte) 4),
	Manganese((byte) 5),
	Chromium((byte) 6),
	;

	private final byte value;
	MaterialType(byte value) { this.value = value; }
	public byte getValue() { return value; }
	
	private static Map<Byte, MaterialType> reverseLookup;
	
	public static MaterialType of(byte value)
	{
		if (reverseLookup == null)
		{
			reverseLookup = new HashMap<>();
			for (MaterialType c : MaterialType.values())
				reverseLookup.put(c.getValue(), c);
		}
		return reverseLookup.get(value);
	}
}
